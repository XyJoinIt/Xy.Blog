/**
 * @description 所有全局配置的状态管理，如无必要请勿修改
 */
import { SettingsModuleType } from '/#/store'
import { isJson } from '@/utils/validate'
import {
  logo as _logo,
  title as _title,
  layout,
  themeName,
  background,
  columnStyle,
  fixedHeader,
  foldSidebar,
  menuWidth,
  showProgressBar,
  showTabs,
  showTabsIcon,
  showRefresh,
  showTheme,
  showFullScreen,
  showPageTransition,
  showLock,
  tabsBarStyle,
} from '@/config'

const defaultTheme: ThemeType = {
  layout,
  themeName,
  background,
  columnStyle,
  fixedHeader,
  foldSidebar,
  menuWidth,
  showProgressBar,
  showTabs,
  showTabsIcon,
  showRefresh,
  showTheme,
  showFullScreen,
  showPageTransition,
  showLock,
  tabsBarStyle,
}

const getLocalStorage = (key: string) => {
  const value: string | null = localStorage.getItem(key)
  return value && isJson(value) ? JSON.parse(value) : false
}

const theme = getLocalStorage('theme') || { ...defaultTheme }
const { collapse = foldSidebar } = getLocalStorage('collapse')
const { lock = false } = getLocalStorage('lock')
const { logo = _logo } = getLocalStorage('logo')
const { title = _title } = getLocalStorage('title')

export const useSettingsStore = defineStore('settings', {
  state: (): SettingsModuleType => ({
    theme,
    device: 'desktop',
    collapse,
    lock,
    logo,
    title,
    echartsGraphic1: ['#3ED572', '#399efd'],
    echartsGraphic2: ['#399efd', '#8cc8ff'],
  }),
  getters: {
    getTheme: (state) => state.theme,
    getDevice: (state) => state.device,
    getCollapse: (state) => state.collapse,
    getLock: (state) => state.lock,
    getLogo: (state) => state.logo,
    getTitle: (state) => state.title,
  },
  actions: {
    updateState(obj: any) {
      Object.getOwnPropertyNames(obj).forEach((key) => {
        // eslint-disable-next-line @typescript-eslint/ban-ts-comment
        // @ts-ignore
        this[key] = obj[key]
        localStorage.setItem(
          key,
          typeof obj[key] == 'string'
            ? `{"${key}":"${obj[key]}"}`
            : `{"${key}":${obj[key]}}`
        )
      })
    },
    saveTheme() {
      localStorage.setItem('theme', JSON.stringify(this.theme))
    },
    resetTheme() {
      this.theme = { ...defaultTheme }
      localStorage.removeItem('theme')
      this.updateTheme()
    },
    updateTheme() {
      const index = this.theme.themeName.indexOf('-')
      const themeName = this.theme.themeName.substring(0, index) || 'blue'

      let variables = require(`@vab/styles/variables/vab-${themeName}-variables.module.scss`)
      if (variables.default) variables = variables.default

      Object.keys(variables).forEach((key) => {
        if (key.startsWith('vab-')) {
          useCssVar(key.replace('vab-', '--el-'), ref(null)).value =
            variables[key]
        }
      })

      if (this.theme.menuWidth && this.theme.menuWidth.endsWith('px'))
        useCssVar('--el-left-menu-width', ref(null)).value =
          this.theme.menuWidth
      else useCssVar('--el-left-menu-width', ref(null)).value = '266px'

      this.echartsGraphic1 = [
        variables['vab-color-transition'],
        variables['vab-color-primary'],
      ]

      this.echartsGraphic2 = [
        variables['vab-color-primary-light-5'],
        variables['vab-color-primary'],
      ]

      const menuBackground =
        this.theme.themeName.split('-')[1] || this.theme.themeName
      document.getElementsByTagName(
        'body'
      )[0].className = `vab-theme-${menuBackground}`

      if (this.theme.background !== 'none') {
        document
          .getElementsByTagName('body')[0]
          .classList.add(this.theme.background)
      }
    },
    toggleCollapse() {
      this.collapse = !this.collapse
      localStorage.setItem('collapse', `{"collapse":${this.collapse}}`)
    },
    toggleDevice(device: string) {
      this.updateState({ device })
    },
    openSideBar() {
      this.updateState({ collapse: false })
    },
    foldSideBar() {
      this.updateState({ collapse: true })
    },
    handleLock() {
      this.updateState({ lock: true })
    },
    handleUnLock() {
      this.updateState({ lock: false })
    },
    changeLogo(logo: string) {
      this.updateState({ logo })
    },
    changeTitle(title: string) {
      this.updateState({ title })
    },
  },
})
