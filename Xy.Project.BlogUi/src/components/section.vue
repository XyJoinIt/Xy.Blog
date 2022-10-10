<template>
  <div class="section" id="section2">
    <div class="fp-tablecell">
      <div class="page2">
        <div class="warp-box">
          <div class="new-article">
            <div class="inner wow fadeInDown" data-wow-delay=".2s">
              <h1>{{ title }}</h1>
              <p>
                {{ msg }}
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
  import { Options, Vue } from "vue-class-component";

  @Options({
    props: {
      msg: String,
      title: String,
    },
  })
  export default class section extends Vue {
    msg!: string;
    title!: string;
  }
</script>

<style scoped lang="scss"></style>
