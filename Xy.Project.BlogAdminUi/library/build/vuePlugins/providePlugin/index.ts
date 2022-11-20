// @ts-ignore
const Webpack = require('webpack')
const { providePlugin } = require('../../../../src/config')

module.exports = {
  createProvidePlugin: () => [new Webpack.ProvidePlugin(providePlugin)],
}
