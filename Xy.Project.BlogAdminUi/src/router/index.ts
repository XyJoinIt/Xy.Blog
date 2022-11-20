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
          icon: 'home-2-line',
          noClosable: true,
        },
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
