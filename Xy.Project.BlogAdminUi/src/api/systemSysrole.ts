import request from '@/utils/request'

export function getList(params: any) {
  return request({
    url: '/system/sysrole/getList',
    method: 'get',
    params,
  })
}

export function doEdit(data: any) {
  return request({
    url: '/system/sysrole/doEdit',
    method: 'post',
    data,
  })
}

export function doDelete(data: any) {
  return request({
    url: '/system/sysrole/doDelete',
    method: 'post',
    data,
  })
}
