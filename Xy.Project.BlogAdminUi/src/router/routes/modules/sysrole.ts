import type { AppRouteModule } from '/@/router/types'

import { LAYOUT } from '/@/router/constant'
import { t } from '/@/hooks/web/useI18n'

const sysrole: AppRouteModule = {
  path: '/system',
  name: 'System',
  component: LAYOUT,
  redirect: '/system/role',
  meta: {
    orderNo: 100,
    icon: 'ion:settings-outline',
    title: t('routes.sys.system'),
  },
  children: [
    {
      path: 'role',
      name: 'RoleManagement',
      component: () => import('/@/views/sys/role/index.vue'),
      meta: {
        title: t('routes.sys.role'),
        ignoreKeepAlive: true,
      },
    },
  ],
}

export default sysrole
