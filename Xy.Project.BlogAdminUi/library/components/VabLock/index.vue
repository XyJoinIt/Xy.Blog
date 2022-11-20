<script lang="ts" setup>
  import { useUserStore } from '@/store/modules/user'
  import { useSettingsStore } from '@/store/modules/settings'

  const vFocus: any = {
    mounted(el: HTMLElement) {
      el.querySelector('input')?.focus()
    },
  }

  const userStore = useUserStore()
  const { avatar } = storeToRefs(userStore)
  const settingsStore = useSettingsStore()
  const { theme, lock, title } = storeToRefs(settingsStore)
  const { handleLock: _handleLock, handleUnLock: _handleUnLock } = settingsStore

  const background = ref(
    'https://fastly.jsdelivr.net/gh/' +
      'chuzh' +
      'ixin/image/vab-im' +
      'age-lock/' +
      `${Math.round(Math.random() * 31)}.jpg`
  )
  const randomBackground = () => {
    background.value =
      'https://fastly.jsdelivr.net/gh/' +
      'chuzh' +
      'ixin/image/vab-im' +
      'age-lock/' +
      `${Math.round(Math.random() * 31)}.jpg`
  }

  const validatePass = (rule: any, value: string, callback: any) => {
    if (value === '' || value !== '123456') {
      callback(new Error('请输入正确的密码'))
    } else {
      callback()
    }
  }

  const formRef = ref()
  const form = ref({
    password: '123456',
  })
  const rules = {
    password: [{ validator: validatePass, trigger: 'blur' }],
  }

  let lockIcon = true
  const handleUnLock = () => {
    formRef.value.validate(async (valid: boolean) => {
      if (valid) {
        lockIcon = false
        setTimeout(async () => {
          await _handleUnLock()
          lockIcon = true
          await randomBackground()
          const el = document.querySelector('.vab-side-bar') as HTMLElement
          if (el) el.removeAttribute('style')
        }, 500)
      }
    })
  }

  const handleLock = () => {
    _handleLock()
    const el = document.querySelector('.vab-side-bar') as HTMLElement
    if (el) el.style.display = 'none'
  }
</script>

<template>
  <vab-icon v-if="theme.showLock" icon="lock-line" @click="handleLock" />
  <transition v-if="theme.showLock" mode="out-in" name="fade-transform">
    <div v-if="lock" class="vab-screen-lock">
      <div
        class="vab-screen-lock-background"
        :style="{
          background: `fixed url(${background}) center`,
          backgroundSize: '100% 100%',
          filter: 'blur(10px)',
        }"
      ></div>

      <div class="vab-screen-lock-content">
        <div class="vab-screen-lock-content-title">
          <el-avatar :size="180" :src="avatar" />
          <vab-icon :icon="lockIcon ? 'lock-line' : 'lock-unlock-line'" />
          {{ title }} 屏幕已锁定
        </div>
        <div class="vab-screen-lock-content-form">
          <el-form ref="formRef" :model="form" :rules="rules" @submit.prevent>
            <el-form-item label="" :label-width="0" prop="password">
              <el-input
                v-model="form.password"
                v-focus
                autocomplete="off"
                placeholder="请输出密码123456"
                type="password"
              >
                <template #suffix>
                  <el-button
                    native-type="submit"
                    type="primary"
                    @click="handleUnLock"
                  >
                    <vab-icon
                      :icon="lockIcon ? 'lock-line' : 'lock-unlock-line'"
                    />
                    解锁
                  </el-button>
                </template>
              </el-input>
            </el-form-item>
          </el-form>
        </div>
        <span @click="randomBackground">切换壁纸</span>
      </div>
    </div>
  </transition>
</template>

<style lang="scss" scoped>
  .vab-screen-lock {
    position: fixed;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    z-index: $base-z-index;
    display: flex;
    flex-wrap: wrap;
    align-items: center;
    justify-content: center;
    font-weight: bold;
    background-color: rgba(255, 255, 255, 0.6);
    transition: $base-transition;
    backdrop-filter: blur(10px);

    &-background {
      position: absolute;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0;
      z-index: $base-z-index - 1;
    }

    &-content {
      z-index: $base-z-index;
      padding: 40px 95px 40px 95px;
      color: #252a30;
      text-align: center;
      background: rgba(255, 255, 255, 0.6);
      backdrop-filter: blur(10px);
      border-radius: 15px;

      > span {
        font-size: $base-font-size-small;
        cursor: pointer;
      }

      &-title {
        line-height: 50px;
        color: #252a30;
        text-align: center;

        .ri-lock-line,
        .ri-lock-unlock-line {
          display: block;
          margin: auto !important;
          font-size: 30px;
          color: #252a30 !important;
          transition: $base-transition;
        }
      }

      &-form {
        :deep() {
          .el-input__inner {
            width: 280px;
            height: 40px;
            line-height: 40px;
          }

          .el-input__wrapper {
            padding-right: 0;
            .el-input__suffix {
              right: 0;

              .el-button {
                height: 40px;
                line-height: 40px;
                border-top-left-radius: 0;
                border-bottom-left-radius: 0;
                i {
                  margin-left: 0 !important;
                }
              }

              .el-input__validateIcon {
                display: none;
              }
            }
          }
        }
      }
    }

    @media (max-width: 576px) {
      .vab-screen-lock-content {
        width: auto !important;
        margin: 5vw;
      }
    }
  }
</style>
