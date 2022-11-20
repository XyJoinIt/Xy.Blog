<script lang="ts" setup>
  defineProps({
    itemOrMenu: {
      type: Object,
      default() {
        return null
      },
    },
  })
</script>

<template>
  <el-sub-menu :index="itemOrMenu.path" popper-append-to-body>
    <template #title>
      <vab-icon
        v-if="itemOrMenu.meta.icon"
        :icon="itemOrMenu.meta.icon"
        :is-custom-svg="itemOrMenu.meta.isCustomSvg"
        :title="itemOrMenu.meta.title"
      />
      <span :title="itemOrMenu.meta.title">
        {{ itemOrMenu.meta.title }}
      </span>
    </template>
    <slot />
  </el-sub-menu>
</template>
