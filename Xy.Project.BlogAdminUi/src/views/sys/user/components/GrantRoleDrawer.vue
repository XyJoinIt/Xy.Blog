<template>
  <BasicModal
    v-bind="$attrs"
    @register="registerModal"
    :title="'授权角色'"
    @ok="handleSubmit"
    :draggable="true"
    :height="600"
    :width="900"
  >
    <div style="width: 100%">
      <Transfer
        v-model:target-keys="targetKeys"
        v-model:data-source="RoleData"
        :disabled="disabled"
        :show-search="true"
        :titles="['全部角色', '当前角色']"
        :filter-option="(inputValue, item) => item.title!.indexOf(inputValue) !== -1"
        :show-select-all="false"
        :operations="['新增', '移除']"
        @change="onChange"
      >
        <template
          #children="{
            direction,
            filteredItems,
            selectedKeys,
            disabled: listDisabled,
            onItemSelectAll,
            onItemSelect,
          }"
        >
          <Table
            :row-selection="
              getRowSelection({
                disabled: listDisabled,
                selectedKeys,
                onItemSelectAll,
                onItemSelect,
              })
            "
            ,
            :columns="direction === 'left' ? leftColumns : rightColumns"
            :data-source="filteredItems"
            size="small"
            :style="{ pointerEvents: listDisabled ? 'none' : null }"
            :custom-row="
              ({ key, disabled: itemDisabled }) => ({
                onClick: () => {
                  if (itemDisabled || listDisabled) return
                  onItemSelect(key, !selectedKeys.includes(key))
                },
              })
            "
          />
        </template>
      </Transfer>
    </div>
  </BasicModal>
</template>
<script lang="ts">
  import { defineComponent, reactive, ref, toRefs, unref } from 'vue'
  import { BasicModal, useModalInner } from '/@/components/Modal'
  import { Transfer, Table } from 'ant-design-vue'
  import { RoleList } from '/@/api/sys/role'
  import { GetUserRoleList, GrantUserRole } from '/@/api/sys/userRole'
  //格式需要
  interface RoleData {
    key: string
    title: string
    description: string
    disabled: boolean
  }
  type tableColumn = Record<string, string>
  export default defineComponent({
    name: 'DeptModal',
    components: { BasicModal, Transfer, Table },
    emits: ['success', 'register'],
    setup(_, { emit }) {
      const isUpdate = ref(true)
      let rowId: number
      const state = reactive({
        //系统选中的数据
        originTargetKeys: [] as string[],
        //更改的数据
        nextTargetKeys: [] as string[],
        //角色集合
        RoleData: [] as RoleData[],
      })
      const [registerModal, { setModalProps, closeModal }] = useModalInner(async (data) => {
        setModalProps({ confirmLoading: false })
        isUpdate.value = !!data?.isUpdate
        if (unref(isUpdate)) {
          rowId = data.record.id
          //state.originTargetKeys = []
          state.RoleData = [] as RoleData[]
          //角色集合
          RoleList().then((res) => {
            res.forEach((element) => {
              state.RoleData.push({
                key: String(element.id),
                title: element.name,
                description: element.remark,
                disabled: false,
              })
            })
          })

          GetUserRoleList(rowId)
            .then((res) => {
              console.log(res)
              state.originTargetKeys.splice(0)
              res.forEach((element) => {
                console.log(String(element.id))
                state.originTargetKeys.push(String(element.id))
              })
            })
            .catch(() => {})
        }
      })

      async function handleSubmit() {
        try {
          setModalProps({ confirmLoading: true })

          if (unref(isUpdate)) {
            //授权角色
            GrantUserRole(rowId, state.nextTargetKeys.map(Number))
          } else {
            console.log(rowId)
          }

          closeModal()
          emit('success', { isUpdate: unref(isUpdate), values: { id: rowId } })
        } finally {
          setModalProps({ confirmLoading: false })
        }
      }

      const leftTableColumns = [
        {
          dataIndex: 'title',
          title: '角色名',
        },
        {
          dataIndex: 'description',
          title: '备注',
        },
      ]
      const rightTableColumns = [
        {
          dataIndex: 'title',
          title: '角色名',
        },
        {
          dataIndex: 'description',
          title: '备注',
        },
      ]

      const targetKeys = ref<string[]>(state.originTargetKeys)
      const disabled = ref<boolean>(false)
      const showSearch = ref<boolean>(false)
      const leftColumns = ref<tableColumn[]>(leftTableColumns)
      const rightColumns = ref<tableColumn[]>(rightTableColumns)

      const onChange = (nextTargetKeys: string[]) => {
        state.nextTargetKeys = nextTargetKeys
      }

      const getRowSelection = ({
        disabled,
        selectedKeys,
        onItemSelectAll,
        onItemSelect,
      }: Record<string, any>) => {
        return {
          getCheckboxProps: (item: Record<string, string | boolean>) => ({
            disabled: disabled || item.disabled,
          }),
          onSelectAll(selected: boolean, selectedRows: Record<string, string | boolean>[]) {
            const treeSelectedKeys = selectedRows
              .filter((item) => !item.disabled)
              .map(({ key }) => key)
            onItemSelectAll(treeSelectedKeys, selected)
          },
          onSelect({ key }: Record<string, string>, selected: boolean) {
            onItemSelect(key, selected)
          },
          selectedRowKeys: selectedKeys,
        }
      }

      return {
        ...toRefs(state),
        registerModal,
        handleSubmit,
        targetKeys,
        disabled,
        showSearch,
        leftColumns,
        rightColumns,
        onChange,
        getRowSelection,
      }
    },
  })
</script>
