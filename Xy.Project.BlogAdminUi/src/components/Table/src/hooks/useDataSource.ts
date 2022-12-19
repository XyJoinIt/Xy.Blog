import type { BasicTableProps, FetchParams, SorterResult } from '../types/table'
import type { PaginationProps } from '../types/pagination'
import {
  ref,
  unref,
  ComputedRef,
  computed,
  onMounted,
  watch,
  reactive,
  Ref,
  watchEffect,
} from 'vue'
import { useTimeoutFn } from '/@/hooks/core/useTimeout'
import { buildUUID } from '/@/utils/uuid'
import { isFunction, isBoolean } from '/@/utils/is'
import { get, cloneDeep, merge } from 'lodash-es'
import { FETCH_SETTING, ROW_KEY, PAGE_SIZE } from '../const'
//import { p } from '@antfu/utils'
//import { any } from 'vue-types'
import { FilterOperator } from '/@/enums/GlobaEnum'
import { OrderCondition, PageCondition, PageParam } from '/@/api/model/baseModel'

interface ActionType {
  getPaginationInfo: ComputedRef<boolean | PaginationProps>
  setPagination: (info: Partial<PaginationProps>) => void
  setLoading: (loading: boolean) => void
  getFieldsValue: () => Recordable
  clearSelectedRowKeys: () => void
  tableData: Ref<Recordable[]>
}

interface SearchState {
  sortInfo: Recordable
  filterInfo: Record<string, string[]>
}
export function useDataSource(
  propsRef: ComputedRef<BasicTableProps>,
  {
    getPaginationInfo,
    setPagination,
    setLoading,
    getFieldsValue,
    clearSelectedRowKeys,
    tableData,
  }: ActionType,
  emit: EmitType,
) {
  const searchState = reactive<SearchState>({
    sortInfo: {},
    filterInfo: {},
  })
  const dataSourceRef = ref<Recordable[]>([])
  const rawDataSourceRef = ref<Recordable>({})

  watchEffect(() => {
    tableData.value = unref(dataSourceRef)
  })

  watch(
    () => unref(propsRef).dataSource,
    () => {
      const { dataSource, api } = unref(propsRef)
      !api && dataSource && (dataSourceRef.value = dataSource)
    },
    {
      immediate: true,
    },
  )

  function handleTableChange(
    pagination: PaginationProps,
    filters: Partial<Recordable<string[]>>,
    sorter: SorterResult,
  ) {
    const { clearSelectOnPageChange, sortFn, filterFn } = unref(propsRef)
    if (clearSelectOnPageChange) {
      clearSelectedRowKeys()
    }
    setPagination(pagination)

    const params: Recordable = {}
    if (sorter && isFunction(sortFn)) {
      const sortInfo = sortFn(sorter)
      searchState.sortInfo = sortInfo
      params.sortInfo = sortInfo
    }

    if (filters && isFunction(filterFn)) {
      const filterInfo = filterFn(filters)
      searchState.filterInfo = filterInfo
      params.filterInfo = filterInfo
    }
    fetch(params)
  }

  function setTableKey(items: any[]) {
    if (!items || !Array.isArray(items)) return
    items.forEach((item) => {
      if (!item[ROW_KEY]) {
        item[ROW_KEY] = buildUUID()
      }
      if (item.children && item.children.length) {
        setTableKey(item.children)
      }
    })
  }

  const getAutoCreateKey = computed(() => {
    return unref(propsRef).autoCreateKey && !unref(propsRef).rowKey
  })

  const getRowKey = computed(() => {
    const { rowKey } = unref(propsRef)
    return unref(getAutoCreateKey) ? ROW_KEY : rowKey
  })

  const getDataSourceRef = computed(() => {
    const dataSource = unref(dataSourceRef)
    if (!dataSource || dataSource.length === 0) {
      return unref(dataSourceRef)
    }
    if (unref(getAutoCreateKey)) {
      const firstItem = dataSource[0]
      const lastItem = dataSource[dataSource.length - 1]

      if (firstItem && lastItem) {
        if (!firstItem[ROW_KEY] || !lastItem[ROW_KEY]) {
          const data = cloneDeep(unref(dataSourceRef))
          data.forEach((item) => {
            if (!item[ROW_KEY]) {
              item[ROW_KEY] = buildUUID()
            }
            if (item.children && item.children.length) {
              setTableKey(item.children)
            }
          })
          dataSourceRef.value = data
        }
      }
    }
    return unref(dataSourceRef)
  })

  async function updateTableData(index: number, key: string, value: any) {
    const record = dataSourceRef.value[index]
    if (record) {
      dataSourceRef.value[index][key] = value
    }
    return dataSourceRef.value[index]
  }

  function updateTableDataRecord(
    rowKey: string | number,
    record: Recordable,
  ): Recordable | undefined {
    const row = findTableDataRecord(rowKey)

    if (row) {
      for (const field in row) {
        if (Reflect.has(record, field)) row[field] = record[field]
      }
      return row
    }
  }

  function deleteTableDataRecord(rowKey: string | number | string[] | number[]) {
    if (!dataSourceRef.value || dataSourceRef.value.length == 0) return
    const rowKeyName = unref(getRowKey)
    if (!rowKeyName) return
    const rowKeys = !Array.isArray(rowKey) ? [rowKey] : rowKey
    for (const key of rowKeys) {
      let index: number | undefined = dataSourceRef.value.findIndex((row) => {
        let targetKeyName: string
        if (typeof rowKeyName === 'function') {
          targetKeyName = rowKeyName(row)
        } else {
          targetKeyName = rowKeyName as string
        }
        return row[targetKeyName] === key
      })
      if (index >= 0) {
        dataSourceRef.value.splice(index, 1)
      }
      index = unref(propsRef).dataSource?.findIndex((row) => {
        let targetKeyName: string
        if (typeof rowKeyName === 'function') {
          targetKeyName = rowKeyName(row)
        } else {
          targetKeyName = rowKeyName as string
        }
        return row[targetKeyName] === key
      })
      if (typeof index !== 'undefined' && index !== -1) unref(propsRef).dataSource?.splice(index, 1)
    }
    setPagination({
      total: unref(propsRef).dataSource?.length,
    })
  }

  function insertTableDataRecord(record: Recordable, index: number): Recordable | undefined {
    // if (!dataSourceRef.value || dataSourceRef.value.length == 0) return;
    index = index ?? dataSourceRef.value?.length
    unref(dataSourceRef).splice(index, 0, record)
    return unref(dataSourceRef)
  }

  function findTableDataRecord(rowKey: string | number) {
    if (!dataSourceRef.value || dataSourceRef.value.length == 0) return

    const rowKeyName = unref(getRowKey)
    if (!rowKeyName) return

    const { childrenColumnName = 'children' } = unref(propsRef)

    const findRow = (array: any[]) => {
      let ret
      array.some(function iter(r) {
        if (typeof rowKeyName === 'function') {
          if ((rowKeyName(r) as string) === rowKey) {
            ret = r
            return true
          }
        } else {
          if (Reflect.has(r, rowKeyName) && r[rowKeyName] === rowKey) {
            ret = r
            return true
          }
        }
        return r[childrenColumnName] && r[childrenColumnName].some(iter)
      })
      return ret
    }

    // const row = dataSourceRef.value.find(r => {
    //   if (typeof rowKeyName === 'function') {
    //     return (rowKeyName(r) as string) === rowKey
    //   } else {
    //     return Reflect.has(r, rowKeyName) && r[rowKeyName] === rowKey
    //   }
    // })
    return findRow(dataSourceRef.value)
  }

  async function fetch(opt?: FetchParams) {
    const {
      api,
      searchInfo,
      defSort,
      fetchSetting,
      isSimSearch,
      beforeFetch,
      afterFetch,
      useSearchForm,
      pagination,
      orders,
    } = unref(propsRef)
    if (!api || !isFunction(api)) return
    try {
      setLoading(true)
      const { pageField, sizeField, listField, totalField } = Object.assign(
        {},
        FETCH_SETTING,
        fetchSetting,
      )
      let pageParams: Recordable = {}

      const { current = 1, pageSize = PAGE_SIZE } = unref(getPaginationInfo) as PaginationProps

      if ((isBoolean(pagination) && !pagination) || isBoolean(getPaginationInfo)) {
        pageParams = {}
      } else {
        pageParams[pageField] = (opt && opt.page) || current
        pageParams[sizeField] = pageSize
      }

      const { sortInfo = {}, filterInfo } = searchState

      let params: Recordable = {}

      //待优化代码
      //一个不懂前端的后端程序员想说的话
      //不是专业前端写得代码，以后还会问大黄瓜会不会前端吗？你说我会不会前端？
      //要我到达会到什么程度？看VUE源码吗？还是VUE执行原理 ？
      //不好意思，我只懂.NET,假如要我懂前端的话，我为什么不去做前端？而做.NET呢？
      //大黄瓜是一个垃圾的程序员。
      if (useSearchForm && isSimSearch) {
        //debugger
        const pageParam = new PageParam()

        //如果是分页表格
        if (pageParams?.pageIndex && pageParams?.pageSize) {
          pageParam.PageCondition = new PageCondition(pageParams.pageIndex!, pageParams.pageSize!)
          orders?.forEach((o) => {
            pageParam.PageCondition!.setOrderCondition(
              new OrderCondition(o.sortField, o.sortDirection),
            )
          })
        } else {
          //如果不是分页那么查询全部
          pageParam.PageCondition = new PageCondition(1, 9999999)
          orders?.forEach((o) => {
            pageParam.PageCondition!.setOrderCondition(
              new OrderCondition(o.sortField, o.sortDirection),
            )
          })
        }

        const values = getFieldsValue()
        const schemas = unref(propsRef).formConfig?.schemas
        for (const key in values) {
          const value = values[key]
          const filterOperator =
            schemas?.find((o) => o.field == key)?.filterOperator ?? FilterOperator.Equal
          pageParam.FilterGroup?.add(key, value, filterOperator)
        }

        //reload方法是否传参
        const searchInfoValues = opt?.searchInfo
        for (const serchKey in searchInfoValues) {
          const searchInfoValue = searchInfoValues[serchKey]
          const filterOperator =
            schemas?.find((o) => o.field == serchKey)?.filterOperator ?? FilterOperator.Equal
          pageParam.FilterGroup?.add(serchKey, searchInfoValue, filterOperator)
        }

        params = merge(
          useSearchForm ? pageParam : {},
          searchInfo,
          opt?.searchInfo?.page ?? {},
          defSort,
          sortInfo,
          filterInfo,
          opt?.sortInfo ?? {},
          opt?.filterInfo?.page ?? {},
        )
      } else {
        params = merge(
          pageParams,
          useSearchForm ? getFieldsValue() : {},
          searchInfo,
          opt?.searchInfo ?? {},
          defSort,
          sortInfo,
          filterInfo,
          opt?.sortInfo ?? {},
          opt?.filterInfo ?? {},
        )
      }

      if (beforeFetch && isFunction(beforeFetch)) {
        params = (await beforeFetch(params)) || params
      }
      const res = await api(params)
      rawDataSourceRef.value = res

      const isArrayResult = Array.isArray(res)

      let resultItems: Recordable[] = isArrayResult ? res : get(res, listField)
      const resultTotal: number = isArrayResult ? res.length : get(res, totalField)

      // 假如数据变少，导致总页数变少并小于当前选中页码，通过getPaginationRef获取到的页码是不正确的，需获取正确的页码再次执行
      if (resultTotal) {
        const currentTotalPage = Math.ceil(resultTotal / pageSize)
        if (current > currentTotalPage) {
          setPagination({
            current: currentTotalPage,
          })
          return await fetch(opt)
        }
      }

      if (afterFetch && isFunction(afterFetch)) {
        resultItems = (await afterFetch(resultItems)) || resultItems
      }
      dataSourceRef.value = resultItems
      setPagination({
        total: resultTotal || 0,
      })
      if (opt && opt.page) {
        setPagination({
          current: opt.page || 1,
        })
      }
      emit('fetch-success', {
        items: unref(resultItems),
        total: resultTotal,
      })
      return resultItems
    } catch (error) {
      emit('fetch-error', error)
      dataSourceRef.value = []
      setPagination({
        total: 0,
      })
    } finally {
      setLoading(false)
    }
  }

  function setTableData<T = Recordable>(values: T[]) {
    dataSourceRef.value = values
  }

  function getDataSource<T = Recordable>() {
    return getDataSourceRef.value as T[]
  }

  function getRawDataSource<T = Recordable>() {
    return rawDataSourceRef.value as T
  }

  async function reload(opt?: FetchParams) {
    return await fetch(opt)
  }

  onMounted(() => {
    useTimeoutFn(() => {
      unref(propsRef).immediate && fetch()
    }, 16)
  })

  return {
    getDataSourceRef,
    getDataSource,
    getRawDataSource,
    getRowKey,
    setTableData,
    getAutoCreateKey,
    fetch,
    reload,
    updateTableData,
    updateTableDataRecord,
    deleteTableDataRecord,
    insertTableDataRecord,
    findTableDataRecord,
    handleTableChange,
  }
}
