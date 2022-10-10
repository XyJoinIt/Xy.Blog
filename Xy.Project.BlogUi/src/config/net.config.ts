/**
 * @description 导出网络配置
 **/
const config = {
  baseURL:
    process.env.NODE_ENV === "development"
      ? "https://mock.apifox.cn/m1/1060071-0-default" // 开发地址
      : process.env.NODE_ENV === "production"
      ? "/xy-mock-server" // 生产地址
      : "/xy-mock-server", // 测试地址

  // 配后端数据的接收方式application/json;charset=UTF-8 或 application/x-www-form-urlencoded;charset=UTF-8
  contentType: "application/json;charset=UTF-8",
  // 最长请求时间
  requestTimeout: 10000,
  // 操作正常code，支持String、Array、int多种类型
  successCode: [200, 0, "200", "0"],
  // 数据状态的字段名称
  statusName: "code",
  // 状态信息的字段名称
  messageName: "msg",
  //是否启用后端接口？否则用mock数据
  isService: false,
};

export default config;
