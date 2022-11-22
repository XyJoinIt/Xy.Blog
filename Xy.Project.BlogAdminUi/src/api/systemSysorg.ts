import request from '@/utils/request'

export function getList(params: any) {
  return request({
    url: '/system/sysorg/getList',
    method: 'get',
    params,
  })
}

export function doEdit(data: any) {
  return request({
    url: '/system/sysorg/doEdit',
    method: 'post',
    data,
  })
}

export function doDelete(data: any) {
  return request({
    url: '/system/sysorg/doDelete',
    method: 'post',
    data,
  })
}
