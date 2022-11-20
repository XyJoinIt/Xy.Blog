/**
 * @description 导入所有 pinia 模块，请勿修改。
 */

const pinia = createPinia()

export function setupStore(app: any) {
  app.use(pinia)
}

export default pinia
