const { Random } = require('mockjs')
const tokens = {
  admin: `admin-token-${Random.guid()}-${new Date().getTime()}`,
  editor: `editor-token-${Random.guid()}-${new Date().getTime()}`,
  test: `test-token-${Random.guid()}-${new Date().getTime()}`,
}
const username2role = {
  admin: ['Admin'],
  editor: ['Editor'],
  test: ['Admin', 'Editor'],
}
const role2permission = {
  Admin: ['read:system', 'write:system', 'delete:system'],
  Editor: ['read:system', 'write:system'],
  Test: ['read:system'],
}

module.exports = [
  {
    url: '/login',
    type: 'post',
    response(config) {
      const { username } = config.body
      const token = tokens[username]
      if (!token)
        return {
          code: 500,
          msg: '帐户或密码不正确',
        }
      return {
        code: 200,
        msg: 'success',
        data: { token },
      }
    },
  },
  {
    url: '/register',
    type: 'post',
    response() {
      return {
        code: 200,
        msg: '模拟注册成功',
        data: { token: tokens['editor'] },
      }
    },
  },
  {
    url: '/userInfo',
    type: 'get',
    response(config) {
      const authorization =
        config.headers.authorization || config.headers.Authorization
      if (!authorization.startsWith('Bearer '))
        return {
          code: 401,
          msg: '令牌无效',
        }
      const _authorization = authorization.replace('Bearer ', '')
      const isTrue = _authorization.includes('-token-')
      const username = isTrue ? _authorization.split('-token-')[0] : 'admin'
      const roles = username2role[username] || []
      const permissions = [
        ...new Set(roles.flatMap((role) => role2permission[role])),
      ]

      return {
        code: 200,
        msg: 'success',
        data: {
          username,
          roles,
          permissions,
          avatar: 'https://i.gtimg.cn/club/item/face/img/2/16022_100.gif',
        },
      }
    },
  },
  {
    url: '/logout',
    type: 'get',
    response() {
      return {
        code: 200,
        msg: 'success',
      }
    },
  },
]
