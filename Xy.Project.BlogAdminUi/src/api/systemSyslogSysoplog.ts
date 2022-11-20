import request from '@/utils/request'

export function getList(params: any) {
  return request({
    url: '/system/syslog/sysoplog/getList',
    method: 'get',
    params,
  })
}

export function doEdit(data: any) {
  return request({
    url: '/system/syslog/sysoplog/doEdit',
    method: 'post',
    data,
  })
}

export function doDelete(data: any) {
  return request({
    url: '/system/syslog/sysoplog/doDelete',
    method: 'post',
    data,
  })
}
