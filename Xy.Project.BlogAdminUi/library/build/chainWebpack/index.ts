const { createGzip } = require('./gzip/index.ts')
const { createBanner } = require('./banner/index.ts')
const { createBuild7z } = require('./build7z/index.ts')
const { createSvgSprite } = require('./svgSprite/index.ts')
const { createOptimization } = require('./optimization/index.ts')
const { createSourceInjector } = require('./sourceInjector/index.ts')
const { createImageCompression } = require('./imageCompression/index.ts')
const { build7z, buildGzip, imageCompression } = require('../../../src/config')

module.exports = {
  // @ts-ignore
  createChainWebpack: (env, config) => {
    config.resolve.symlinks(true)
    createBanner(config)
    createSvgSprite(config)
    if (env === 'production') {
      if (build7z) createBuild7z(config)
      if (buildGzip) createGzip(config)
      if (imageCompression) createImageCompression(config)
      createOptimization(config)
    }
    if (env === 'development') config.devtool('cheap-module-source-map')
    createSourceInjector(config)
  },
}
