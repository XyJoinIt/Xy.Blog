import request from '@/utils/request'

export function getList(params: any) {
  return request({
    url: '/sysuser/getList',
    method: 'get',
    params,
  })
}

export function doEdit(data: any) {
  return request({
    url: '/sysuser/doEdit',
    method: 'post',
    data,
  })
}

export function doDelete(data: any) {
  return request({
    url: '/sysuser/doDelete',
    method: 'post',
    data,
  })
}
