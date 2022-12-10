import { BasicColumn } from '/@/components/Table'
import { FormSchema } from '/@/components/Table'
import { h } from 'vue'
import { Tag } from 'ant-design-vue'
import { CommonStatus } from '/@/enums/GlobaEnum'
export const columns: BasicColumn[] = [
  {
    title: '部门名称',
    dataIndex: 'name',
    align: 'left',
  },
  {
    title: '排序',
    dataIndex: 'order',
    width: 50,
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
    title: '创建时间',
    dataIndex: 'createTime',
    width: 180,
  },
  {
    title: '备注',
    dataIndex: 'remark',
    width: 280,
  },
]

export const searchFormSchema: FormSchema[] = [
  {
    field: 'name',
    label: '部门名称',
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
