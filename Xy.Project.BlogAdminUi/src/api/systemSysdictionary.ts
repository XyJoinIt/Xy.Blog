import request from '@/utils/request'

export function getList(params: any) {
  return request({
    url: '/system/sysdictionary/getList',
    method: 'get',
    params,
  })
}

export function doEdit(data: any) {
  return request({
    url: '/system/sysdictionary/doEdit',
    method: 'post',
    data,
  })
}

export function doDelete(data: any) {
  return request({
    url: '/system/sysdictionary/doDelete',
    method: 'post',
    data,
  })
}
