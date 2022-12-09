<template>
  <div>
    <Row>
      <Col :span="5">
        <div class="m-4 mt-5 mr-1 overflow-hidden bg-white">
          <BasicTree
            class="p-4"
            title="系统部门机构"
            :treeData="treeData"
            ref="treeRef"
            @select="handleSelect"
          />
        </div>
      </Col>
      <Col :span="19">
        <BasicTable @register="registerTable">
          <template #toolbar>
            <a-button type="primary" @click="handleCreate"> 新增部门 </a-button>
          </template>
          <template #bodyCell="{ column, record }">
            <template v-if="column.key === 'action'">
              <TableAction
                :actions="[
                  {
                    icon: 'clarity:note-edit-line',
                    onClick: handleEdit.bind(null, record),
                  },
                  {
                    icon: 'ant-design:delete-outlined',
                    color: 'error',
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
        <DeptModal @register="registerModal" @success="handleSuccess" />
      </Col>
    </Row>
  </div>
</template>
<script lang="ts">
  import { defineComponent, ref, unref, onMounted, nextTick } from 'vue'
  import { Row, Col } from 'ant-design-vue'
  import { BasicTable, useTable, TableAction } from '/@/components/Table'
  import { BasicTree, TreeItem, TreeActionType } from '/@/components/Tree/index'
  import { useModal } from '/@/components/Modal'
  import DeptModal from './OrgModal.vue'
  import { TreeList, PateList } from '/@/api/sys/org'
  import { columns, searchFormSchema } from './org.data'
  import { FetchParams } from '/@/components/Table'
  export default defineComponent({
    name: 'OrgManagement',
    components: { BasicTable, DeptModal, TableAction, Row, Col, BasicTree },
    setup() {
      const treeRef = ref<Nullable<TreeActionType>>(null)
      const treeData = ref<TreeItem[]>([])
      const [registerModal, { openModal }] = useModal()
      const [registerTable, { reload }] = useTable({
        title: '部门列表',
        api: PateList,
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
        canResize: false,
        actionColumn: {
          width: 80,
          title: '操作',
          dataIndex: 'action',
          fixed: undefined,
        },
      })

      onMounted(() => {
        fetch()
      })

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
        fetch()
      }

      async function fetch() {
        treeData.value = (await TreeList()) as unknown as TreeItem[]
        nextTick(() => {
          unref(treeRef)?.filterByLevel(2)
        })
      }

      function handleSelect(keys, obj) {
        if (obj == undefined) return
        console.log(keys[0], obj.selectedNodes[0])

        reload({ searchInfo: { pid: keys[0] } } as FetchParams)
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
      }
    },
  })
</script>
