<template>
  <BasicModal
    v-bind="$attrs"
    @register="registerModal"
    :title="getTitle"
    @ok="handleSubmit"
    :draggable="true"
    :height="600"
    :width="900"
  >
    <div style="width: 100%">
      <Transfer
        v-model:target-keys="targetKeys"
        :data-source="mockData"
        :disabled="disabled"
        :show-search="true"
        :filter-option="(inputValue, item) => item.title!.indexOf(inputValue) !== -1"
        :show-select-all="false"
        @change="onChange"
        ,
        :one-way="true"
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
          >
            <template #bodyCell="{ column }">
              <template v-if="column.key === 'action'">
                <TableAction
                  :actions="[
                    {
                      icon: 'ant-design:info-circle-outlined',
                      tooltip: '查看详情',
                    },
                  ]"
                />

                <!-- <delete-outlined /> -->
              </template>
            </template>
          </Table>
        </template>
      </Transfer>
    </div>
  </BasicModal>
</template>
<script lang="ts">
  import { defineComponent, ref, unref } from 'vue'
  import { BasicModal, useModalInner } from '/@/components/Modal'
  import { Transfer, Table } from 'ant-design-vue'
  //import { delete-outlined } from 'ant-design-icons'
  import { TableAction } from '/@/components/Table'
  interface MockData {
    key: string
    title: string
    description: string
    disabled: boolean
  }
  type tableColumn = Record<string, string>
  const mockData: MockData[] = []
  for (let i = 0; i < 26; i++) {
    mockData.push({
      key: i.toString(),
      title: `content${i + 1}`,
      description: `description of content${i + 1}`,
      disabled: false,
    })
  }

  const originTargetKeys = mockData.filter((item) => +item.key % 3 > 1).map((item) => item.key)

  const leftTableColumns = [
    {
      dataIndex: 'title',
      title: 'Name',
    },
    {
      dataIndex: 'description',
      title: 'Description',
    },
  ]
  const rightTableColumns = [
    {
      dataIndex: 'title',
      title: 'Name',
    },
    {
      dataIndex: 'description',
      title: 'Description',
    },
    {
      title: 'action',
      dataIndex: 'action',
    },
  ]

  export default defineComponent({
    name: 'DeptModal',
    components: { BasicModal, Transfer, Table, TableAction },
    emits: ['success', 'register'],
    setup(_, { emit }) {
      const isUpdate = ref(true)
      let rowId: number

      const [registerModal, { setModalProps, closeModal }] = useModalInner(async (data) => {
        setModalProps({ confirmLoading: false })
        isUpdate.value = !!data?.isUpdate

        if (unref(isUpdate)) {
          rowId = data.record.id
          console.log(rowId)
        }
      })

      const getTitle = '授权角色'

      async function handleSubmit() {
        try {
          setModalProps({ confirmLoading: true })

          if (unref(isUpdate)) {
            console.log(rowId)
          } else {
            console.log(rowId)
          }

          closeModal()
          emit('success', { isUpdate: unref(isUpdate), values: { id: rowId } })
        } finally {
          setModalProps({ confirmLoading: false })
        }
      }

      const targetKeys = ref<string[]>(originTargetKeys)
      const disabled = ref<boolean>(false)
      const showSearch = ref<boolean>(false)
      const leftColumns = ref<tableColumn[]>(leftTableColumns)
      const rightColumns = ref<tableColumn[]>(rightTableColumns)

      const onChange = (nextTargetKeys: string[]) => {
        console.log('nextTargetKeys', nextTargetKeys)
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
        registerModal,
        getTitle,
        handleSubmit,
        mockData,
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
