const { createUnPlugin } = require('vue-' + 'unplugin')
const { createWebpackBar } = require('./webpack' + 'Bar/index.ts')
const { createDefineOptions } = require('./defineOptions/index.ts')
const { createDefinePlugin } = require('./definePlugin/index.ts')
const { createProvidePlugin } = require('./providePlugin/index.ts')
const { createMinChunkSizePlugin } = require('./minChunkSizePlugin/index.ts')

const dev = process.env.NODE_ENV === 'development'
module.exports = {
  createVuePlugin: () => [
    ...createDefineOptions(),
    ...createUnPlugin(),
    require('unplugin-element-plus/webpack')(),
    ...createWebpackBar(),
    ...createDefinePlugin(),
    ...createProvidePlugin(),
    ...(dev ? [] : createMinChunkSizePlugin()),
  ],
}
