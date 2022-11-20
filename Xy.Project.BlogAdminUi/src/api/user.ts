import request from '@/utils/request'

export async function login(data: any) {
  return request({
    url: '/login',
    method: 'post',
    data,
  })
}

export async function socialLogin(data: any) {
  return request({
    url: '/socialLogin',
    method: 'post',
    data,
  })
}

export function getUserInfo() {
  return request({
    url: '/userInfo',
    method: 'get',
  })
}

export function logout() {
  return request({
    url: '/logout',
    method: 'get',
  })
}

export function register(data: any) {
  return request({
    url: '/register',
    method: 'post',
    data,
  })
}
