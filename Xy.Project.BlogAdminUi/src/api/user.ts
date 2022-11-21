import request from '@/utils/request'

/**
 * @description 登录
 * @author Xy 2377853937@qq.com
 * @export
 * @param {*} data
 * @return {*}
 */
export async function login(data: any) {
  return request({
    url: '/api/Identity/Login',
    method: 'post',
    data,
  })
}

/**
 * @description
 * @author Xy 2377853937@qq.com
 * @export
 * @param {*} data
 * @return {*}
 */
export async function socialLogin(data: any) {
  return request({
    url: '/socialLogin',
    method: 'post',
    data,
  })
}

/**
 * @description 获取用户信息
 * @author Xy 2377853937@qq.com
 * @export
 * @return {*}
 */
export function getUserInfo() {
  return request({
    url: '/api/SysUse/GetUserInfo',
    method: 'get',
  })
}

/**
 * @description 退出登录
 * @author Xy 2377853937@qq.com
 * @export
 * @return {*}
 */
export function logout() {
  return request({
    url: '/api/SysUse/LoginOut',
    method: 'get',
  })
}

/**
 * @description
 * @author Xy 2377853937@qq.com
 * @export
 * @param {*} data
 * @return {*}
 */
export function register(data: any) {
  return request({
    url: '/register',
    method: 'post',
    data,
  })
}
