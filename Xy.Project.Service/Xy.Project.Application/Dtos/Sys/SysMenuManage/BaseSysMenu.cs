using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Application.Dtos.Sys.SysMenuManage
{
    public class BaseSysMenu
    {
        /// <summary>
        /// 菜单类型（1目录 2菜单 3按钮）
        /// </summary>
        public MenuType? Type { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 路由地址
        /// </summary>
        [MaxLength(128)]
        public string? Path { get; set; }

        /// <summary>
        /// 组件路径
        /// </summary>
        [MaxLength(128)]
        public string? Component { get; set; }

        /// <summary>
        /// 重定向
        /// </summary>
        [MaxLength(128)]
        public string? Redirect { get; set; }

        /// <summary>
        /// 权限标识
        /// </summary>
        [MaxLength(128)]
        public string? Permission { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(128)]
        public string? Icon { get; set; }

        /// <summary>
        /// 是否内嵌
        /// </summary>
        public bool IsIframe { get; set; } = false;

        /// <summary>
        /// 外链链接
        /// </summary>
        [MaxLength(256)]
        public string? OutLink { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool IsHide { get; set; } = false;

        /// <summary>
        /// 是否缓存
        /// </summary>
        public bool IsKeepAlive { get; set; } = true;

        /// <summary>
        /// 是否固定
        /// </summary>
        public bool IsAffix { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; } = 100;

        /// <summary>
        /// 状态
        /// </summary>
        public CommonStatus Status { get; set; } = CommonStatus.正常;

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}
