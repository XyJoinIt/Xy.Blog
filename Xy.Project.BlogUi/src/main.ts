import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import Antd from "ant-design-vue";
import "ant-design-vue/dist/antd.css";
import "animate.css"; //动态库

import VMdPreview from "@kangc/v-md-editor/lib/preview";
import "@kangc/v-md-editor/lib/style/preview.css";
// 引入所使用的主题 此处以 github 主题为例
import githubTheme from "@kangc/v-md-editor/lib/theme/github";
import "@kangc/v-md-editor/lib/theme/style/github.css";
// highlightjs
import hljs from "highlight.js";
//组件
import createEmojiPlugin from "@kangc/v-md-editor/lib/plugins/emoji/index"; //emoji
//代码高亮
import createHighlightLinesPlugin from "@kangc/v-md-editor/lib/plugins/highlight-lines/index";
import "@kangc/v-md-editor/lib/plugins/highlight-lines/highlight-lines.css";
VMdPreview.use(githubTheme, {
  Hljs: hljs,
})
  .use(createEmojiPlugin())
  .use(createHighlightLinesPlugin());

const app = createApp(App);

app.use(Antd).use(store).use(router).use(VMdPreview).mount("#app");
