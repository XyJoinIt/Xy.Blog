<template>
  <div class="home">
    <div class="section" id="section1">
      <div class="fp-tablecell">
        <div class="page1">
          <div class="nav wow zoomIn animate__animated animate__rubberBand">
            <h1 style="color: white">Xy</h1>
            <p class="">一叶浮萍归大海，人生何处不相逢</p>
            <a-button type="primary">
              <RouterLink to="/blog">Enter Blog</RouterLink>
            </a-button>
          </div>
          <CaretDownOutlined
            class="next animate__animated animate__rubberBand"
            data-wow-duration="2s"
          />
        </div>
      </div>
    </div>
    <!-- 热门文章 -->
    <Section msg="很想给你写封信,告诉你这里的天气" title="热门文章" />
    <WildCard :entity="obj" v-for="obj in obgs" />
    <!-- 生活小调味 -->
    <Section msg="一蓑烟雨任平生也无风雨也无晴。" title="生活小调味" />
    <!-- <a-card style="width: 75%; text-align: center; margin: auto">
      <div class="section section-80">
        <div class="container">
          <div class="">
            <div class="heading">
              <h6>Trending Post</h6>
            </div>
            <div
              data-slides='{"slidesToScroll":"1","slidesToShow":"4","dots":"false","arrows":"true"}'
              data-slides-md='{"slidesToShow": "2"}'
              class="blog-slick"
            >
              <div class="blog-item hover-dark">
                <a href="news-detail.html" class="img-wrap">
                  <img src="@/assets/img/blog4.jpg" alt="Alay" />
                  <h5 class="title">Fall is Comming to Our Big Village</h5>
                </a>
              </div>
              <div class="blog-item hover-dark">
                <a href="news-detail.html" class="img-wrap">
                  <img src="@/assets/img/blog4.jpg" alt="Alay" />
                  <h5 class="title">Fall is Comming to Our Big Village</h5>
                </a>
              </div>
              <div class="blog-item hover-dark">
                <a href="news-detail.html" class="img-wrap">
                  <img src="@/assets/img/blog4.jpg" alt="Alay" />
                  <h5 class="title">Fall is Comming to Our Big Village</h5>
                </a>
              </div>
              <div class="blog-item hover-dark">
                <a href="news-detail.html" class="img-wrap">
                  <img src="@/assets/img/blog4.jpg" alt="Alay" />
                  <h5 class="title">Fall is Comming to Our Big Village</h5>
                </a>
              </div>
              <div class="blog-item hover-dark">
                <a href="news-detail.html" class="img-wrap">
                  <img src="@/assets/img/blog4.jpg" alt="Alay" />
                  <h5 class="title">Fall is Comming to Our Big Village</h5>
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </a-card> -->

    <Section msg="" title="最近留言" />
  </div>
</template>

<script lang="ts">
  import { CaretDownOutlined } from "@ant-design/icons-vue";
  import { toRefs, reactive, defineComponent, onMounted, ref } from "vue";
  import Section from "@/components/section.vue";
  import WildCard from "@/components/WildCard.vue";
  export default defineComponent({
    name: "home",
    components: {
      CaretDownOutlined,
      Section,
      WildCard,
    },
    setup() {
      const state = reactive({
        editRef: null,
        tabsActiveName: "小云邦邦给你两圈",
        isScan: false,
      });
      const obgs = [
        {
          url: "src/assets/img/blog1.jpg",
          title: "做个自己的APP吧，自己当自己的产品",
          Content:
            "在朋友的建议下，我决定做一个更有意义的事情，将《段子乐》项目接口和数据进行对外开放，让爱折腾的朋友可以用这些接口做一个自己的应用，当然包括但不仅限于开发一个 Android App，iOS App，小程序，H5应用，Flutter应用等等。",
          CreateTime: "2022年9月17日17:28:19",
          Wordage: 12222,
        },
        {
          url: "src/assets/img/blog1.jpg",
          title:
            "【需求解决系列之三】Android 自定义可展开收回的ExpandableTextView",
          Content:
            "最近慢慢习惯了新环境，也渐渐的变得忙碌起来。之前暴雷的事情有同学还是比较关注，我想说的是，已经一而再再而三的展期了，老赖加上老赖平台，结果是相当明确的，不说了，说多了都是泪。",
          CreateTime: "2022年9月17日17:28:19",
          Wordage: 32322,
        },
        {
          url: "src/assets/img/blog1.jpg",
          title: "需求解决系列之-【系列工具概览】",
          Content:
            "系列开发 在工作之余，打算将一些常用的逻辑页面，模块，功能点做成library库，这样当有相似需求的时候，可以做到插拔式开发！现在系列中有以下内容，后续会持续迭代： 列表 开源免费API-RollToolsApi 一个提供开发中常用数据的一个稳定聚合Api接口源，运行于独立服务器，免费，且长期维",
          CreateTime: "2022年9月17日17:28:19",
          Wordage: 32322,
        },
      ];
      // 页面加载时
      onMounted(() => {});
      return {
        ...toRefs(state),
        obgs,
      };
    },
  });
</script>
<style lang="scss">
  @import "@/assets/css/home.css";
</style>
