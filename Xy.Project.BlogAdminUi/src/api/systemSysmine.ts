import request from '@/utils/request'

export function getList(params: any) {
  return request({
    url: '/system/sysmine/getList',
    method: 'get',
    params,
  })
}

export function doEdit(data: any) {
  return request({
    url: '/system/sysmine/doEdit',
    method: 'post',
    data,
  })
}

export function doDelete(data: any) {
  return request({
    url: '/system/sysmine/doDelete',
    method: 'post',
    data,
  })
}
