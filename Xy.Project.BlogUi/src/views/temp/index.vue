<template>
  <div class="home"></div>
</template>

<script lang="ts">
  import { toRefs, reactive, computed, defineComponent, onMounted } from "vue";
  // 定义接口来定义对象的类型
  interface StateData {
    tabsActiveName: string;
    isScan: boolean;
  }

  export default defineComponent({
    name: "temp",
    components: {},
    setup() {
      const state = reactive<StateData>({
        tabsActiveName: "小云邦邦给你两圈",
        isScan: false,
      });

      // 页面加载时
      onMounted(() => {
        console.log(1);
      });
      return {
        ...toRefs(state),
      };
    },
  });
</script>
<style></style>
