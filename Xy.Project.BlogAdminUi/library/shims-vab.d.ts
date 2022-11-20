declare let __APP_INFO__: any

// CSS
type CSSModuleClasses = { readonly [key: string]: string }
declare module '*.module.scss' {
  const classes: CSSModuleClasses
  export default classes
}
declare module '*.scss' {
  const css: string
  export default css
}

declare module 'vab-icons'
