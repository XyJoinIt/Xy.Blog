<template>
  <div>
    <BasicTable @register="registerTable">
      <template #toolbar>
        <a-button type="primary" v-if="hasPermission(['sysrole:add'])" @click="handleCreate">
          新增角色
        </a-button>
      </template>
      <template #bodyCell="{ column, record }">
        <template v-if="column.key === 'action'">
          <TableAction
            :actions="[
              {
                icon: 'clarity:note-edit-line',
                onClick: handleEdit.bind(null, record),
                auth: 'sysrole:edit',
              },
            ]"
            :dropDownActions="[
              {
                icon: 'ant-design:menu-outlined',
                label: '授权菜单',
                onClick: handleGrantMenu.bind(null, record),
              },
              {
                icon: 'ant-design:delete-outlined',
                color: 'error',
                auth: 'sysrole:delete',
                label: '删除',
                popConfirm: {
                  title: '是否确认删除',
                  placement: 'left',
                  confirm: handleDelete.bind(null, record),
                },
              },
            ]"
          />
        </template>
      </template>
    </BasicTable>
    <GrantMenuDrawer @register="registerGrantMenuDrawer" />
    <RoleDrawer @register="registerDrawer" @success="handleSuccess" />
  </div>
</template>
<script lang="ts">
  import { defineComponent } from 'vue'
  import { BasicTable, useTable, TableAction } from '/@/components/Table'
  import { PateList, DeleteRole } from '/@/api/sys/role'
  import { useDrawer } from '/@/components/Drawer'
  import { usePermission } from '/@/hooks/web/usePermission'
  import { columns, searchFormSchema, orders } from './role.data'
  import RoleDrawer from './RoleDrawer.vue'
  import { useMessage } from '/@/hooks/web/useMessage'
  import GrantMenuDrawer from './GrantMenuDrawer.vue'
  export default defineComponent({
    name: 'RoleManagement',
    components: { BasicTable, TableAction, RoleDrawer, GrantMenuDrawer },
    setup() {
      const [registerDrawer, { openDrawer }] = useDrawer()
      const { createMessage } = useMessage()
      const { hasPermission } = usePermission()
      const [registerGrantMenuDrawer, { openDrawer: openGrantMenuDrawer }] = useDrawer()
      const [registerTable, { reload }] = useTable({
        title: '角色列表',
        api: PateList,
        columns,
        formConfig: {
          labelWidth: 120,
          schemas: searchFormSchema,
        },
        orders: orders,
        useSearchForm: true,
        isSimSearch: true, //加上这个参数那么查询的时候就会组装参数
        rowKey: 'id',
        showTableSetting: true,
        bordered: true,
        showIndexColumn: false,
        actionColumn: {
          width: 80,
          title: '操作',
          dataIndex: 'action',
          fixed: undefined,
        },
      })

      //新增
      function handleCreate() {
        openDrawer(true, {
          isUpdate: false,
        })
      }

      //编辑
      function handleEdit(record: Recordable) {
        openDrawer(true, {
          record,
          isUpdate: true,
        })
      }

      //删除
      async function handleDelete(record: Recordable) {
        if (await DeleteRole(record.id)) {
          handleSuccess()
          createMessage.success('删除成功')
        }
      }

      function handleGrantMenu(record: Recordable) {
        openGrantMenuDrawer(true, { record })
      }

      function handleSuccess() {
        reload()
      }

      return {
        handleGrantMenu,
        registerGrantMenuDrawer,
        registerTable,
        registerDrawer,
        handleCreate,
        handleEdit,
        handleDelete,
        handleSuccess,
        hasPermission,
      }
    },
  })
</script>
