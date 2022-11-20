import request from '@/utils/request'

export function getList(params: any) {
  return request({
    url: '/system/sysmenu/getList',
    method: 'get',
    params,
  })
}

export function doEdit(data: any) {
  return request({
    url: '/system/sysmenu/doEdit',
    method: 'post',
    data,
  })
}

export function doDelete(data: any) {
  return request({
    url: '/system/sysmenu/doDelete',
    method: 'post',
    data,
  })
}
