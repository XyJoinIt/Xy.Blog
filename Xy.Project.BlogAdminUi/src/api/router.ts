import request from '@/utils/request'

export function getList() {
  return request({
    url: '/router/getList',
    method: 'get',
  })
}
