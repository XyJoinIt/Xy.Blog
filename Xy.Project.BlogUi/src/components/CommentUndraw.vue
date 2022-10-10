<template>
  <div class=""></div>
</template>
<script lang="ts">
  import { toRefs, reactive, computed, defineComponent, onMounted } from "vue";
  import UndrawUi from "undraw-ui";
  import "undraw-ui/dist/style.css";
  export default defineComponent({
    name: "mine",
    components: { UndrawUi },
    setup(props) {
      const state = reactive({});
      // 页面加载时
      onMounted(() => {});
      return {
        ...toRefs(state),
      };
    },
  });
</script>
<style></style>
