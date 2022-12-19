import { BasicColumn } from '/@/components/Table'
import { FormSchema } from '/@/components/Table'
import { h } from 'vue'
import { Tag } from 'ant-design-vue'
import { CommonStatus, Gender } from '/@/enums/GlobaEnum'
export const columns: BasicColumn[] = [
  {
    title: '账户',
    dataIndex: 'account',
    fixed: 'left',
  },
  {
    title: '头像',
    dataIndex: 'avatar',
    width: 90,
  },

  {
    title: '姓名',
    dataIndex: 'name',
  },
  {
    title: '昵称',
    dataIndex: 'nickName',
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
    title: '生日',
    dataIndex: 'birthday',
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
    field: 'account',
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

// export const formSchema: FormSchema[] = [
//   {
//     field: 'account',
//     label: '账户',
//     component: 'Input',
//     required: true,
//   },
//   {
//     field: 'Password',
//     label: '密码',
//     component: 'Input',
//     required: true,
//   },
//   {
//     field: 'pid',
//     label: '上级部门',
//     component: 'TreeSelect',
//     defaultValue: 0,
//     componentProps: {
//       treeDefaultExpandAll: true,
//       allowClear: true,
//       fieldNames: {
//         label: 'title',
//         key: 'key',
//         value: 'key',
//       },
//       getPopupContainer: () => document.body,
//     },
//     required: true,
//   },
//   {
//     field: 'order',
//     label: '排序',
//     component: 'InputNumber',
//     required: true,
//   },
//   {
//     field: 'status',
//     label: '状态',
//     component: 'RadioButtonGroup',
//     defaultValue: CommonStatus.正常,
//     componentProps: {
//       options: [
//         { label: '启用', value: CommonStatus.正常 },
//         { label: '停用', value: CommonStatus.停用 },
//       ],
//     },
//     required: true,
//   },
//   {
//     label: '备注',
//     field: 'remark',
//     component: 'InputTextArea',
//   },
// ]

export const formSchema: FormSchema[] = [
  {
    field: 'userName',
    label: '用户名',
    component: 'Input',
    required: true,
    colProps: { span: 12 },
  },
  {
    field: 'nickName',
    label: '昵称',
    component: 'Input',
    colProps: { span: 12 },
  },
  {
    field: 'realName',
    label: '真实姓名',
    component: 'Input',
    required: true,
    colProps: { span: 12 },
  },
  {
    field: 'birthday',
    label: '出生日期',
    component: 'DatePicker',
    colProps: { span: 12 },
    componentProps: { style: { width: '100%' } },
  },
  {
    field: 'sex',
    label: '性别',
    component: 'RadioGroup',
    colProps: { span: 12 },
    componentProps: {
      options: [
        {
          label: '男',
          value: 1,
        },
        {
          label: '女',
          value: 2,
        },
      ],
    },
  },
  {
    field: 'phone',
    label: '手机号码',
    component: 'Input',
    colProps: { span: 12 },
    required: true,
  },
  {
    field: 'email',
    label: '邮箱',
    component: 'Input',
    colProps: { span: 12 },
  },
  {
    field: 'idCard',
    label: '证件号码',
    component: 'Input',
    colProps: { span: 12 },
  },
  {
    field: 'signature',
    label: '个性签名',
    component: 'Input',
    colProps: { span: 24 },
  },
  {
    field: 'introduction',
    label: '本人简介',
    component: 'Input',
    colProps: { span: 24 },
  },
  {
    field: 'jobNum',
    label: '工号',
    component: 'Input',
    colProps: { span: 12 },
  },
  {
    field: 'jobStatus',
    label: '岗位状态',
    component: 'Select',
    colProps: { span: 12 },
    componentProps: {
      options: [
        {
          label: '在职',
          value: 1,
          key: 1,
        },
        {
          label: '离职',
          value: 2,
          key: 2,
        },
        {
          label: '请假',
          value: 3,
          key: 3,
        },
      ],
    },
  },
  {
    field: 'remark',
    label: '备注',
    component: 'InputTextArea',
    colProps: { span: 24 },
  },
]
