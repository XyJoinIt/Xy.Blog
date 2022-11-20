<!--浮动布局 -->
<script lang="ts" setup>
  import { useSettingsStore } from '@/store/modules/settings'

  defineProps({
    fixedHeader: {
      type: Boolean,
      default() {
        return true
      },
    },
    showTabs: {
      type: Boolean,
      default() {
        return true
      },
    },
  })

  const settingsStore = useSettingsStore()
  const { foldSideBar, openSideBar } = settingsStore

  foldSideBar()
  onUnmounted(() => {
    openSideBar()
  })
</script>

<template>
  <div
    class="vab-layout-float"
    :class="{
      fixed: fixedHeader,
      'no-tabs-bar': !showTabs,
    }"
  >
    <vab-side-bar layout="float" />
    <div class="vab-main">
      <div
        class="vab-layout-header"
        :class="{
          'fixed-header': fixedHeader,
        }"
      >
        <vab-nav layout="float" />
        <vab-tabs v-show="showTabs" />
      </div>
      <vab-app-main />
    </div>
  </div>
</template>

<!--由于element-plus
bug使用popper-append-to-body=false会导致多级路由无法显示，故所有菜单必须生成至body下，样式必须放到body下-->
<style lang="scss" scoped>
  .vab-layout-float {
    :deep() {
      .vab-main {
        margin-left: $base-left-menu-width-min !important;

        .fixed-header {
          width: $base-right-content-width-min !important;
        }
      }
    }

    :deep() {
      .el-menu--collapse.el-menu li.el-sub-menu.is-active {
        .el-sub-menu__title {
          background-color: transparent !important;
        }

        > .el-sub-menu__title {
          background-color: var(--el-color-primary) !important;
        }
      }

      .vab-menu-children-height {
        height: auto !important;
      }

      .el-menu {
        &--vertical {
          .el-menu--popup-right-start {
            width: 335px !important;

            .el-sub-menu__title,
            .el-menu-item {
              float: left;
              width: 160px;
              min-width: 160px;
              margin: 0 0 5px 5px;
              border-radius: $base-border-radius;
            }
          }
        }
      }
    }
  }
</style>
