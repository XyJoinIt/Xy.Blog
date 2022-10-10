<template>
  <div class="botton_nav">
    <footer class="roll_footer">
      <p>Copyright © 2012-2026 All Rights Reserved. 粤ICP备123456789号-2</p>
    </footer>
  </div>
</template>
<script lang="ts">
  import { toRefs, reactive, defineComponent, onMounted } from "vue";
  export default defineComponent({
    name: "Footer",
    components: {},
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
<style lang="scss">
  .roll_footer {
    //margin-top: 50px;
    width: 100%;
    background-color: #333333;
    height: 5rem;
    line-height: 5rem;
    p {
      color: rgba(255, 255, 255, 0.7);
      font-size: 13px;
      text-align: center;
    }
  }
</style>
