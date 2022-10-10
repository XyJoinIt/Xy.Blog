<template>
  <div class="article-panel">
    <div class="a-thumb">
      <a href="#">
        <img src="@/assets/2.jpg" />
      </a>
    </div>
    <div class="a-post 1">
      <div class="header">
        <a class="label" href="#">
          api相关
          <i class="label-arrow"></i>
        </a>
        <h3 class="title">
          <RouterLink to="/bloginfo">
            {{ entity.title }}
          </RouterLink>
        </h3>
      </div>
      <div class="content_text">
        <p>
          {{ entity.Content }}
        </p>
      </div>
    </div>
    <div class="a-meta">
      <span class="float-left d-block">
        <span class="mr-2">
          <CalendarOutlined></CalendarOutlined>
          {{ entity.CreateTime }}
        </span>
        <span class="mr-2">
          <CommentOutlined></CommentOutlined>
          {{ entity.PraiseNum }}条评论
        </span>
        <span class="mr-2">
          <EyeOutlined></EyeOutlined>
          {{ entity.HowNum }}点热度
        </span>
        <span class="mr-2">
          <LikeOutlined></LikeOutlined>
          {{ entity.CommentNum }}人点赞
        </span>
        <span class="mr-2">
          <UserOutlined></UserOutlined>
          {{ entity.CreateUserName }}
        </span>
      </span>
      <span class="float-right link">
        <RouterLink to="/bloginfo">
          阅读全文
          <CaretRightOutlined></CaretRightOutlined>
        </RouterLink>
      </span>
    </div>
  </div>
</template>
<script lang="ts">
  // 定义接口来定义对象的类型
  interface StateData {
    url: string;
    title: string;
    Content: string;
    CreateTime: string;
    Wordage: number;
    CreateUserName: string;
    PraiseNum: number;
    HowNum: number;
    CommentNum: number;
  }
  import { toRefs, reactive, PropType, defineComponent, onMounted } from "vue";
  import {
    CalendarOutlined,
    CommentOutlined,
    LikeOutlined,
    UserOutlined,
    EyeOutlined,
    CaretRightOutlined,
  } from "@ant-design/icons-vue";
  export default defineComponent({
    name: "mine",
    components: {
      CalendarOutlined,
      CommentOutlined,
      LikeOutlined,
      UserOutlined,
      EyeOutlined,
      CaretRightOutlined,
    },
    props: {
      entity: {
        type: Object as PropType<StateData>,
        required: true,
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
  .article-panel {
    position: relative;
    margin: 0 0 23px;
    border-radius: 0;
    background-color: #fff;
    box-shadow: 0 1px 2px rgb(0 0 0 / 10%);
    margin: 0px 0px 0px 15%;
    width: 80%;
    margin-bottom: 20px;
    .a-thumb {
      position: relative;
      float: left;
      overflow: hidden;
      margin: 20px;
      width: 256px;
      height: 144px;

      img {
        width: 100%;
        height: 100%;
      }
    }
    .a-post {
      margin-left: 255px;
      padding: 21px 20px 0 3px;
      height: 160px;

      .header {
        display: -webkit-box;
        overflow: hidden;
        // margin: 3px 0 6px;
        // max-height: 25px;
        text-overflow: ellipsis;
        -webkit-box-orient: vertical;
        -webkit-line-clamp: 1;

        .label {
          position: relative;
          position: relative;
          top: -2px;
          display: inline-block;
          margin-right: 5px;
          padding: 4px 6px 3px;
          border-radius: 0;
          background-color: #00a2ff;
          color: #fff;
          vertical-align: baseline;
          text-align: center;
          white-space: nowrap;
          font-size: 12px;
          line-height: 14px;
        }

        .title {
          display: inline;
          margin: 0;
          font-size: 21px;
          a {
            color: #333;
          }
        }
      }

      .content_text {
        display: block;
        display: -webkit-box;
        overflow: hidden;
        max-height: 110px;
        text-overflow: ellipsis;
        word-wrap: break-word;
        cursor: default;
        -webkit-box-orient: vertical;
        -webkit-line-clamp: 4;

        p {
          margin-bottom: 0;
          font-size: 15px;
        }
      }
    }

    .a-meta {
      clear: both;
      overflow: hidden;
      padding: 8px 20px;
      border-top: 1px solid #f3f3f3;
      font-size: 12px;
      line-height: 27px;

      span {
        font-size: 13px;
        line-height: 24px;
        cursor: default;

        .mr-2 {
          margin-right: 10px;
        }
      }

      .link a {
        color: #000;
      }
      .link a:hover {
        color: #40a9ff;
      }
    }
  }
</style>
