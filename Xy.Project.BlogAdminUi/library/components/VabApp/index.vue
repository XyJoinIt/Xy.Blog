<script lang="ts" setup>
  import zhLocale from 'element-plus/lib/locale/lang/zh-cn'
</script>
<template>
  <el-config-provider
    :button="{
      autoInsertSpace: true,
    }"
    :locale="zhLocale"
  >
    <router-view v-slot="{ Component }">
      <component :is="Component" />
    </router-view>
  </el-config-provider>
</template>
