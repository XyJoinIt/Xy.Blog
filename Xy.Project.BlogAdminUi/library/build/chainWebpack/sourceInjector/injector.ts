const { relative } = require('path')

const blockName = 'vue-filename-injector'
// @ts-ignore
module.exports = function (content) {
  // @ts-ignore
  const { rootContext, resourcePath } = this
  const context = rootContext || process.cwd()
  const filePath = relative(context, resourcePath).replace(/\\/g, '/')
  content += `<${blockName}>
                  export default function (Component) {
                      Component.__source = ${JSON.stringify(filePath)}
                  }
              </${blockName}>`
  return content
}
