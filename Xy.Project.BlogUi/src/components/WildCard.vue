<template>
  <div class="blog_content clearfix">
    <!-- <a-image class="img" :src="entity.url" /> -->
    <img class="img" src="@/assets/img/blog1.jpg" alt="" />
    <!-- <a-image class="img" src="@/assets/img/blog1.jpg" /> -->
    <div class="blog_info">
      <h3>{{ entity.title }}</h3>
      <p>
        {{ entity.Content }}
      </p>
      <div>
        <a href="javascript:void(false)">默认文集</a>
        <span>{{ entity.CreateTime }}</span>
        <span>{{ entity.Wordage }}字</span>
        <a class="blog_detail" href="#">查看原文</a>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
  import { defineComponent, reactive, PropType, toRefs, computed } from "vue";
  // 定义接口来定义对象的类型
  interface StateData {
    url: string;
    title: string;
    Content: string;
    CreateTime: string;
    Wordage: number;
  }
  //export default class PieChart extends defineComponent <any>{}
  export default defineComponent({
    name: "WildCard",
    props: {
      entity: {
        type: Object as PropType<StateData>,
        required: true,
      },
    },
    setup(props) {},
  });
</script>

<style lang="scss">
  .blog_content {
    padding-top: 30px;
    padding-bottom: 30px;
    padding-left: 20px;
    padding-right: 20px;
    border-bottom: 1px solid #ddd;
    width: 75%;
    margin: auto;
    background-color: #fff;
    .img {
      width: 25%;
      display: inline-block;
      object-fit: cover;
      height: 180px;
      background-size: cover;
      //float: left;
      border-radius: 4px;
    }

    .blog_info {
      padding-left: 15px;
      float: left;
      position: relative;
      width: 75%;

      h3 {
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
        font-size: 22px;
        color: #333;
        padding: 0;
        margin: 0;
      }

      p {
        padding-right: 15px;
        padding-top: 10px;
        font-size: 14px;
        line-height: 24px;
        color: #aaa;
        overflow: hidden;
        text-overflow: ellipsis;
        display: -webkit-box;
        -webkit-line-clamp: 5;
        -webkit-box-orient: vertical;
      }

      div {
        position: absolute;
        top: 160px;
        font-size: 14px;
        color: #777;

        span {
          margin-left: 10px;
        }

        .blog_detail {
          color: #666;
          padding-left: 10px;
          padding-right: 10px;
        }
      }
    }
  }
</style>
