/**
 * @description router全局配置，如有必要可分文件抽离，其中asyncRoutes只有在intelligence模式下才会用到，pro版只支持remixIcon图标，具体配置请查看vip群文档
 */
import type { RouteRecordName, RouteRecordRaw } from 'vue-router'
import type { VabRouteRecord } from '/#/router'
import {
  createRouter,
  createWebHashHistory,
  createWebHistory,
} from 'vue-router'
import Layout from '@vab/layouts/index.vue'
import { setupPermissions } from './permissions'
import { authentication, isHashRouterMode, publicPath } from '@/config'

export const constantRoutes: VabRouteRecord[] = [
  {
    path: '/login',
    name: 'Login',
    component: () => import('@/views/login/index.vue'),
    meta: {
      hidden: true,
    },
  },
  {
    path: '/register',
    name: 'Register',
    component: () => import('@/views/register/index.vue'),
    meta: {
      hidden: true,
    },
  },
  {
    path: '/403',
    name: '403',
    component: () => import('@/views/403.vue'),
    meta: {
      hidden: true,
    },
  },
  {
    path: '/404',
    name: '404',
    component: () => import('@/views/404.vue'),
    meta: {
      hidden: true,
    },
  },
]

export const asyncRoutes: VabRouteRecord[] = [
  {
    path: '/',
    name: 'Root',
    component: Layout,
    meta: {
      title: '首页',
      icon: 'home-2-line',
      breadcrumbHidden: true,
    },
    children: [
      {
        path: 'index',
        name: 'Index',
        component: () => import('@/views/index/index.vue'),
        meta: {
          title: '首页',
          icon: 'reserved-line',
          noClosable: true,
        },
      },
    ],
  },
  {
    path: '/sys',
    name: 'system',
    component: Layout,
    meta: {
      title: '系统管理',
      icon: 'settings-3-line',
      //breadcrumbHidden: true,
    },
    children: [
      {
        path: 'sysuser',
        name: 'sysuser',
        component: () => import('@/views/system/sysuser/index.vue'),
        meta: {
          title: '用户管理',
          icon: 'user-line',
        },
      },
      {
        path: 'sysmenu',
        name: 'sysmenu',
        component: () => import('@/views/system/sysmenu/index.vue'),
        meta: {
          title: '菜单管理',
          icon: 'apps-2-line',
        },
      },
      {
        path: 'sysrole',
        name: 'sysrole',
        component: () => import('@/views/system/sysrole/index.vue'),
        meta: {
          title: '角色管理',
          icon: 'user-smile-line',
        },
      },
      {
        path: 'syslog',
        name: 'syslog',
        //component: () => import('@/views/system/sysrole/index.vue'),
        meta: {
          title: '日志管理',
          icon: 'book-3-line',
        },
        children: [
          {
            path: 'sysoplog',
            name: 'sysoplog',
            component: () => import('@/views/system/syslog/sysoplog/index.vue'),
            meta: {
              title: '操作日志',
              icon: 'user-settings-line',
            },
          },
          {
            path: 'sysexlog',
            name: 'sysexlog',
            component: () => import('@/views/system/syslog/sysexlog/index.vue'),
            meta: {
              title: '错误日志',
              icon: 'signal-wifi-error-line',
            },
          },
        ],
      },
    ],
  },
  {
    path: '/:pathMatch(.*)*',
    redirect: '/404',
    name: 'NotFound',
    meta: {
      hidden: true,
    },
  },
]

const router = createRouter({
  history: isHashRouterMode
    ? createWebHashHistory(publicPath)
    : createWebHistory(publicPath),
  routes: constantRoutes as RouteRecordRaw[],
})

function fatteningRoutes(routes: VabRouteRecord[]): VabRouteRecord[] {
  return routes.flatMap((route: VabRouteRecord) => {
    return route.children ? fatteningRoutes(route.children) : route
  })
}

function addRouter(routes: VabRouteRecord[]) {
  routes.forEach((route: VabRouteRecord) => {
    if (!router.hasRoute(route.name)) router.addRoute(route as RouteRecordRaw)
    if (route.children) addRouter(route.children)
  })
}

export function resetRouter(routes: VabRouteRecord[] = constantRoutes) {
  routes.map((route: VabRouteRecord) => {
    if (route.children) route.children = fatteningRoutes(route.children)
  })
  router.getRoutes().forEach(({ name }) => {
    router.hasRoute(<RouteRecordName>name) &&
      router.removeRoute(<RouteRecordName>name)
  })
  addRouter(routes)
}

export function setupRouter(app: any) {
  if (authentication === 'intelligence') addRouter(asyncRoutes)
  setupPermissions(router)
  app.use(router)
  return router
}

export default router
