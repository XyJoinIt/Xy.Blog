<template>
  <div class="m-4 mt-5 mr-1 overflow-hidden bg-white">
    <Card style="padding: 0">
      <BasicTree
        title="机构列表"
        toolbar
        search
        :clickRowToExpand="true"
        :treeData="treeData"
        :fieldNames="{ key: 'key', title: 'title' }"
        @select="handleSelect"
        ref="treeAction"
      />
    </Card>
  </div>
</template>
<script lang="ts">
  import { defineComponent, onMounted, ref, unref, nextTick } from 'vue'
  import { BasicTree, TreeActionType, TreeItem } from '/@/components/Tree/index'
  import { Card } from 'ant-design-vue'
  import { TreeList } from '/@/api/sys/org'

  export default defineComponent({
    name: 'OrgTree',
    components: { BasicTree, Card },

    emits: ['select'],
    setup(_, { emit }) {
      const treeData = ref<TreeItem[]>([])
      const treeAction = ref<Nullable<TreeActionType>>(null)

      async function fetch() {
        treeData.value = (await TreeList()) as unknown as TreeItem[]
        nextTick(() => {
          unref(treeAction)?.filterByLevel(2)
        })
      }

      function handleSelect(keys, obj) {
        if (obj == undefined) return
        else emit('select', keys[0], obj.selectedNodes[0])
      }

      onMounted(() => {
        fetch()
      })
      return {
        treeData,
        handleSelect,
        treeAction,
        // appendNodeByKey,
        // updateNodeByKey,
        // deleteNodeByKey,
        fetch,
      }
    },
  })
</script>
