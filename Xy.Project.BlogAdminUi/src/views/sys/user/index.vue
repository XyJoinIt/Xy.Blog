<template>
  <div>
    <Row>
      <Col :span="5">
        <OrgTree @select="handleSelect" />
      </Col>
      <Col :span="19">
        <BasicTable @register="registerTable">
          <template #toolbar>
            <a-button type="primary" @click="handleCreate"> 新增用户</a-button>
          </template>
          <template #bodyCell="{ column, record }">
            <template v-if="column.key === 'action'">
              <TableAction
                :actions="[
                  {
                    icon: 'ant-design:info-circle-outlined',
                    tooltip: '查看详情',
                    onClick: handleEdit.bind(null, record),
                  },
                  {
                    icon: 'clarity:note-edit-line',
                    tooltip: '编辑用户',
                    onClick: handleEdit.bind(null, record),
                  },
                ]"
                :dropDownActions="[
                  {
                    icon: 'ant-design:menu-outlined',
                    label: '授权角色',
                    onClick: handleGrantRole.bind(null, record),
                  },
                  {
                    icon: 'ant-design:redo-outlined',
                    label: '所属部门',
                    onClick: handleEdit.bind(null, record),
                  },
                  {
                    icon: 'ant-design:delete-outlined',
                    color: 'error',
                    label: '删除账号',
                    //ifShow: hasPermission('sysUser:delete'),
                    popConfirm: {
                      title: '是否确认删除',
                      confirm: handleDelete.bind(null, record),
                    },
                  },
                ]"
              />
            </template>
            <template v-else-if="column.key === 'avatar'">
              <Avatar :size="30" :src="record.avatar" :alt="record.account" />
            </template>
          </template>
        </BasicTable>
        <DeptModal @register="registerModal" @success="handleSuccess" />
        <GrantRoleDrawer @register="openUserRoleModal" @success="handleSuccess" />
      </Col>
    </Row>
  </div>
</template>
<script lang="ts">
  import { defineComponent, ref, onMounted } from 'vue'
  import { Row, Col, Avatar } from 'ant-design-vue'
  import { BasicTable, useTable, TableAction } from '/@/components/Table'
  import { TreeItem, TreeActionType } from '/@/components/Tree/index'
  import { useModal } from '/@/components/Modal'
  import DeptModal from './components/UserModal.vue'
  import GrantRoleDrawer from './components/GrantRoleDrawer.vue'
  import { PageList } from '/@/api/sys/user'
  import { columns, searchFormSchema } from './user.data'
  import { FetchParams } from '/@/components/Table'
  import OrgTree from '../org/OrgTree.vue'

  export default defineComponent({
    name: 'UserManagement',
    components: { BasicTable, DeptModal, TableAction, Row, Col, OrgTree, Avatar, GrantRoleDrawer },
    setup() {
      const treeRef = ref<Nullable<TreeActionType>>(null)
      const treeData = ref<TreeItem[]>([])
      const [registerModal, { openModal }] = useModal()
      const [openUserRoleModal, { openModal: openGrantRoleDrawer }] = useModal()
      const [registerTable, { reload }] = useTable({
        title: '用户列表',
        api: PageList,
        columns,
        formConfig: {
          labelWidth: 120,
          schemas: searchFormSchema,
        },
        striped: false,
        useSearchForm: true,
        pagination: true,
        rowKey: 'Id',
        showTableSetting: true,
        bordered: true,
        showIndexColumn: false,
        resizeHeightOffset: 40,
        actionColumn: {
          width: 120,
          title: '操作',
          dataIndex: 'action',
          fixed: undefined,
        },
      })

      onMounted(() => {})

      function handleCreate() {
        openModal(true, {
          isUpdate: false,
        })
      }

      function handleEdit(record: Recordable) {
        openModal(true, {
          record,
          isUpdate: true,
        })
      }

      function handleDelete(record: Recordable) {
        console.log(record)
      }

      function handleSuccess() {
        reload()
      }

      function handleSelect(keys, obj) {
        if (obj == undefined) return
        console.log(keys, obj)

        reload({ searchInfo: { pid: keys } } as FetchParams)
      }

      function handleGrantRole(record: Recordable) {
        openGrantRoleDrawer(true, { record })
      }

      return {
        treeRef,
        treeData,
        handleSelect,
        registerTable,
        registerModal,
        handleCreate,
        handleEdit,
        handleDelete,
        handleSuccess,
        openUserRoleModal,
        handleGrantRole,
      }
    },
  })
</script>
