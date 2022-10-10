<template>
  <div>
    <div class="container">
      <Nav v-if="$route.meta.ShowNavMenu" />
      <router-view />
      <Footer />
    </div>
  </div>
</template>
<script lang="ts">
  import {
    toRefs,
    reactive,
    defineComponent,
    defineAsyncComponent,
    onMounted,
    ref,
  } from "vue";
  import { useRoute } from "vue-router";
  export default defineComponent({
    name: "App",
    components: {
      Footer: defineAsyncComponent(() => import("@/components/Footer.vue")),
      Nav: defineAsyncComponent(() => import("@/components/Nav.vue")),
    },
    setup() {
      const state = reactive({ isShowNav: false });
      const route = useRoute();
      // 页面加载时
      onMounted(() => {});
      return {
        ...toRefs(state),
      };
    },
  });
</script>
<style lang="scss">
  #app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    background-color: #f1f1f1;
  }
  .float-right {
    float: right;
  }
  .float-left {
    float: left;
  }

  .clen {
    clear: both;
  }
</style>
