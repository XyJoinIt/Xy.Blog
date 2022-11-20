<!--常规布局 -->
<script lang="ts" setup>
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
    device: {
      type: String,
      default() {
        return 'desktop'
      },
    },
  })
</script>

<template>
  <div
    class="vab-layout-common"
    :class="{
      fixed: fixedHeader,
      'no-tabs-bar': !showTabs,
    }"
  >
    <div
      class="vab-layout-header"
      :class="{
        'fixed-header': fixedHeader,
      }"
    >
      <vab-header layout="common" />
      <div>
        <vab-side-bar layout="common" />
        <div
          v-show="showTabs"
          class="vab-main"
          :class="{
            'is-collapse-main': collapse,
          }"
        >
          <vab-tabs layout="common" />
        </div>
      </div>
    </div>
    <div
      class="vab-main main-padding"
      :class="{
        'is-collapse-main': collapse,
      }"
    >
      <vab-app-main />
    </div>
  </div>
</template>

<style lang="scss" scoped>
  .vab-layout-common {
    :deep() {
      .vab-tabs-content {
        width: calc(
          100% - 60px - #{$base-font-size-default} - #{$base-padding} - 2px
        ) !important;
      }

      .vab-header {
        .vab-main {
          width: 100%;
          margin: auto $base-margin;
        }
      }
    }
  }
</style>
