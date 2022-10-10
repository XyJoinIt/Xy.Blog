<template>
  <a-list
    class="comment-list"
    :header="`全部评论`"
    item-layout="horizontal"
    :data-source="data"
  >
    <template #renderItem="{ item }">
      <a-list-item>
        <a-comment :author="item.author" :avatar="item.avatar">
          <template #actions>
            <span>
              <HeartOutlined></HeartOutlined>
              点赞
            </span>
            <span>
              <BellOutlined></BellOutlined>
              举报
            </span>
            <span>回复</span>
          </template>
          <template #content>
            <p>
              {{ item.content }}
            </p>
          </template>
          <a-comment
            v-if="item.children"
            v-for="children in item.children"
            :author="children.author"
            :avatar="children.avatar"
          >
            <template #actions>
              <span>
                <HeartOutlined></HeartOutlined>
                点赞
              </span>
              <span>
                <BellOutlined></BellOutlined>
                举报
              </span>
            </template>
          </a-comment>
          <template #datetime>
            <a-tooltip :title="item.datetime">
              <span>{{ item.datetime }}</span>
            </a-tooltip>
          </template>
        </a-comment>
      </a-list-item>
    </template>
  </a-list>
</template>
<script lang="ts">
  import { defineComponent } from "vue";
  import {
    HeartOutlined,
    BellOutlined,
    TagTwoTone,
  } from "@ant-design/icons-vue";
  export default defineComponent({
    name: "Comment",
    components: {
      HeartOutlined,
      BellOutlined,
      TagTwoTone,
      Comment,
    },
    setup() {
      return {
        data: [
          {
            author: "张三",
            avatar: "https://joeschmoe.io/api/v1/random",
            content: "这是一片好的文章",
            datetime: "2022年9月27日15:35:27",
            children: [
              {
                author: "王五",
                avatar: "https://joeschmoe.io/api/v1/random",
                content: "这是一片好的文章1",
                datetime: "2022年9月27日15:35:27",
              },
              {
                author: "赵六",
                avatar: "https://joeschmoe.io/api/v1/random",
                content: "这是一片好的文章1",
                datetime: "2022年9月27日15:35:27",
              },
            ],
          },
          {
            author: "李四",
            avatar: "https://joeschmoe.io/api/v1/random",
            content: "我认同作者说的哦",
            datetime: "2022年9月27日15:39:11",
          },
        ],
      };
    },
  });
</script>
