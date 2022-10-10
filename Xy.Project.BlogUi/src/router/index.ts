import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "home",
    component: () => import("../views/home/index.vue"),
    meta: {
      ShowNavMenu: false, //是否显示导航栏
    },
  },
  {
    path: "/mine",
    name: "mine",
    component: () => import("../views/mine/index.vue"),
    meta: {
      ShowNavMenu: true, //是否显示导航栏
    },
  },
  {
    path: "/blog",
    name: "blog",
    component: () => import("../views/blog/index.vue"),
    meta: {
      ShowNavMenu: true, //是否显示导航栏
    },
  },
  {
    path: "/bloginfo",
    name: "bloginfo",
    component: () => import("../views/blog/bloginfo.vue"),
    meta: {
      ShowNavMenu: true, //是否显示导航栏
    },
  },
  {
    path: "/placefile", //归档
    name: "placefile",
    component: () => import("../views/placefile/index.vue"),
    meta: {
      ShowNavMenu: true, //是否显示导航栏
    },
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
