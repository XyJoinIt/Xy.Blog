<template>
  <div class="login_background">
    <div class="login_background_front"></div>
    <div class="login_main">
      <div class="login-form">
        <el-card>
          <el-tabs v-model="activeKey">
            <el-tab-pane label="账户密码" name="userAccount">
              <el-form
                ref="formRef"
                label-position="left"
                :model="form"
                :rules="rules"
              >
                <el-form-item prop="username">
                  <el-input
                    v-model.trim="form.username"
                    v-focus
                    placeholder="请输入用户名"
                    tabindex="1"
                    type="text"
                  >
                    <template #prefix>
                      <vab-icon icon="user-line" />
                    </template>
                  </el-input>
                </el-form-item>
                <el-form-item prop="password">
                  <el-input
                    :key="passwordType"
                    ref="passwordRef"
                    v-model.trim="form.password"
                    placeholder="请输入密码"
                    tabindex="2"
                    :type="passwordType"
                    @keyup.enter="handleLogin"
                  >
                    <template #prefix>
                      <vab-icon icon="lock-line" />
                    </template>
                    <template v-if="passwordType === 'password'" #suffix>
                      <vab-icon
                        class="show-password"
                        icon="eye-off-line"
                        @click="handlePassword"
                      />
                    </template>
                    <template v-else #suffix>
                      <vab-icon
                        class="show-password"
                        icon="eye-line"
                        @click="handlePassword"
                      />
                    </template>
                  </el-input>
                </el-form-item>

                <el-form-item prop="verificationCode">
                  <el-row :gutter="20">
                    <el-col :span="16">
                      <el-input
                        v-model.trim="form.verificationCode"
                        class="w-50 m-2"
                        :placeholder="'验证码' + previewText"
                        type="text"
                      >
                        <template #prefix>
                          <vab-icon icon="barcode-box-line" />
                        </template>
                      </el-input>
                    </el-col>
                    <el-col :span="8">
                      <el-image
                        class="code"
                        :src="codeUrl"
                        @click="changeCode"
                      />
                    </el-col>
                  </el-row>
                </el-form-item>

                <el-form-item>
                  <el-button
                    class="login-btn"
                    :loading="loading"
                    style="width: 100%"
                    type="primary"
                    @click="handleLogin"
                  >
                    登录
                  </el-button>
                </el-form-item>
              </el-form>
            </el-tab-pane>
          </el-tabs>
        </el-card>
      </div>
    </div>
  </div>
</template>

<script>
  import { useSettingsStore } from '@/store/modules/settings'
  import { useUserStore } from '@/store/modules/user'
  import { isPassword } from '@/utils/validate'
  import { onBeforeRouteLeave } from 'vue-router'

  export default defineComponent({
    name: 'Login',
    directives: {
      focus: {
        mounted(el) {
          el.querySelector('input').focus()
        },
      },
    },
    setup() {
      const route = useRoute()
      const router = useRouter()

      const userStore = useUserStore()
      const settingsStore = useSettingsStore()

      const login = (form) => userStore.login(form)

      const validateUsername = (rule, value, callback) => {
        if ('' === value) callback(new Error('用户名不能为空'))
        else callback()
      }
      const validatePassword = (rule, value, callback) => {
        if (!isPassword(value)) callback(new Error('密码不能少于6位'))
        else callback()
      }

      const state = reactive({
        formRef: null,
        passwordRef: null,
        activeKey: 'userAccount',
        form: {
          username: 'xiaoyun',
          password: '123456',
          verificationCode: '',
        },
        rules: {
          username: [
            {
              required: true,
              trigger: 'blur',
              validator: validateUsername,
            },
          ],
          password: [
            {
              required: true,
              trigger: 'blur',
              validator: validatePassword,
            },
          ],
          // verificationCode: [
          //   {
          //     required: true,
          //     trigger: 'blur',
          //     message: '验证码不能空',
          //   },
          // ],
        },
        loading: false,
        passwordType: 'password',
        redirect: undefined,
        timer: 0,
        codeUrl: 'https://www.oschina.net/action/user/captcha',
        previewText: '',
      })

      const handleRoute = () => {
        return state.redirect === '/404' || state.redirect === '/403'
          ? '/'
          : state.redirect
      }
      const handlePassword = () => {
        state.passwordType === 'password'
          ? (state.passwordType = '')
          : (state.passwordType = 'password')
        nextTick(() => {
          state['passwordRef'].focus()
        })
      }
      const handleLogin = async () => {
        state['formRef'].validate(async (valid) => {
          if (valid)
            try {
              state.loading = true
              await login(state.form).catch(() => {})
              await router.push(handleRoute())
            } finally {
              state.loading = false
            }
        })
      }
      const changeCode = () => {
        state.codeUrl = `https://www.oschina.net/action/user/captcha?timestamp=${new Date().getTime()}`
      }

      onBeforeMount(() => {
        //state.form.username = ''
        //state.form.password = ''
        // 为了演示效果，会在官网演示页自动登录到首页，正式开发可删除
        // if (
        //   document.domain === 'vue-admin-beautiful.com' ||
        //   document.domain === 'chu1204505056.gitee.io'
        // ) {
        //   state.previewText = '（演示地址验证码可不填）'
        //   state.timer = setTimeout(() => {
        //     handleLogin()
        //   }, 5000)
        // }
      })

      watchEffect(() => {
        state.redirect = (route.query && route.query.redirect) || '/'
      })

      onBeforeRouteLeave((to, from, next) => {
        clearInterval(state.timer)
        next()
      })

      return {
        ...toRefs(state),
        title: settingsStore.getTitle,
        handlePassword,
        handleLogin,
        changeCode,
      }
    },
  })
</script>

<style lang="scss" scoped>
  .login_background {
    width: 100%;
    height: 100%;
    overflow: hidden;
    background-size: cover;
    background-position: center;
    background-image: url('~@/assets/login_images/login_background.png');
  }
  .login-btn {
    display: inherit;
    // width: 220px;
    //height: 50px;
    margin-top: 5px;
    background: var(--el-color-primary);
    border: 0;

    &:hover {
      opacity: 0.9;
    }
  }
  .login_background_front {
    width: 450px;
    height: 450px;
    margin-left: 100px;
    margin-top: 15%;
    overflow: hidden;
    /*position: relative;*/
    background-size: cover;
    background-position: center;
    background-image: url('~@/assets/login_images/login_background_front.png');
    animation-name: myfirst;
    animation-duration: 5s;
    animation-timing-function: linear;
    animation-delay: 1s;
    animation-iteration-count: infinite;
    animation-direction: alternate;
    animation-play-state: running;
    /* Safari and Chrome: */
    -webkit-animation-name: myfirst;
    -webkit-animation-duration: 5s;
    -webkit-animation-timing-function: linear;
    -webkit-animation-delay: 1s;
    -webkit-animation-iteration-count: infinite;
    -webkit-animation-direction: alternate;
    -webkit-animation-play-state: running;
  }
  @keyframes myfirst {
    0% {
      left: 0px;
      top: 0px;
    }
    50% {
      left: 50px;
      top: 0px;
    }
    100% {
      left: 0px;
      top: 0px;
    }
  }
  @-webkit-keyframes myfirst /* Safari and Chrome */ {
    0% {
      left: 0px;
      top: 0px;
    }
    50% {
      left: 50px;
      top: 0px;
    }
    100% {
      left: 0px;
      top: 0px;
    }
  }
  .login_adv__title h2 {
    font-size: 40px;
  }
  .login_adv__title h4 {
    font-size: 18px;
    margin-top: 10px;
    font-weight: normal;
  }
  .login_adv__title p {
    font-size: 14px;
    margin-top: 10px;
    line-height: 1.8;
    color: rgba(255, 255, 255, 0.6);
  }
  .login_adv__title div {
    margin-top: 10px;
    display: flex;
    align-items: center;
  }
  .login_adv__title div span {
    margin-right: 15px;
  }
  .login_adv__title div i {
    font-size: 40px;
  }
  .login_adv__title div i.add {
    font-size: 20px;
    color: rgba(255, 255, 255, 0.6);
  }
  /*background-image:linear-gradient(transparent, #000);*/
  .login_main {
    flex: 1;
    overflow: auto;
    display: flex;
  }
  .login-form {
    top: 20%;
    right: 15%;
    position: absolute;
    width: 450px;
    margin-left: 10%;
    margin-top: 20px;
    padding: 10px 0;
  }
  .login-header {
    margin-bottom: 20px;
  }
  .login-header .logo {
    display: flex;
    align-items: center;
  }
  .login-header .logo img {
    width: 35px;
    height: 35px;
    vertical-align: bottom;
    margin-right: 10px;
  }
  .login-header .logo label {
    font-size: 24px;
  }
  .login-header h2 {
    font-size: 24px;
    font-weight: bold;
    margin-top: 40px;
  }
  .login_config {
    position: absolute;
    top: 20px;
    right: 20px;
  }
  @media (max-width: 1200px) {
    .login-form {
      width: 340px;
    }
  }
  @media (max-width: 1000px) {
    .login_main {
      display: block;
    }
    .login_background_front {
      display: none;
    }
    .login-form {
      width: 100%;
      padding: 20px 40px;
      right: 0 !important;
      top: 0 !important;
    }
  }
</style>
