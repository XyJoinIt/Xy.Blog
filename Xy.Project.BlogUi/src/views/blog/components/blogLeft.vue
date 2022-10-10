<template>
  <div class="right_width">
    <a-affix :offset-top="top">
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
          <a-tab-pane key="3" tab="随机">Content of Tab Pane 3</a-tab-pane>
        </a-tabs>
      </div>

      <!-- <div class="widget">
              <a-tabs v-model:activeKey="activeKey2">
                <a-tab-pane key="1" tab="最新评论">
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
                    <tag-two-tone style="font-size: 18px; margin-right: 10px" />
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
</template>
<script lang="ts">
  import { toRefs, reactive, defineComponent, onMounted, ref } from "vue";
  import { TagTwoTone } from "@ant-design/icons-vue";
  interface DataItem {
    title: string;
    description: string;
  }
  // 定义接口来定义对象的类型
  interface StateData {
    value: string;
    onSearch: string;
  }
  export default defineComponent({
    name: "mine",
    components: { TagTwoTone },
    props: {
      item: {
        type: Object,
      },
    },
    setup(props) {
      const state = reactive<StateData>({
        value: "",
        onSearch: "",
      });
      //第一行
      const activeKey1 = ref("1");
      //第一行
      const activeKey2 = ref("1");
      //第一行
      const activeKey3 = ref("1");

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
        activeKey1,
        activeKey2,
        activeKey3,
        data,
        classificationData,
        data2,
        top,
      };
    },
  });
</script>
<style>
  .right_width {
    width: 80%;
  }
</style>
