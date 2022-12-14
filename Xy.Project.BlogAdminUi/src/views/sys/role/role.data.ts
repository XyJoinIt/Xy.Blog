import { BasicColumn, OrderProps } from '/@/components/Table'
import { FormSchema } from '/@/components/Table'
import { h } from 'vue'
import { Switch } from 'ant-design-vue'
import { SetRoleStart } from '/@/api/sys/role'
import { useMessage } from '/@/hooks/web/useMessage'
import { CommonStatus, FilterOperator, OrderDirection } from '/@/enums/GlobaEnum'
import { OrderCondition } from '/@/api/model/baseModel'

export const columns: BasicColumn[] = [
  {
    title: '角色名称',
    dataIndex: 'name',
    width: 200,
  },
  {
    title: '角色值',
    dataIndex: 'code',
    width: 180,
  },
  {
    title: '排序',
    dataIndex: 'sort',
    width: 50,
  },
  {
    title: '状态',
    dataIndex: 'status',
    width: 120,

    customRender: ({ record }) => {
      if (!Reflect.has(record, 'pendingStatus')) {
        record.pendingStatus = false
      }
      return h(Switch, {
        checked: record.status === '正常',
        checkedChildren: '正常',
        unCheckedChildren: '停用',
        loading: record.pendingStatus,
        onChange(checked: boolean) {
          const newStatus = checked ? '正常' : '停用'
          console.log(newStatus)
          const { createMessage } = useMessage()
          SetRoleStart(record.id)
            .then(() => {
              record.status = newStatus
              createMessage.success(`已成功修改角色状态`)
            })
            .catch(() => {
              createMessage.error('修改角色状态失败')
            })
            .finally(() => {
              record.pendingStatus = false
            })
        },
      })
    },
  },
  {
    title: '创建时间',
    dataIndex: 'createTime',
    width: 180,
  },
  {
    title: '备注',
    dataIndex: 'remark',
  },
]

export const searchFormSchema: FormSchema[] = [
  {
    field: 'name',
    label: '角色名称',
    component: 'Input',
    colProps: { span: 8 },
    filterOperator: FilterOperator.Contains
  },
  {
    field: 'status',
    label: '状态',
    component: 'Select',
    componentProps: {
      options: [
        { label: '启用', value: CommonStatus.正常 },
        { label: '停用', value: CommonStatus.停用 },
      ],
    },
    colProps: { span: 8 },
    filterOperator: FilterOperator.Equal
  },
]

export const formSchema: FormSchema[] = [
  {
    field: 'name',
    label: '角色名称',
    required: true,
    component: 'Input',
    colProps: { span: 24 },
  },
  {
    field: 'code',
    label: '角色值',
    required: true,
    component: 'Input',
    colProps: { span: 24 },
  },
  {
    field: 'status',
    label: '状态',
    component: 'RadioButtonGroup',
    defaultValue: CommonStatus.正常,
    componentProps: {
      options: [
        { label: '启用', value: CommonStatus.正常 },
        { label: '停用', value: CommonStatus.停用 },
      ],
    },
  },
  {
    label: '备注',
    field: 'remark',
    component: 'InputTextArea',
    colProps: { span: 24 },
  },
]

export const orders: OrderProps[] = [
  {
    sortField: "Id",
    sortDirection: OrderDirection.Ascending
  }

]