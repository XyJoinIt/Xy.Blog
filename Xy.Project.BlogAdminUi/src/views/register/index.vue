<template>
  <div class="register-container">
    <el-row>
      <el-col :lg="14" :md="11" :sm="24" :xl="14" :xs="24">
        <div style="color: transparent">占位符</div>
      </el-col>
      <el-col :lg="9" :md="12" :sm="24" :xl="9" :xs="24">
        <el-form
          ref="registerFormRef"
          class="register-form"
          :model="form"
          :rules="registerRules"
        >
          <div class="title">hello !</div>
          <div class="title-tips">注册</div>
          <el-form-item prop="username">
            <el-input
              v-model.trim="form.username"
              v-focus
              auto-complete="off"
              placeholder="请输入用户名"
              type="text"
            >
              <template #prefix>
                <vab-icon icon="user-line" />
              </template>
            </el-input>
          </el-form-item>
          <el-form-item prop="phone">
            <el-input
              v-model.trim="form.phone"
              maxlength="11"
              placeholder="请输入手机号"
              show-word-limit
              type="text"
            >
              <template #prefix>
                <vab-icon icon="smartphone-line" />
              </template>
            </el-input>
          </el-form-item>
          <el-form-item prop="phoneCode" style="position: relative">
            <el-input
              v-model.trim="form.phoneCode"
              placeholder="请输入手机验证码"
              type="text"
            >
              <template #prefix>
                <vab-icon icon="barcode-box-line" />
              </template>
            </el-input>
            <el-button
              class="phone-code"
              :disabled="isGetPhone"
              type="primary"
              @click="getPhoneCode"
            >
              {{ phoneCode }}
            </el-button>
          </el-form-item>
          <el-form-item prop="password">
            <el-input
              v-model.trim="form.password"
              autocomplete="new-password"
              placeholder="请输入密码"
              type="password"
            >
              <template #prefix>
                <vab-icon icon="lock-line" />
              </template>
            </el-input>
          </el-form-item>
          <el-form-item>
            <el-button
              class="register-btn"
              type="primary"
              @click.prevent="handleRegister"
            >
              注册
            </el-button>
          </el-form-item>
          <el-form-item>
            <router-link to="/login">登录</router-link>
          </el-form-item>
        </el-form>
      </el-col>
      <el-col :lg="1" :md="1" :sm="24" :xl="1" :xs="24">
        <div style="color: transparent">占位符</div>
      </el-col>
    </el-row>
  </div>
</template>

<script>
  import { onBeforeRouteLeave } from 'vue-router'
  import { isPassword, isPhone } from '@/utils/validate'
  import { register } from '@/api/user'
  import { useUserStore } from '@/store/modules/user'

  export default defineComponent({
    name: 'Register',
    directives: {
      focus: {
        inserted(el) {
          el.querySelector('input').focus()
        },
      },
    },
    setup() {
      const $baseConfirm = inject('$baseConfirm')

      const router = useRouter()

      const userStore = useUserStore()
      const { setToken } = userStore

      const validateUsername = (rule, value, callback) => {
        if ('' === value) {
          callback(new Error('用户名不能为空'))
        } else {
          callback()
        }
      }
      const validatePassword = (rule, value, callback) => {
        if (!isPassword(value)) {
          callback(new Error('密码不能少于6位'))
        } else {
          callback()
        }
      }
      const validatePhone = (rule, value, callback) => {
        if (!isPhone(value)) {
          callback(new Error('请输入正确的手机号'))
        } else {
          callback()
        }
      }

      const state = reactive({
        registerFormRef: null,
        isGetPhone: false,
        timer: null,
        phoneCode: '获取验证码',
        showRegister: false,
        form: {},
        registerRules: {
          username: [
            {
              required: true,
              trigger: 'blur',
              message: '请输入用户名',
            },
            { validator: validateUsername, trigger: 'blur' },
          ],
          phone: [
            {
              required: true,
              trigger: 'blur',
              message: '请输入手机号',
            },
            { validator: validatePhone, trigger: 'blur' },
          ],
          password: [
            {
              required: true,
              trigger: 'blur',
              message: '请输入密码',
            },
            { validator: validatePassword, trigger: 'blur' },
          ],
          phoneCode: [
            {
              required: true,
              trigger: 'blur',
              message: '请输入手机验证码',
            },
          ],
        },
        loading: false,
        passwordType: 'password',
      })

      const getPhoneCode = () => {
        if (!isPhone(state.form.phone)) {
          state['registerFormRef'].validateField('phone')
          return
        }
        state.isGetPhone = true
        let n = 60
        state.timer = setInterval(() => {
          if (n > 0) {
            n--
            state.phoneCode = '获取验证码 ' + n + 's'
          } else {
            clearInterval(state.timer)
            state.phoneCode = '获取验证码'
            state.timer = null
            state.isGetPhone = false
          }
        }, 1000)
      }
      const handleRegister = () => {
        state['registerFormRef'].validate(async (valid) => {
          if (valid) {
            const {
              msg,
              data: { token },
            } = await register(state.form).catch(() => {})
            //$baseMessage(msg, 'success', 'vab-hey-message-success')
            $baseConfirm(
              `${msg}，点击确定模拟进入拥有【editor】角色的首页`,
              null,
              async () => {
                setToken(token)
                await router.push('/index')
              }
            )
          }
        })
      }

      onBeforeRouteLeave((to, from, next) => {
        clearInterval(state.timer)
        next()
      })

      return {
        ...toRefs(state),
        getPhoneCode,
        handleRegister,
      }
    },
  })
</script>

<style lang="scss" scoped>
  .register-container {
    height: 100vh;
    min-height: 700px;
    background: url('~@/assets/login_images/background.jpg') center center fixed
      no-repeat;
    background-size: cover;

    .register-form {
      position: relative;
      max-width: 100%;
      padding: 4.5vh;
      margin: calc((100vh - 555px) / 2) 5vw 5vw;
      overflow: hidden;
      background: url('~@/assets/login_images/login_form.png');
      background-size: 100% 100%;
      .title {
        font-size: 54px;
        font-weight: 500;
        color: var(--el-color-white);
      }

      .title-tips {
        margin-top: 29px;
        font-size: 26px;
        font-weight: 400;
        color: var(--el-color-white);
        text-overflow: ellipsis;
        white-space: nowrap;
      }

      .register-btn {
        display: inherit;
        width: 220px;
        height: 50px;
        margin-top: 5px;
        background: var(--el-color-primary);
        border: 0;

        &:hover {
          opacity: 0.9;
        }
      }

      .phone-code {
        position: absolute;
        top: 8px;
        right: 10px;
        width: 120px;
        height: 32px;
        font-size: 14px;
        color: #fff;
        cursor: pointer;
        user-select: none;
        border-radius: 3px;
      }
    }

    .tips {
      margin-bottom: 10px;
      font-size: $base-font-size-default;
      color: var(--el-color-white);

      span {
        &:first-of-type {
          margin-right: 16px;
        }
      }
    }

    :deep() {
      .el-form-item {
        padding-right: 0;
        margin: 20px 0;
        color: #454545;
        background: transparent;
        border: 1px solid transparent;
        border-radius: 2px;

        &__content {
          min-height: $base-input-height;
          line-height: $base-input-height;
        }

        &__error {
          position: absolute;
          top: 100%;
          left: 18px;
          font-size: $base-font-size-small;
          line-height: 18px;
          color: var(--el-color-error);
        }
      }

      .el-input {
        box-sizing: border-box;

        input {
          height: 48px;
          line-height: 48px;
          border: 0;
        }

        &__suffix-inner {
          position: absolute;
          right: 15px;
          cursor: pointer;

          .el-input__count {
            position: absolute;
            top: 25px;
            right: 0px;
          }
        }
      }

      .code {
        position: absolute;
        top: 4px;
        right: 4px;
        cursor: pointer;
        border-radius: $base-border-radius;
      }
    }
  }
</style>
