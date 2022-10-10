<template>
  <div class="bl_content">
    <a-row>
      <a-col :span="16">
        <BlogCart :entity="obj" v-for="obj in ContstList" />
        <!-- 分页 -->
        <div class="pagination_botton">
          <a-config-provider :locale="locale">
            <a-pagination
              v-model:current="PageIndex"
              :total="52"
              :defaultPageSize="10"
              show-less-items
            />
          </a-config-provider>
        </div>
      </a-col>
      <a-col :span="8">
        <div class="right_width">
          <a-affix :offset-top="0">
            <div class="widget w-search">
              <a-input-search
                v-model:value="value"
                size="large"
                placeholder="想知道点什么呢？"
                enter-button
                @search="onSearch"
              />
            </div>
            <div class="widget">
              <a-tabs v-model:activeKey="activeKey1">
                <a-tab-pane key="1" tab="最新">
                  <a-list :data-source="data">
                    <template #renderItem="{ item }">
                      <a-list-item>
                        <a href="">{{ item }}</a>
                      </a-list-item>
                    </template>
                  </a-list>
                </a-tab-pane>
                <a-tab-pane key="2" tab="最多点赞" force-render>
                  Content of Tab Pane 2
                </a-tab-pane>
                <a-tab-pane key="3" tab="随机">
                  Content of Tab Pane 3
                </a-tab-pane>
              </a-tabs>
            </div>

            <!-- <div class="widget">
              <a-tabs v-model:activeKey="activeKey2">
                <a-tab-pane key="1" tab="最新留言">
                  <a-list item-layout="horizontal" :data-source="data2">
                    <template #renderItem="{ item }">
                      <a-list-item>
                        <a-list-item-meta :description="item.description">
                          <template #title>
                            <a href="#">{{ item.title }}</a>
                          </template>
                          <template #avatar>
                            <a-avatar
                              src="https://joeschmoe.io/api/v1/random"
                            />
                          </template>
                        </a-list-item-meta>
                      </a-list-item>
                    </template>
                  </a-list>
                </a-tab-pane>
              </a-tabs>
            </div> -->

            <div class="widget">
              <a-tabs v-model:activeKey="activeKey3">
                <a-tab-pane key="1" tab="标签">
                  <a-tag clas="tag_button" color="pink">Java</a-tag>
                  <a-tag clas="tag_button" color="red">.Net</a-tag>
                  <a-tag clas="tag_button" color="orange">分布式</a-tag>
                  <a-tag clas="tag_button" color="green">消息队列</a-tag>
                  <a-tag clas="tag_button" color="cyan">npm</a-tag>
                  <a-tag clas="tag_button" color="purple">工作记录</a-tag>
                  <a-tag clas="tag_button" color="pink">Java</a-tag>
                  <a-tag clas="tag_button" color="green">消息队列</a-tag>
                  <a-tag clas="tag_button" color="cyan">npm</a-tag>
                  <a-tag clas="tag_button" color="blue">多线程</a-tag>
                  <a-tag clas="tag_button" color="red">.Net</a-tag>
                  <a-tag clas="tag_button" color="orange">分布式</a-tag>
                  <a-tag clas="tag_button" color="green">消息队列</a-tag>
                  <a-tag clas="tag_button" color="cyan">npm</a-tag>
                  <a-tag clas="tag_button" color="blue">多线程</a-tag>
                  <a-tag clas="tag_button" color="blue">多线程</a-tag>
                  <a-tag clas="tag_button" color="purple">工作记录</a-tag>
                  <a-tag clas="tag_button" color="pink">Java</a-tag>
                  <a-tag clas="tag_button" color="red">.Net</a-tag>
                  <a-tag clas="tag_button" color="orange">分布式</a-tag>
                </a-tab-pane>
                <a-tab-pane key="2" tab="文章分类">
                  <a-list :data-source="classificationData">
                    <template #renderItem="{ item }">
                      <a-list-item>
                        <a href="" style="color: #817a7a">
                          <tag-two-tone
                            style="font-size: 18px; margin-right: 10px"
                          />
                          {{ item }}
                        </a>
                      </a-list-item>
                    </template>
                  </a-list>
                </a-tab-pane>
              </a-tabs>
            </div>
          </a-affix>
        </div>
      </a-col>
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
  import {
    BookOutlined,
    UpCircleTwoTone,
    TagTwoTone,
  } from "@ant-design/icons-vue";
  import BlogCart from "@/components/BlogCart.vue";
  import zhCN from "ant-design-vue/es/locale/zh_CN";
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
      BlogCart,
      BookOutlined,
      UpCircleTwoTone,
      TagTwoTone,
    },
    setup() {
      const state = reactive<StateData>({
        value: "",
        onSearch: "",
      });
      const ContstList = [
        {
          url: "/assets/2.jpg",
          title: "使用NPS搭建内网穿透服务，限时开放1",
          Content:
            "前言 先说下背景，大家通常使用内网穿透，一般都是用在那种开发公众号的时候，联调的时候需要在公众号配置公网可以访问的请求地址，所以需要内网穿透到本机的某个端口，方便联调。但是我这次使用内网穿透，是为了做一个骚操作。 我们呢每天完成开发任务之后，提交代码是需要提Merger dshafkdhasfhkasfhkashfkashfkhsdkafh",
          CreateTime: "2022年9月21日10:33:48",
          Wordage: 15444,
          CreateUserName: "小云昂",
          PraiseNum: 541,
          HowNum: 2594,
          CommentNum: 1544,
        },
        {
          url: "/assets/2.jpg",
          title: "使用NPS搭建内网穿透服务，限时开放2",
          Content:
            "前言 先说下背景，大家通常使用内网穿透，一般都是用在那种开发公众号的时候，联调的时候需要在公众号配置公网可以访问的请求地址，所以需要内网穿透到本机的某个端口，方便联调。但是我这次使用内网穿透，是为了做一个骚操作。 我们呢每天完成开发任务之后，提交代码是需要提Merger dshafkdhasfhkasfhkashfkashfkhsdkafh",
          CreateTime: "2022年9月21日10:33:48",
          Wordage: 15444,
          CreateUserName: "小云昂",
          PraiseNum: 541,
          HowNum: 2594,
          CommentNum: 1544,
        },
        {
          url: "/assets/2.jpg",
          title: "使用NPS搭建内网穿透服务，限时开放3",
          Content:
            "前言 先说下背景，大家通常使用内网穿透，一般都是用在那种开发公众号的时候，联调的时候需要在公众号配置公网可以访问的请求地址，所以需要内网穿透到本机的某个端口，方便联调。但是我这次使用内网穿透，是为了做一个骚操作。 我们呢每天完成开发任务之后，提交代码是需要提Merger dshafkdhasfhkasfhkashfkashfkhsdkafh",
          CreateTime: "2022年9月21日10:33:48",
          Wordage: 15444,
          CreateUserName: "小云昂",
          PraiseNum: 541,
          HowNum: 2594,
          CommentNum: 1544,
        },
        {
          url: "/assets/2.jpg",
          title: "使用NPS搭建内网穿透服务，限时开放3",
          Content:
            "前言 先说下背景，大家通常使用内网穿透，一般都是用在那种开发公众号的时候，联调的时候需要在公众号配置公网可以访问的请求地址，所以需要内网穿透到本机的某个端口，方便联调。但是我这次使用内网穿透，是为了做一个骚操作。 我们呢每天完成开发任务之后，提交代码是需要提Merger dshafkdhasfhkasfhkashfkashfkhsdkafh",
          CreateTime: "2022年9月21日10:33:48",
          Wordage: 15444,
          CreateUserName: "小云昂",
          PraiseNum: 541,
          HowNum: 2594,
          CommentNum: 1544,
        },
        {
          url: "/assets/2.jpg",
          title: "使用NPS搭建内网穿透服务，限时开放3",
          Content:
            "前言 先说下背景，大家通常使用内网穿透，一般都是用在那种开发公众号的时候，联调的时候需要在公众号配置公网可以访问的请求地址，所以需要内网穿透到本机的某个端口，方便联调。但是我这次使用内网穿透，是为了做一个骚操作。 我们呢每天完成开发任务之后，提交代码是需要提Merger dshafkdhasfhkasfhkashfkashfkhsdkafh",
          CreateTime: "2022年9月21日10:33:48",
          Wordage: 15444,
          CreateUserName: "小云昂",
          PraiseNum: 541,
          HowNum: 2594,
          CommentNum: 1544,
        },
        {
          url: "/assets/2.jpg",
          title: "使用NPS搭建内网穿透服务，限时开放3",
          Content:
            "前言 先说下背景，大家通常使用内网穿透，一般都是用在那种开发公众号的时候，联调的时候需要在公众号配置公网可以访问的请求地址，所以需要内网穿透到本机的某个端口，方便联调。但是我这次使用内网穿透，是为了做一个骚操作。 我们呢每天完成开发任务之后，提交代码是需要提Merger dshafkdhasfhkasfhkashfkashfkhsdkafh",
          CreateTime: "2022年9月21日10:33:48",
          Wordage: 15444,
          CreateUserName: "小云昂",
          PraiseNum: 541,
          HowNum: 2594,
          CommentNum: 1544,
        },
        {
          url: "/assets/2.jpg",
          title: "使用NPS搭建内网穿透服务，限时开放3",
          Content:
            "前言 先说下背景，大家通常使用内网穿透，一般都是用在那种开发公众号的时候，联调的时候需要在公众号配置公网可以访问的请求地址，所以需要内网穿透到本机的某个端口，方便联调。但是我这次使用内网穿透，是为了做一个骚操作。 我们呢每天完成开发任务之后，提交代码是需要提Merger dshafkdhasfhkasfhkashfkashfkhsdkafh",
          CreateTime: "2022年9月21日10:33:48",
          Wordage: 15444,
          CreateUserName: "小云昂",
          PraiseNum: 541,
          HowNum: 2594,
          CommentNum: 1544,
        },
      ];

      //第一行
      const activeKey1 = ref("1");
      //第一行
      const activeKey2 = ref("1");
      //第一行
      const activeKey3 = ref("1");
      //页码
      const PageIndex = ref(1);

      const data: string[] = [
        "使用NPS搭建内网穿透服务，限时开放1",
        "使用NPS搭建内网穿透服务，限时开放2",
        "使用NPS搭建内网穿透服务，限时开放3",
      ];

      const data2: DataItem[] = [
        {
          title: "张三",
          description: "good good vary good",
        },
        {
          title: "李四",
          description: "good good vary good",
        },
        {
          title: "王五",
          description: "good good vary good",
        },
      ];
      const top = ref<number>(10);
      const classificationData = [
        "Java学习笔记(5)",
        ".NetCore学习笔记(12)",
        "EntityFromwork学习笔记(13)",
        "常见Bug记录(1)",
        "其他资料(3)",
      ];
      // 页面加载时
      onMounted(() => {
        console.log(1);
      });
      return {
        ...toRefs(state),
        ContstList,
        activeKey1,
        activeKey2,
        activeKey3,
        PageIndex,
        data,
        data2,
        locale: zhCN,
        classificationData,
        top,
      };
    },
  });
</script>
<style lang="scss">
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
</style>
