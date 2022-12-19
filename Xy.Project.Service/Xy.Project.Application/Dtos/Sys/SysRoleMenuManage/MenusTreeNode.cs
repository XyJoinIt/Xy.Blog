using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Core.Helpers;
using Xy.Project.Platform.Model.Entities.Sys;

namespace Xy.Project.Application.Dtos.Sys.SysRoleMenuManage
{
    [AutoMap(typeof(SysMenu), ReverseMap = true)]
    public class MenusTreeNode : SysMenu, ITreeNode
    {
        public long GetId()
        {
            return Id;
        }

        public long GetPid()
        {
            return Pid;
        }


        /// <summary>
        /// 菜单子项
        /// </summary>
        public List<MenusTreeNode> Children { get; set; } = new List<MenusTreeNode>();

        public void SetChildren(IList _children)
        {
            Children = (List<MenusTreeNode>)_children;
        }
    }
}
