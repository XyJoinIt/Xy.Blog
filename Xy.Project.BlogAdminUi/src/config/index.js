/**
 * @description 4个子配置，vue/cli配置|通用配置|主题配置|网络配置导出
 *              config中的部分配置由vue.config.js读取，本质是node，故不可使用window等浏览器对象
 */
const cli = require('./cli.config')
const setting = require('./setting.config')
const theme = require('./theme.config')
const network = require('./net.config')
module.exports = {
  ...cli,
  ...setting,
  ...theme,
  ...network,
}
