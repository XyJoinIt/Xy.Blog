<template>
  <BasicModal v-bind="$attrs" @register="registerModal" :title="getTitle" @ok="handleSubmit">
    <BasicForm @register="registerForm" />
  </BasicModal>
</template>
<script lang="ts">
  import { defineComponent, ref, computed, unref } from 'vue'
  import { BasicModal, useModalInner } from '/@/components/Modal'
  import { BasicForm, useForm } from '/@/components/Form/index'
  import { formSchema } from '../user.data'

  import { TreeList, AddRole, UpdateRole } from '/@/api/sys/org'
  export default defineComponent({
    name: 'DeptModal',
    components: { BasicModal, BasicForm },
    emits: ['success', 'register'],
    setup(_, { emit }) {
      const isUpdate = ref(true)
      let rowId: number
      const [registerForm, { resetFields, setFieldsValue, updateSchema, validate }] = useForm({
        labelWidth: 100,
        baseColProps: { span: 24 },
        schemas: formSchema,
        showActionButtonGroup: false,
      })

      const [registerModal, { setModalProps, closeModal }] = useModalInner(async (data) => {
        resetFields()
        setModalProps({ confirmLoading: false })
        isUpdate.value = !!data?.isUpdate

        const treeData = await TreeList()
        updateSchema({
          field: 'pid',
          componentProps: { treeData },
        })

        if (unref(isUpdate)) {
          rowId = data.record.id
          setFieldsValue({
            ...data.record,
          })
        }
      })

      const getTitle = computed(() => (!unref(isUpdate) ? '新增部门' : '编辑部门'))

      async function handleSubmit() {
        try {
          const values = await validate()
          setModalProps({ confirmLoading: true })

          if (unref(isUpdate)) {
            values.id = rowId
            await UpdateRole(values)
          } else {
            await AddRole(values)
          }

          closeModal()
          emit('success', { isUpdate: unref(isUpdate), values: { ...values, id: rowId } })
        } finally {
          setModalProps({ confirmLoading: false })
        }
      }

      return { registerModal, registerForm, getTitle, handleSubmit }
    },
  })
</script>
