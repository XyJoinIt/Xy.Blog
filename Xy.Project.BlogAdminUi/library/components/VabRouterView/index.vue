<script lang="ts" setup>
  import { useSettingsStore } from '@/store/modules/settings'
  import { useTabsStore } from '@/store/modules/tabs'
  import { handleActivePath } from '@/utils/routes'
  import { keepAliveMaxNum } from '@/config'
  import { useHead } from '@vueuse/head'
  import { VabRoute, VabRouteRecord } from '/#/router'
  import VabProgress from 'nprogress'

  const route: VabRoute = useRoute()

  const $sub: any = inject('$sub')
  const $unsub: any = inject('$unsub')

  const settingsStore = useSettingsStore()
  const { theme } = storeToRefs(settingsStore)
  const tabsStore = useTabsStore()
  const { getVisitedRoutes: visitedRoutes } = storeToRefs(tabsStore)

  const componentRef = ref()
  const routerKey = ref()
  const keepAliveNameList = ref()

  const siteData = reactive({
    description: '',
  })
  useHead({
    meta: [
      {
        name: `description`,
        content: computed(() => siteData.description),
      },
    ],
  })

  const updateKeepAliveNameList = (refreshRouteName = null) => {
    keepAliveNameList.value = visitedRoutes.value
      .filter(
        (item: VabRouteRecord) =>
          !item.meta.noKeepAlive && item.name !== refreshRouteName
      )
      .flatMap((item: VabRouteRecord) => item.name)
  }

  // 更新KeepAlive缓存页面
  watchEffect(() => {
    routerKey.value = handleActivePath(route, true)
    updateKeepAliveNameList()
    siteData.description = `${'Vue'} ${'Admin'} ${'Plus'}-${
      route.meta.title
    }简介、官网、首页、文档和下载 - 前端开发框架`
  })

  $sub('get-code', () => {
    window.open(
      `https://github.com/vue-admin-beautiful/admin-plus/blob/main/${componentRef.value.$options.__source}`
    )
  })

  $sub('reload-router-view', (refreshRouteName: any = route.name) => {
    if (theme.value.showProgressBar) VabProgress.start()
    const cacheActivePath = routerKey.value
    routerKey.value = null
    updateKeepAliveNameList(refreshRouteName)
    nextTick(() => {
      routerKey.value = cacheActivePath
      updateKeepAliveNameList()
    })
    setTimeout(() => {
      if (theme.value.showProgressBar) VabProgress.done()
    }, 200)
  })

  onUnmounted(() => {
    $unsub('get-code')
    $unsub('reload-router-view')
  })
</script>

<template>
  <router-view v-slot="{ Component }">
    <transition
      mode="out-in"
      :name="theme.showPageTransition ? 'fade-transform' : 'no-transform'"
    >
      <keep-alive :include="keepAliveNameList" :max="keepAliveMaxNum">
        <component :is="Component" :key="routerKey" ref="componentRef" />
      </keep-alive>
    </transition>
  </router-view>
</template>
