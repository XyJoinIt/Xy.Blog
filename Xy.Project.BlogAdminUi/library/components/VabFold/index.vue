<script lang="ts" setup>
  import { useSettingsStore } from '@/store/modules/settings'

  const settingsStore = useSettingsStore()
  const { collapse } = storeToRefs(settingsStore)
  const { toggleCollapse } = settingsStore
</script>

<template>
  <vab-icon
    class="fold-unfold"
    :icon="collapse ? 'menu-unfold-line' : 'menu-fold-line'"
    @click="toggleCollapse"
  />
</template>

<style lang="scss" scoped>
  .fold-unfold {
    color: var(--el-color-grey);
    cursor: pointer;
  }
</style>
