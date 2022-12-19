<template>
  <BasicDrawer
    v-bind="$attrs"
    @register="registerDrawer"
    showFooter
    title="授权角色菜单"
    width="500px"
    @ok="handleSubmit"
  >
    <BasicForm @register="registerForm">
      <template #menu>
        <BasicTree
          :treeData="treeData"
          :fieldNames="{ title: 'name', key: 'id' }"
          :checkedKeys="ownMenuData"
          checkable
          toolbar
          search
          title="菜单列表"
          ref="treeAction"
          @check="handleCheck"
        />
      </template>
    </BasicForm>
  </BasicDrawer>
</template>
<script lang="ts">
  import { defineComponent, ref, unref, nextTick } from 'vue'
  import { BasicForm, useForm } from '/@/components/Form/index'
  import { BasicDrawer, useDrawerInner } from '/@/components/Drawer'
  import { BasicTree, TreeItem, TreeActionType } from '/@/components/Tree'

  //import { getMenuList, ownMenuList, grantRoleMenu } from '/@/api/sys/admin'
  import { GetMenuList } from '/@/api/sys/menu'
  import { GetRoleMenuByRoleId, grantRoleMenu } from '/@/api/sys/roleMenu'
  export default defineComponent({
    name: 'GrantMenuDrawer',
    components: { BasicDrawer, BasicForm, BasicTree },
    emits: ['success', 'register'],
    setup(_, { emit }) {
      const treeData = ref<TreeItem[]>([])
      let rowId: number
      const ownMenuData = ref<number[]>([])
      const treeAction = ref<Nullable<TreeActionType>>(null)
      let checkKeys: number[] = [] // 子节点集合(勾选)
      let halfCheckKeys: number[] = [] // 父节点集合(半勾选)

      const [registerForm, { validate }] = useForm({
        labelWidth: 90,
        schemas: [
          {
            label: ' ',
            field: 'menu',
            slot: 'menu',
            component: 'Input',
          },
        ],
        showActionButtonGroup: false,
      })

      const [registerDrawer, { setDrawerProps, closeDrawer }] = useDrawerInner(async (data) => {
        setDrawerProps({ confirmLoading: false })

        if (unref(treeData).length === 0) {
          treeData.value = []
          treeData.value = (await GetMenuList()) as any as TreeItem[]
          nextTick(() => {
            unref(treeAction)?.filterByLevel(1)
          })
        }

        rowId = data.record.id
        var menuTree = await GetRoleMenuByRoleId(rowId)
        checkKeys = []
        halfCheckKeys = []
        handleKeys(menuTree)
        ownMenuData.value = checkKeys
      })

      // 节点勾选事件
      function handleCheck(_checkedKeys, e) {
        checkKeys = _checkedKeys
        halfCheckKeys = e.halfCheckedKeys
      }

      async function handleSubmit() {
        try {
          const values = await validate()
          setDrawerProps({ confirmLoading: true })

          values.SysMenuIds = checkKeys.concat(halfCheckKeys) // 将勾选和半勾选节点合并
          values.SysRoleId = rowId
          await grantRoleMenu(values)

          closeDrawer()
          emit('success')
        } finally {
          setDrawerProps({ confirmLoading: false })
        }
      }

      // 递归遍历树区分父子节点集合
      function handleKeys(menuTree: any[]) {
        menuTree.map((item) => {
          if (item.children && item.children.length > 0) {
            halfCheckKeys.push(item.id)
            handleKeys(item.children)
          } else {
            checkKeys.push(item.id)
          }
        })
      }

      return {
        registerDrawer,
        registerForm,
        handleSubmit,
        treeData,
        ownMenuData,
        treeAction,
        handleCheck,
      }
    },
  })
</script>
