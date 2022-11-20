const productionGzipExtensions = ['html', 'js', 'css', 'svg']
const CompressionWebpackPlugin = require('compression-webpack-plugin')

module.exports = {
  // @ts-ignore
  createGzip: (config) => {
    config.plugin('compression').use(CompressionWebpackPlugin, [
      {
        filename: '[path][base].gz[query]',
        algorithm: 'gzip',
        test: new RegExp('\\.(' + productionGzipExtensions.join('|') + ')$'),
        threshold: 8192,
        minRatio: 0.8,
      },
    ])
  },
}
