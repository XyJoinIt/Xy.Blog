<template>
  <div class="bl_content">
    <a-row>
      <a-col :span="16">
        <div class="article-pane">
          <div class="header">
            <h1 class="title">
              {{ htmldata.title }}
            </h1>
            <div class="meta">
              <span>{{ htmldata.creteTime }}</span>
              <span>{{ htmldata.howNum }}人围观</span>
              <span>{{ htmldata.zhanNum }}人点赞</span>
              <span>{{ htmldata.pingLun }}条评论</span>
            </div>
          </div>
          <v-md-preview :text="htmldata.tinymce"></v-md-preview>
          <div class="footer clearfix">
            <div class="tags float-left">
              <span>标签：</span>
              <a-tag color="pink">.Net Core</a-tag>
            </div>
            <div class="tool float-right d-none d-lg-block">
              <span>最后更新：2022年9月27日14:38:21</span>
            </div>
          </div>
        </div>
        <div class="article-pane">
          <Comment></Comment>
        </div>
      </a-col>
      <a-col :span="8"><blogLeft></blogLeft></a-col>
    </a-row>
    <div id="components-back-top-demo-custom">
      <a-back-top>
        <div class="ant-back-top-inner">
          <up-circle-two-tone />
        </div>
      </a-back-top>
    </div>
  </div>
</template>

<script lang="ts">
  import {
    toRefs,
    ref,
    reactive,
    computed,
    defineComponent,
    onMounted,
  } from "vue";
  import { BookOutlined, UpCircleTwoTone } from "@ant-design/icons-vue";
  import Comment from "@/components/Comment.vue";
  import zhCN from "ant-design-vue/es/locale/zh_CN";
  import blogLeft from "./components/blogLeft.vue";
  import dayjs from "dayjs";
  import "dayjs/locale/zh-cn";
  dayjs.locale("zh-cn");
  // 定义接口来定义对象的类型
  interface StateData {
    value: string;
    onSearch: string;
  }
  interface DataItem {
    title: string;
    description: string;
  }
  export default defineComponent({
    name: "blog",
    components: {
      BookOutlined,
      UpCircleTwoTone,
      Comment,
      blogLeft,
    },
    setup() {
      const state = reactive<StateData>({
        value: ``,
        onSearch: "",
      });
      const htmldata = {
        creteTime: "2022年9月27日14:34:19",
        howNum: 4321,
        zhanNum: 2312,
        pingLun: 22,
        title:
          "【需求解决系列之三】Android 自定义可展开收回的ExpandableTextView",
        tinymce: "### 标题",
      };
      // 页面加载时
      onMounted(() => {});
      return {
        ...toRefs(state),
        htmldata,
        locale: zhCN,
      };
    },
  });
</script>
<style lang="scss">
  .article-pane {
    position: relative;
    margin: 0 0 23px;
    border-radius: 0;
    background-color: #fff;
    box-shadow: 0 1px 2px rgb(0 0 0 / 10%);
    margin: 0px 0px 0px 15%;
    width: 80%;
    margin-bottom: 20px;
    padding: 2rem;

    .header {
      padding: 0 20px 16px;
      text-align: center;

      .title {
        padding-bottom: 0;
        border: none;
      }

      .meta {
        color: #5a5a5a;
        font-size: 14px;
        cursor: default;

        span {
          margin: 1rem;
        }
      }
    }

    pre {
      color: #444;
      margin: 15px auto;
      padding: 15px 10px;
      border: 3px dashed #ddd;
      border-left: 3px solid #bbb;
      background: #fff
        url("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABMAAAAmCAIAAACphTeFAAAAJElEQVRIx2N4RS5gGNU5qnNU56hOZJ2fyQWjOkd1juoc1YkMAKDL4lkok3p7AAAAAElFTkSuQmCC")
        repeat;
      white-space: pre-wrap;
      word-wrap: break-word;
      letter-spacing: 1.5px;
      font: 14px/25px "Comic Sans MS", "courier new";
      line-height: 22px;
      background-size: 100% 44px;
    }

    .footer {
      border-top: 1px solid #f2f2f2;
      padding-top: 10px;
      height: 50px;
      line-height: 50px;
    }
  }
  .bl_content {
    background-color: #f1f1f1;
    padding-top: 20px;

    .pagination_botton {
      text-align: center;
      margin: 3rem 0px;
    }
  }

  .widget {
    margin: 0 0 23px;
    padding: 15px 30px;
    border-radius: 0;
    background-color: #fff;
    box-shadow: 0 1px 2px rgb(0 0 0 / 10%);
  }
  .right_width {
    width: 80%;
  }
  .ant-tag {
    margin: 5px;
  }

  #components-back-top-demo-custom .ant-back-top {
    bottom: 100px;
  }
  #components-back-top-demo-custom .ant-back-top-inner {
    height: 40px;
    width: 40px;
    line-height: 40px;
    border-radius: 4px;
    background-color: #1088e9;
    color: #fff;
    text-align: center;
    font-size: 20px;
  }
  .comment-list-wrapper {
    padding: 90px 0 16px;
  }
</style>
