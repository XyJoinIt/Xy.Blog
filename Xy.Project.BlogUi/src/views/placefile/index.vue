<template>
  <div class="Content">
    <a-card>
      <a-timeline mode="alternate">
        <a-timeline-item>
          <div>2022年9月23日10:14:49</div>
          <div>博客正式上线，这也是我第一个网站。</div>
        </a-timeline-item>
        <a-timeline-item>
          <div>2022年9月23日10:15:38</div>
          <div>冬天的第一杯姜茶</div>
          <div>
            <a-image
              class="imagesfile"
              :width="200"
              src="https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png"
            />
          </div>
        </a-timeline-item>
        <a-timeline-item>
          <div>2022年9月23日10:15:38</div>
          <div>人面不知何处去，桃花依旧笑春风。 ——崔护《题都城南庄》</div>
        </a-timeline-item>
        <a-timeline-item>
          <div>2022年9月23日10:15:38</div>
          <div>整栋楼只有2家公司上班，其中就有我们 (T_T)。</div>
        </a-timeline-item>
        <a-timeline-item>
          <div>2022年9月23日10:15:38</div>
          <div>
            林俊杰 ：像我这种自己编曲制作自己打鼓
            拉麦四五十厘米高音十五秒不带换气还自带混响的人……
          </div>
        </a-timeline-item>

        <a-timeline-item>
          <div>2022年9月23日10:15:38</div>
          <div>
            <RouterLink to="/">
              《关于long类型的id前端后端交互精度丢失的问题》文章发布
            </RouterLink>
          </div>
        </a-timeline-item>
      </a-timeline>
    </a-card>
  </div>
</template>

<script lang="ts">
  import { toRefs, reactive, computed, defineComponent, onMounted } from "vue";
  import { ClockCircleOutlined } from "@ant-design/icons-vue";
  // 定义接口来定义对象的类型
  interface StateData {
    tabsActiveName: string;
    isScan: boolean;
  }

  export default defineComponent({
    name: "placefile",
    components: { ClockCircleOutlined },
    setup() {
      const state = reactive<StateData>({
        tabsActiveName: "小云邦邦给你两圈",
        isScan: false,
      });

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
  .Content {
    width: 80%;
    text-align: center;
    margin: auto;
    margin-top: 2rem;

    .imagesfile {
      width: 200px;
      /* border-radius: 11px; */
      padding: 10px;
      border: 1px solid #ececec;
    }
  }
</style>
