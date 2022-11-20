import { VNode } from 'vue'

declare interface globalPropertiesType {
  $baseLoading(index?: string | undefined, text?: string): any
  $baseMessage(
    message: string | VNode,
    type?: 'success' | 'warning' | 'info' | 'error',
    customClass?: string,
    dangerouslyUseHTMLString?: boolean
  ): any
  $baseAlert(
    content: string | VNode,
    title: string,
    callback: (() => unknown) | undefined
  ): any
  $baseConfirm(
    content: string | VNode,
    title: string,
    callback1: any,
    callback2: any,
    confirmButtonText: string,
    cancelButtonText: string
  ): any
  $baseNotify(
    message: string,
    title: string,
    type?: 'success' | 'warning' | 'info' | 'error',
    position?: 'top-right' | 'top-left' | 'bottom-right' | 'bottom-left',
    duration?: number
  ): any
  $baseTableHeight(formType: number | unknown): number
  $pub(...args: any[]): void
  $sub(): void
  $unsub(): void
}
