// @ts-ignore
const Webpack = require('webpack')

module.exports = {
  createMinChunkSizePlugin: () => [
    new Webpack.optimize.MinChunkSizePlugin({
      minChunkSize: 1024 * 300,
    }),
  ],
}
