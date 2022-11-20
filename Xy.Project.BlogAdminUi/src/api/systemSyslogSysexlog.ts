import request from '@/utils/request'

export function getList(params: any) {
  return request({
    url: '/system/syslog/sysexlog/getList',
    method: 'get',
    params,
  })
}

export function doEdit(data: any) {
  return request({
    url: '/system/syslog/sysexlog/doEdit',
    method: 'post',
    data,
  })
}

export function doDelete(data: any) {
  return request({
    url: '/system/syslog/sysexlog/doDelete',
    method: 'post',
    data,
  })
}
