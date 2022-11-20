import { createApp } from 'vue'
import App from './App.vue'
import { setupVab } from '~/library'
import { setupStore } from '@/store'
import { setupRouter } from '@/router'

const app = createApp(App)

import * as ElementPlusIconsVue from '@element-plus/icons-vue'
for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
  app.component(key, component)
}

/**
 * @description 生产环境启用组件初始化，编译，渲染和补丁性能跟踪。仅在开发模式和支持 Performance.mark API的浏览器中工作。
 */
if (process.env.NODE_ENV === 'development') app.config.performance = true

setupVab(app)
setupStore(app)
setupRouter(app)
  .isReady()
  .then(() => app.mount('#app'))
