/**
 * @description 导出主题配置，注意事项：此配置下的项修改后需清理浏览器缓存！！！
 */
module.exports = {
  // 布局种类：横向布局horizontal、纵向布局vertical、分栏布局column、综合布局comprehensive、常规布局common、浮动布局float
  layout: 'column',
  // 主题名称：默认blue-black、blue-white、green-black、green-white、渐变ocean、red-white、red-black
  themeName: 'blue-black',
  // 菜单背景 none、vab-background
  background: 'none',
  // 菜单宽度，仅支持px，建议大小：266px、277px、288px，其余尺寸会影响美观
  menuWidth: '266px',
  // 分栏风格(仅针对分栏布局column时生效)：横向风格horizontal、纵向风格vertical、卡片风格card、箭头风格arrow
  columnStyle: 'card',
  // 是否固定头部固定
  fixedHeader: true,
  // 是否开启顶部进度条
  showProgressBar: true,
  // 是否开启标签页
  showTabs: true,
  // 显示标签页时标签页样式：卡片风格card、灵动风格smart、圆滑风格smooth
  tabsBarStyle: 'smooth',
  // 是否标签页图标
  showTabsIcon: true,
  // 是否开启刷新组件
  showRefresh: true,
  // 是否开启主题组件
  showTheme: true,
  // 是否开启全屏组件
  showFullScreen: true,
  //纵向布局、常规布局、综合布局时是否默认收起左侧菜单（不支持分栏布局、横向布局）
  foldSidebar: false,
  // 是否开启页面动画
  showPageTransition: true,
  // 是否开启锁屏
  showLock: true,
}
