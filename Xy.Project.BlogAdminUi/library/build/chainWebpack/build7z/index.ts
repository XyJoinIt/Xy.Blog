const dayjs = require('dayjs')
const { outputDir, abbreviation } = require('../../../../src/config')
const FileManagerPlugin = require('filemanager-webpack-plugin')

module.exports = {
  // @ts-ignore
  createBuild7z: (config) => {
    config.plugin('fileManager').use(FileManagerPlugin, [
      {
        events: {
          onEnd: {
            archive: [
              {
                source: `./${outputDir}`,
                destination: `./${outputDir}/${abbreviation}_${dayjs().unix()}.zip`,
              },
            ],
          },
        },
      },
    ])
  },
}
