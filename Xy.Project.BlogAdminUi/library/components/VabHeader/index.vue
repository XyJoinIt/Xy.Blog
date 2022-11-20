<script lang="ts" setup>
  import { useRoutesStore } from '@/store/modules/routes'
  import variables from '@vab/styles/variables/variables.module.scss'

  defineProps({
    layout: {
      type: String,
      default: 'horizontal',
    },
  })

  const routesStore = useRoutesStore()
  const { getActiveMenu: activeMenu, getRoutes: routes } =
    storeToRefs(routesStore)
</script>

<template>
  <div class="vab-header">
    <div class="vab-main">
      <el-row :gutter="20">
        <el-col :span="6">
          <vab-logo />
        </el-col>
        <el-col :span="18">
          <div class="right-panel">
            <el-menu
              v-if="'horizontal' === layout"
              :active-text-color="variables['menu-color-active']"
              :background-color="variables['menu-background']"
              :default-active="activeMenu.data"
              menu-trigger="hover"
              mode="horizontal"
              popper-append-to-body
              style="width: 100%"
              :text-color="variables['menu-color']"
            >
              <template
                v-for="(item, index) in routes.flatMap((route) =>
                  route['meta'] &&
                  route['meta']['levelHidden'] &&
                  route['children']
                    ? [...route['children']]
                    : route
                )"
              >
                <vab-menu
                  v-if="item['meta'] && !item['meta']['hidden']"
                  :key="index + item['name']"
                  :item="item"
                  :layout="layout"
                />
              </template>
            </el-menu>
            <vab-error-log />
            <vab-full-screen />
            <vab-refresh />
            <vab-avatar />
          </div>
        </el-col>
      </el-row>
    </div>
  </div>
</template>

<style lang="scss" scoped>
  $base-menu-height: 40px;
  .vab-header {
    display: flex;
    align-items: center;
    justify-items: flex-end;
    height: $base-header-height;
    background: $base-menu-background;

    .vab-main {
      padding: 0 $base-padding 0 $base-padding;

      .right-panel {
        display: flex;
        align-items: center;
        justify-content: flex-end;
        height: $base-header-height;

        :deep() {
          .el-sub-menu__icon-more {
            margin-top: #{math.div($base-menu-height - 20, 2)} !important;
            margin-right: 20px !important;
          }

          > .el-menu--horizontal.el-menu {
            > .el-sub-menu > .el-sub-menu__title {
              padding-right: 0;

              > .el-sub-menu__icon-arrow {
                position: relative !important;
                //margin-top: #{math.div($base-header-height - 11, 2)} !important;
                margin-top: -5px !important;
                margin-right: 0;
                margin-left: 30px;
              }
            }

            > .el-menu-item {
              .el-tag {
                position: relative !important;
                margin-top: 0 !important;
                margin-right: -20px;
                margin-left: 25px;
              }

              .vab-dot {
                float: right;
                margin-top: #{math.div($base-header-height - 6, 2)} + 1;
              }

              @media only screen and (max-width: 1199px) {
                .el-tag {
                  display: none;
                }
              }
            }
          }

          .el-menu {
            border: 0 !important;
            * {
              border: 0 !important;
            }
            &.el-menu--horizontal {
              display: flex;
              align-items: center;
              justify-content: flex-end;
              width: 100%;
              height: $base-menu-height;
              border: 0 !important;

              > .el-menu-item,
              > .el-sub-menu {
                height: $base-menu-height;
                margin-right: 3px;
                line-height: $base-menu-height;
                border-radius: 3px;

                .el-sub-menu__icon-arrow {
                  float: right;
                  margin-top: 7px;
                }

                > .el-sub-menu__title {
                  display: flex;
                  align-items: flex-start;
                  height: $base-menu-height;
                  line-height: $base-menu-height;
                  border: 0 !important;
                  border-radius: 3px;
                }
              }
            }

            [class*='ri-'] {
              margin-left: 0;
              color: var(--el-color-white);
              cursor: pointer;
            }

            .el-sub-menu,
            .el-menu-item {
              i {
                color: inherit;
              }

              &.is-active {
                border: 0 !important;

                .el-sub-menu__title {
                  border: 0 !important;
                }
              }
            }

            .el-menu-item {
              &.is-active {
                background: var(--el-color-primary) !important;
              }
            }
          }

          .user-name {
            color: var(--el-color-white);
          }

          .user-name + i {
            color: var(--el-color-white);
          }

          [class*='ri-'] {
            margin-left: $base-margin;
            color: var(--el-color-white);
            cursor: pointer;
          }

          button {
            svg {
              margin-right: 0;
              color: var(--el-color-white);
              cursor: pointer;
              fill: var(--el-color-white);
            }
          }
        }
      }
    }
  }
</style>

<!--由于element-plus
bug使用popper-append-to-body=false会导致多级路由无法显示，故所有菜单必须生成至body下，样式必须放到body下-->
<style lang="scss">
  @mixin menuActiveHover {
    &:hover,
    &.is-active {
      i {
        color: var(--el-color-white) !important;
      }

      color: var(--el-color-white) !important;
      background: var(--el-color-primary) !important;

      .el-sub-menu__title {
        i {
          color: var(--el-color-white) !important;
        }

        color: var(--el-color-white) !important;
        background: var(--el-color-primary) !important;
      }
    }
  }

  .el-popper {
    .el-menu--horizontal {
      height: #{math.div($base-header-height, 1.4)};
      border-bottom: 0 solid transparent !important;

      @media only screen and (max-width: 1199px) {
        .el-tag {
          display: none;
        }
      }

      .el-tag {
        position: absolute;
        right: 20px;
        margin-top: 0 !important;
      }

      .vab-dot {
        position: absolute;
        right: 20px;
        margin-top: 0 !important;
      }

      .el-menu-item,
      .el-sub-menu {
        height: #{math.div($base-header-height, 1.4)} !important;
        line-height: #{math.div($base-header-height, 1.4)} !important;
        @include menuActiveHover;

        i {
          color: inherit;
        }

        .el-sub-menu__icon-arrow {
          float: right;
        }

        .el-sub-menu__title {
          height: #{math.div($base-header-height, 1.4)} !important;
          line-height: #{math.div($base-header-height, 1.4)} !important;
          @include menuActiveHover;
        }
      }
    }
  }
</style>
