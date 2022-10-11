<template>
  <div class="k-header">
    <nav class="k-nav navbar navbar-expand-lg navbar-light fixed-top">
      <div class="content clen">
        <a-row>
          <a-col :span="14">
            <div class="flot_left navbar-brand">
              <a class="" href="/">
                <h1>XY-BLOG</h1>
              </a>
            </div>
          </a-col>
          <a-col :span="10">
            <div
              id="navbarResponsive"
              class="collapse navbar-collapse flot_left"
            >
              <ul id="menu-nav" class="navbar-nav ml-auto clen">
                <li class="nav-item flot_left">
                  <router-link to="/">首页</router-link>
                </li>
                <li class="nav-item flot_left">
                  <router-link to="/blog">博客</router-link>
                </li>
                <li class="nav-item flot_left">
                  <router-link to="/blog">留言板</router-link>
                </li>
                <!-- <li class="nav-item flot_left">
                  <router-link to="/blog">生活小调料</router-link>
                </li> -->
                <li class="nav-item flot_left">
                  <router-link to="/placefile">归档</router-link>
                </li>
                <li class="nav-item flot_left">
                  <router-link to="/mine">关于我</router-link>
                </li>
              </ul>
            </div>
          </a-col>
        </a-row>
      </div>
    </nav>
    <div class="banner">
      <div class="introduce animate__animated animate__rubberBand">
        <div class="title">Xy</div>
        <div class="mate">纸上得来终觉浅，绝知此事要躬行</div>
      </div>
    </div>
  </div>
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
<style lang="scss">
  #menu-nav {
    list-style: none;

    li {
      height: 5rem;
      line-height: 5rem;
      width: 9rem;
      text-align: center;

      a {
        color: #fff;
        font-size: 1.8rem;
      }
    }
  }
  .k-header {
    height: 30rem;
  }
  .navbar {
    width: 100%;
    position: absolute;
  }
  .content {
    height: 5rem;
    line-height: 5rem;

    .navbar-brand {
      margin-left: 10rem;
      width: 100%;

      h1 {
        font-size: 24px;
        color: #fff;
      }
    }
  }

  .banner {
    background-image: url("@/assets/img/background.jpg");
    background-repeat: no-repeat;
    height: 100%;
    width: 100%;
    overflow: hidden;
    background-size: cover;
    .introduce {
      position: relative;
      top: 40%;
      text-align: center;

      .title {
        font-size: 4rem;
        color: #fff;
        text-shadow: 2px 2px 2px #666;
      }
      .mate {
        color: #fff;
        font-size: 2rem;
        text-shadow: 2px 2px 2px #666;
      }
    }
  }
  .flot_left {
    float: left;
  }
  .clen {
    clear: both;
    //overflow: hidden;
  }
</style>
