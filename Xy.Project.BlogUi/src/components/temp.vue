<template>
  <div class=""></div>
</template>
<script lang="ts">
  import { toRefs, reactive, computed, defineComponent, onMounted } from "vue";

  export default defineComponent({
    name: "mine",
    components: {},
    props: {
      item: {
        type: Object,
      },
    },
    setup(props) {
      const state = reactive({});
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
