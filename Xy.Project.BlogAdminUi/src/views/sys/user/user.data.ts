import { BasicColumn } from '/@/components/Table'
import { FormSchema } from '/@/components/Table'
import { h } from 'vue'
import { Tag } from 'ant-design-vue'
import { CommonStatus, Gender } from '/@/enums/GlobaEnum'
export const columns: BasicColumn[] = [
  {
    title: '头像',
    dataIndex: 'avatar',
    width: 90,
  },
  {
    title: '账户',
    dataIndex: 'account',
  },
  {
    title: '姓名',
    dataIndex: 'name',
  },
  {
    title: '性别',
    dataIndex: 'sex',
    width: 80,
    customRender: ({ record }) => {
      const status = record.sex
      let color = ''
      switch (status as Gender) {
        case Gender.男:
          color = 'blue'
          break
        case Gender.女:
          color = 'pink'
          break
        default:
          color = 'green'
          break
      }
      const text = status
      return h(Tag, { color: color }, () => text)
    },
  },
  {
    title: '状态',
    dataIndex: 'status',
    width: 80,
    customRender: ({ record }) => {
      const status = record.status
      const enable = status === CommonStatus.正常 ? true : false
      const color = enable ? 'green' : 'red'
      const text = enable ? CommonStatus.正常 : CommonStatus.停用
      return h(Tag, { color: color }, () => text)
    },
  },
  {
    title: '手机',
    dataIndex: 'phone',
  },
  {
    title: '邮箱',
    dataIndex: 'email',
  },
  {
    title: '角色',
    dataIndex: 'order',
  },
]

export const searchFormSchema: FormSchema[] = [
  {
    field: 'name',
    label: '姓名',
    component: 'Input',
    colProps: { span: 8 },
  },
  {
    field: 'status',
    label: '状态',
    component: 'Select',
    componentProps: {
      options: [
        { label: '启用', value: '0' },
        { label: '停用', value: '1' },
      ],
    },
    colProps: { span: 8 },
  },
]

export const formSchema: FormSchema[] = [
  {
    field: 'name',
    label: '部门名称',
    component: 'Input',
    required: true,
  },
  {
    field: 'pid',
    label: '上级部门',
    component: 'TreeSelect',
    defaultValue: 0,
    componentProps: {
      treeDefaultExpandAll: true,
      allowClear: true,
      fieldNames: {
        label: 'title',
        key: 'key',
        value: 'key',
      },
      getPopupContainer: () => document.body,
    },
    required: true,
  },
  {
    field: 'order',
    label: '排序',
    component: 'InputNumber',
    required: true,
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
    required: true,
  },
  {
    label: '备注',
    field: 'remark',
    component: 'InputTextArea',
  },
]
