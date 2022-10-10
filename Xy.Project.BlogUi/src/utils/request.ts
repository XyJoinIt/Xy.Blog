import netconfig from "@/config/net.config";
import axios from "axios";
import { message } from "ant-design-vue";
import { isArray } from "@/utils/validate";

let loadingInstance: any;
const baseURL = netconfig.baseURL;
// 操作正常Code数组
const codeVerificationArray = isArray(netconfig.successCode)
  ? [...netconfig.successCode]
  : [...[netconfig.successCode]];

const CODE_MESSAGE: any = {
  200: "获取成功",
  201: "新建或修改数据成功",
  204: "删除数据成功",
  400: "发出信息有误",
  401: "用户没有权限(令牌失效、用户名、密码错误、登录过期)",
  402: "令牌过期",
  403: "用户得到授权，但是访问是被禁止的",
  404: "访问资源不存在",
  500: "服务器发生错误",
};

/**
 * axios响应拦截器
 * @param config 请求配置
 * @param data response数据
 * @param status HTTP status
 * @param statusText HTTP status text
 * @returns {Promise<*|*>}
 */
const handleData = async ({ data, status, statusText }: any) => {
  if (loadingInstance) loadingInstance.close();
  // 若data.code存在，覆盖默认code
  let code =
    data && data[netconfig.statusName] ? data[netconfig.statusName] : status;
  // 若code属于操作正常code，则status修改为200
  if (codeVerificationArray.indexOf(data[netconfig.statusName]) + 1) code = 200;
  if (!netconfig.isService) {
    return data;
  }
  switch (code) {
    case 200:
      // 业务层级错误处理，以下是假定restful有一套统一输出格式(指不管成功与否都有相应的数据格式)情况下进行处理
      // 例如响应内容：
      // 错误内容：{ code: 1, msg: '非法参数' }
      // 正确内容：{ code: 200, data: {  }, msg: '操作正常' }
      // return data
      return data;
    case 401:
      //该做些什么呢？
      break;
    case 403:
      //该做些什么呢？
      break;
  }
  // 异常处理
  // 若data.msg存在，覆盖默认提醒消息
  console.log(data);

  const errMsg = `${
    data && data[netconfig.messageName]
      ? data[netconfig.messageName]
      : CODE_MESSAGE[code]
      ? CODE_MESSAGE[code]
      : statusText
  }`;
  // 是否显示高亮错误(与errorHandler钩子触发逻辑一致)
  message.error(errMsg);
  return Promise.reject(data);
};

/**
 * @description axios初始化
 */
const instance = axios.create({
  baseURL,
  timeout: netconfig.requestTimeout,
  headers: {
    "Content-Type": netconfig.contentType,
  },
});

/**
 * @description axios请求拦截器
 */
instance.interceptors.request.use(
  (config: any) => {
    //const userStore = useUserStore();
    //const { token } = userStore;
    const token = "njkyD7MiOy5hmPS2KzOPaM2GUOisL6ya";
    if (!netconfig.isService) {
      if (token) config.headers["apifoxToken"] = token;
    } else {
      // 规范写法 不可随意自定义
      if (token) config.headers["Authorization"] = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

/**
 * @description axios响应拦截器
 */
instance.interceptors.response.use(
  (response) => handleData(response),
  (error) => {
    const { response } = error;
    if (response === undefined) {
      if (loadingInstance) loadingInstance.close();
      message.error(
        "连接后台接口失败，可能由以下原因造成：后端不支持跨域CORS、接口地址不存在、请求超时等，请联系管理员排查后端接口问题"
      );
      return {};
    } else return handleData(response);
  }
);

export default instance;
