import request from "@/utils/request";
//新增
export function doAdd(data: any) {
  return request({
    url: "/api/SysRole/Add",
    method: "post",
    data,
  });
}

/**
 * @description 分页
 * @author xiaoyun
 * @export
 * @param {*} data
 * @return {*}
 */
export function Page(params: any) {
  return request({
    url: "/api/SysUser/Page",
    method: "",
    params,
  });
}
