<script lang="ts" setup>
  import { useRoutesStore } from '@/store/modules/routes'
  import { handleMatched } from '@/utils/routes'
  import { VabRoute } from '/#/router'

  const route: VabRoute = useRoute()

  const routesStore = useRoutesStore()
  const { getRoutes: routes } = storeToRefs(routesStore)

  const breadcrumbList = computed(() =>
    handleMatched(routes.value, route.path).filter(
      (item: any) => !item.meta.breadcrumbHidden
    )
  )
  const handleTo = (path: string | undefined = '') => {
    return { path }
  }
</script>

<template>
  <el-breadcrumb class="vab-breadcrumb" separator=">">
    <el-breadcrumb-item
      v-for="(item, index) in breadcrumbList"
      :key="index"
      :to="handleTo(item.redirect)"
    >
      <vab-icon
        v-if="item.meta.icon"
        :icon="item.meta.icon"
        :is-custom-svg="item.meta.isCustomSvg"
      />
      <span v-if="item.meta.title">{{ item.meta.title }}</span>
    </el-breadcrumb-item>
  </el-breadcrumb>
</template>

<style lang="scss" scoped>
  .vab-breadcrumb {
    height: $base-nav-height;
    font-size: $base-font-size-default;
    line-height: $base-nav-height;

    :deep() {
      .el-breadcrumb__item {
        .el-breadcrumb__inner {
          font-weight: normal;
          color: #515a6e;
          i,
          svg {
            margin-right: 3px;
          }
        }

        &:last-child {
          .el-breadcrumb__inner {
            a {
              color: #999;
            }
          }
        }
      }
    }
  }
</style>
