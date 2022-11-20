// @ts-ignore
const Webpack = require('webpack')
const { webpackBanner } = require('./config.ts')

module.exports = {
  // @ts-ignore
  createBanner: (config) => {
    config
      .plugin('banner')
      .use(Webpack.BannerPlugin, [
        `${webpackBanner}${process.env.VUE_APP_UPDATE_TIME}`,
      ])
  },
}
