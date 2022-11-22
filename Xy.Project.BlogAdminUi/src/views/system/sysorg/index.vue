<template>
  <div class="card-container">
    <el-row>
      <el-col :span="5">
        <vab-card class="cardImp" :skeleton="true">
          <el-tree
            :data="data"
            default-expanded-keys="[1]"
            node-key="id"
            :props="defaultProps"
            @node-click="handleNodeClick"
          />
        </vab-card>
      </el-col>
      <el-col :span="19">
        <vab-query-form class="page-header">
          <vab-query-form-top-panel :span="24">
            <el-form inline :model="queryForm" @submit.prevent>
              <el-form-item label="组织名称：">
                <el-input
                  v-model="queryForm.title"
                  placeholder="请输入名称..."
                />
              </el-form-item>
              <el-form-item>
                <el-button native-type="submit" type="primary">查询</el-button>
              </el-form-item>
            </el-form>
          </vab-query-form-top-panel>
        </vab-query-form>
        <vab-card :skeleton="true">
          <el-table
            v-loading="listLoading"
            :data="list"
            @selection-change="setSelectRows"
          >
            <el-table-column
              align="center"
              show-overflow-tooltip
              type="selection"
            />
            <el-table-column
              align="center"
              label="id"
              prop="id"
              show-overflow-tooltip
            />
            <el-table-column
              align="center"
              label="标题"
              prop="title"
              show-overflow-tooltip
            />
            <el-table-column align="center" label="操作" width="200">
              <template #default="{ row }">
                <el-button text @click="handleEdit(row)">编辑</el-button>
                <el-button text @click="handleDelete(row)">删除</el-button>
              </template>
            </el-table-column>
          </el-table>
          <el-pagination
            background
            :current-page="queryForm.pageNo"
            :layout="layout"
            :page-size="queryForm.pageSize"
            :total="total"
            @current-change="handleCurrentChange"
            @size-change="handleSizeChange"
          />
          <edit ref="editRef" @fetch-data="fetchData" />
        </vab-card>
      </el-col>
    </el-row>
  </div>
</template>

<script lang="ts">
  import Edit from './components/SystemSysorgEdit.vue'
  // import { getList } from '@/api/table'
  //import { Search } from '@element-plus/icons-vue'

  interface Tree {
    label: string
    id: number
    children?: Tree[]
  }
  export default defineComponent({
    name: 'Card',
    components: { Edit },
    setup() {
      //const $baseConfirm = inject('$baseConfirm')
      //const $baseMessage = inject('$baseMessage')
      const state = reactive({
        editRef: null,
        list: [],
        total: 0,
        listLoading: true,
        queryForm: { pageNo: 1, pageSize: 20, title: '' },
        layout: 'total, sizes, prev, pager, next, jumper',
        emptyShow: true,
        selectRows: '',
      })

      const setSelectRows = (val: string) => {
        state.selectRows = val
      }
      const handleEdit = (row: { id: any }) => {
        console.log(row)
      }
      const handleDelete = (row: { id: any }) => {
        console.log(row)
      }
      const handleSizeChange = (val: number) => {
        state.queryForm.pageSize = val
        fetchData()
      }
      const handleCurrentChange = (val: number) => {
        state.queryForm.pageNo = val
        fetchData()
      }
      const queryData = () => {
        state.queryForm.pageNo = 1
        fetchData()
      }
      const fetchData = async () => {
        state.listLoading = true
        // const {
        //   data: { list, total },
        // } = await getList(state.queryForm)
        state.list = []
        state.total = 2
        state.listLoading = false
      }
      onMounted(() => {
        fetchData()
      })

      const handleNodeClick = (data: Tree) => {
        console.log(data)
      }

      const data: Tree[] = [
        {
          label: '平台管理',
          id: 1,
          children: [
            {
              label: '博客平台',
              id: 2,
            },
            {
              label: '商城平台',
              id: 3,
            },
            {
              label: '服务平台',
              id: 4,
            },
          ],
        },
      ]

      const defaultProps = {
        children: 'children',
        label: 'label',
      }
      return {
        ...toRefs(state),
        defaultProps,
        data,
        handleNodeClick,
        setSelectRows,
        handleEdit,
        handleDelete,
        handleSizeChange,
        handleCurrentChange,
        queryData,
        fetchData,
      }
    },
  })
</script>

<style lang="scss" scoped>
  .card-container {
    padding: 0 0 $base-padding 0 !important;
    background: $base-color-background !important;
    .cardImp {
      margin-right: 10px;
    }
    .ant-form-item {
      margin-bottom: 0 !important;
    }
    .primaryAdd {
      margin-right: 10px;
    }
    .snowy-buttom-left {
      margin-left: 8px;
    }
    .page-header {
      display: flex;
      align-items: center;
      padding: $base-padding $base-padding 0 $base-padding;
      margin-bottom: $base-margin;
      background: var(--el-color-white);
      border: 1px solid #ebeef5;

      :deep() {
        .el-form-item__content {
          width: 221px !important;

          .el-select,
          .el-input,
          .el-date-editor,
          .el-checkbox-group {
            width: 100%;
          }
        }
      }
    }

    :deep() {
      .el-card {
        &__body {
          position: relative;
          padding: $base-padding;
          cursor: pointer;

          img {
            height: 228px;
          }

          .card-title {
            margin: $base-margin $base-margin 10px $base-margin;
            font-size: 16px;
            font-weight: bold;
          }

          .card-description {
            margin: 0 $base-margin 10px $base-margin;
          }

          .card-datetime {
            margin: 0 $base-margin 10px $base-margin;
            color: rgba($base-color-black, 0.6);
          }
        }
      }

      .el-pagination.is-background {
        .btn-next,
        .btn-prev {
          background-color: var(--el-color-white);
        }

        .el-pager {
          li {
            background-color: var(--el-color-white);

            &.active {
              background-color: var(--el-color-primary);
            }
          }
        }
      }
    }
  }
</style>
