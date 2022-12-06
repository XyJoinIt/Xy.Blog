import { FilterConnect, FilterOperator, OrderDirection } from '/@/enums/GlobaEnum'
import { PaginationProps } from '/@/components/Table/src/types/pagination'
export interface BasicPageParams {
  pageIndex?: number
  pageSize?: number
}
export class BaseId {
  constructor(id: number) {
    this.Id = id
  }
  Id = 0
}
export interface BasicFetchResult<T> {
  items: T[]
  total: number
}

//分页总参数
export class PageParam {
  constructor(pageIndex: number, pageSize: number) {
    this.PageCondition = new PageCondition(pageIndex, pageSize)
    this.FilterGroup = new FilterGroup()
  }
  //分页条件
  PageCondition: PageCondition
  //查询条件组
  FilterGroup: FilterGroup
}

// 排序条件集合
export class OrderCondition {
  constructor(SortField: string, SortDirection?: OrderDirection) {
    this.SortField = SortField
    this.SortDirection = SortDirection == null ? OrderDirection.Ascending : SortDirection
  }

  SortField: string
  SortDirection: OrderDirection
}

//分页条件
export class PageCondition {
  constructor(pageIndex?: number, pageSize?: number) {
    if (pageIndex == null) pageIndex = 1
    if (pageSize == null) pageSize = 10
    this.PageIndex = pageIndex
    this.PageSize = pageSize
  }

  PageIndex: number
  PageSize: number
  StartTime?: Date
  OrderConditions?: OrderCondition[]
  EndTime?: Date
}

//过滤组
export class FilterGroup {
  // constructor(Conditions: [], FilterConnect?: FilterConnect) {
  //   this.FilterConnect = FilterConnect
  //   this.Conditions = Conditions
  // }
  FilterConnect?: FilterConnect = FilterConnect.And
  Conditions?: Array<FilterCondition> = new Array<FilterCondition>()

  //新增
  add(field: string, value: Object, operator: FilterOperator = FilterOperator.Equal) {
    this.Conditions?.push(new FilterCondition(field, value, operator))
  }
}

//连接条件
export class FilterCondition {
  constructor(field: string, value: Object, operator: FilterOperator) {
    this.Field = field
    this.Value = value
    this.Operator = operator
  }
  Field: string
  Value: Object
  Operator: FilterOperator
}

//设置分页
export class Pagination implements PaginationProps {
  constructor(pageindex: number, pageSize: number, total: number) {
    ;(this.current = pageindex), (this.pageSize = pageSize), (this.total = total)
  }
  /**
   * total number of data items
   * @default 0
   * @type number
   */
  total?: number

  /**
   * current page number
   * @type number
   */
  current?: number

  /**
   * number of data items per page
   * @type number
   */
  pageSize?: number
}
