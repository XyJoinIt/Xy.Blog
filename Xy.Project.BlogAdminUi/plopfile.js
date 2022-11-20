const viewGenerator = require('vab-templates-vue3/view/prompt')
const curdGenerator = require('vab-templates-vue3/curd/prompt')
const componentGenerator = require('vab-templates-vue3/component/prompt')
const mockGenerator = require('vab-templates-vue3/mock/prompt')

module.exports = (plop) => {
  plop.setGenerator('view', viewGenerator)
  plop.setGenerator('curd', curdGenerator)
  plop.setGenerator('component', componentGenerator)
  plop.setGenerator('mock&api', mockGenerator)
}
