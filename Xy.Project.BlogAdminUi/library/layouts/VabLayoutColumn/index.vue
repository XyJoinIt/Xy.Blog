<!--分栏布局 -->
<script lang="ts" setup>
  import { useSettingsStore } from '@/store/modules/settings'

  defineProps({
    collapse: {
      type: Boolean,
      default() {
        return false
      },
    },
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
  const { theme } = storeToRefs(settingsStore)
</script>

<template>
  <div
    class="vab-layout-column"
    :class="{
      fixed: fixedHeader,
      'no-tabs-bar': !showTabs,
    }"
  >
    <vab-column-bar />
    <div
      class="vab-main"
      :class="{
        ['vab-main-' + theme.columnStyle]: true,
        'is-collapse-main': collapse,
      }"
    >
      <div
        class="vab-layout-header"
        :class="{
          'fixed-header': fixedHeader,
        }"
      >
        <vab-nav />
        <vab-tabs v-show="showTabs" />
      </div>
      <vab-app-main />
    </div>
  </div>
</template>

<style lang="scss" scoped>
  .vab-layout-column {
    .vab-main {
      &.is-collapse-main {
        &.vab-main-horizontal {
          margin-left: $base-left-menu-width-min * 1.3;

          :deep() {
            .fixed-header {
              width: calc(100% - #{$base-left-menu-width-min} * 1.3);
            }
          }
        }
      }
    }
  }
</style>
