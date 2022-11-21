import request from '@/utils/request'

/**
 * @description 获取分页数据
 * @author Xy 2377853937@qq.com
 * @export
 * @param {*} params
 * @return {*}
 */
export function PateList(data: any) {
  return request({
    url: '/api/Role/PateList',
    method: 'Post',
    data,
  })
}

/**
 * @description 修改
 * @author Xy 2377853937@qq.com
 * @export
 * @param {*} data
 * @return {*}
 */
export function doUpdate(data: any) {
  return request({
    url: '/api/Role/Update',
    method: 'Put',
    data,
  })
}

/**
 * @description 删除
 * @author Xy 2377853937@qq.com
 * @export
 * @param {*} data
 * @return {*}
 */
export function doDelete(data: any) {
  return request({
    url: '/api/Role/Delete',
    method: 'delete',
    data,
  })
}

/**
 * @description 新增
 * @author Xy 2377853937@qq.com
 * @export
 * @param {*} data
 * @return {*}
 */
export function doAdd(data: any) {
  return request({
    url: '/api/Role/Add',
    method: 'Post',
    data,
  })
}
