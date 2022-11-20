module.exports = {
  // @ts-ignore
  createImageCompression: (config) => {
    config.module
      .rule('images')
      .use('image-webpack-loader')
      .loader('image-webpack-loader')
      .options({
        bypassOnDebug: true,
      })
      .end()
  },
}
