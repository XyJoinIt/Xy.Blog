using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Core.Helpers;

namespace Xy.Project.Application.Dtos.Sys.SysMenuManage
{
    /// <summary>
    /// 登录菜单-AntDesign菜单类型
    /// </summary>
    public class MenusTreeNode : ITreeNode
    {
        /// <summary>
        /// id
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// 父id
        /// </summary>
        public long? Pid { get; set; }

        /// <summary>
        /// 路由名称, 必须设置,且不能重名
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 组件
        /// </summary>
        public string? Component { get; set; }

        /// <summary>
        /// 重定向地址, 访问这个路由时, 自定进行重定向
        /// </summary>
        public string? Redirect { get; set; }

        /// <summary>
        /// 路由元信息（路由附带扩展信息）
        /// </summary>
        public Meta Meta { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string? Path { get; set; }

        /// <summary>
        /// 控制路由和子路由是否显示在 sidebar
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 子集
        /// </summary>
        public List<MenusTreeNode> children { get; set; } = new List<MenusTreeNode>();

        public long GetId()
        {
            return Id!.Value;
        }

        public long GetPid()
        {
            return Pid!.Value;
        }

        public void SetChildren(IList _children)
        {
            children = (List<MenusTreeNode>)_children;
        }
    }

    /// <summary>
    /// 路由元信息内部类
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// 路由标题, 用于显示面包屑, 页面标题 *推荐设置
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// 是否可见
        /// </summary>
        public bool Show { get; set; }

        /// <summary>
        /// 如需外部打开，增加：_blank
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 内链打开http链接
        /// </summary>
        public string? Link { get; set; }
    }
}
