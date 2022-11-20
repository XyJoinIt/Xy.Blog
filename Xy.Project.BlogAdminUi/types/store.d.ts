import { VabRouteMeta, VabRouteRecord } from '/#/router'

declare interface AclModuleType {
  admin: boolean
  role: string[]
  permission: string[]
}

declare interface ErrorLogModuleType {
  errorLogs: any[]
}

declare interface RoutesModuleType {
  tab: {
    data: string | undefined
  }
  tabMenu: string | undefined
  activeMenu: {
    data: string | undefined
  }
  routes: VabRouteRecord[]
}

declare type DeviceType = 'mobile' | 'desktop'
declare type LanguageType = 'zh' | 'en'

declare interface SettingsModuleType {
  theme: ThemeType
  device: DeviceType
  collapse: boolean
  lock: boolean
  logo: string
  title: string
  echartsGraphic1: string[]
  echartsGraphic2: string[]
}

declare interface TabsModuleType {
  visitedRoutes: VabRouteRecord[]
}

declare interface OptionType {
  name?: string
  title?: string
  meta: VabRouteMeta
}

declare interface UserModuleType {
  token: string | boolean
  username: string
  avatar: string
}
