// @ts-ignore
const { resolve } = require('path')

module.exports = {
  // @ts-ignore
  createSvgSprite: (config) => {
    config.module.rule('svg').exclude.add(resolve('src/icon'))
    config.module
      .rule('vabIcon')
      .test(/\.svg$/)
      .include.add(resolve('src/icon'))
      .end()
      .use('svg-sprite-loader')
      .loader('svg-sprite-loader')
      .options({ symbolId: 'vab-icon-[name]' })
  },
}
