const injector = require.resolve('./injector.ts')

module.exports = {
  // @ts-ignore
  createSourceInjector: (config) => {
    config.module
      .rule('vue')
      .use('vue-filename-injector')
      .loader(injector)
      .after('vue-loader')
      .end()
  },
}
