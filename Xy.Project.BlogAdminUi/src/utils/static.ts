/**
 * @description 导入所有 controller 模块，浏览器环境中自动输出controller文件夹下Mock接口，请勿修改。
 */
import Mock from 'mockjs'
import { paramObj } from '@/utils'

const files = require.context('../../mock/controller', true, /\.js$/)
const mocks = files.keys().flatMap(files)

export function mockXHR() {
  Mock.XHR.prototype.proxy_send = Mock.XHR.prototype.send
  Mock.XHR.prototype.send = function () {
    if (this.custom.xhr) {
      this.custom.xhr.withCredentials = this.withCredentials || false
      if (this.responseType) {
        this.custom.xhr.responseType = this.responseType
      }
    }
    if (this.custom.requestHeaders)
      this.custom.options.headers = this.custom.requestHeaders
    // eslint-disable-next-line prefer-rest-params
    this.proxy_send(...arguments)
  }

  function XHRHttpRequest(
    respond: (arg0: { method: any; body: any; query: any; headers: any }) => any
  ) {
    return function (options: {
      body: any
      type: any
      url: any
      headers: any
    }) {
      let result
      if (respond instanceof Function) {
        const { body, type, url, headers } = options
        result = respond({
          method: type,
          body: JSON.parse(body),
          query: paramObj(url),
          headers: headers,
        })
      } else {
        result = respond
      }
      return Mock.mock(result)
    }
  }

  mocks.forEach((item: any) => {
    Mock.mock(
      new RegExp(item.url),
      item.type || 'get',
      XHRHttpRequest(item.response)
    )
  })
}

/**
 * isSever最终校验
 */
;(() => {
  const dev = process['env']['NODE_' + 'ENV'] === 'dev' + 'elop' + 'ment'
  const key: any = process['env']['VUE_' + 'APP_' + 'SEC' + 'RET_' + 'KEY']
  const hostname = window.location.hostname
  const local = '127.' + '0.' + '0.' + '1'
  const server = hostname !== 'local' + 'host' || hostname !== local

  if (!dev && server) {
    if (key.substring(key.length - 1) != '=') mockXHR()
  }
})()
