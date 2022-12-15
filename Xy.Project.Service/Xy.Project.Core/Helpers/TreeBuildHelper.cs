using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.Project.Core.Helpers
{
    public class TreeBuildHelper<T> where T : ITreeNode
    {
        /// <summary>
        /// 顶级节点的父节点Id(默认0)
        /// </summary>
        private long _rootParentId = 0L;

        /// <summary>
        /// 设置根节点方法
        /// 查询数据可以设置其他节点为根节点，避免父节点永远是0，查询不到数据的问题
        /// </summary>
        public void SetRootParentId(long rootParentId)
        {
            _rootParentId = rootParentId;
        }

        /// <summary>
        /// 构造树节点
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public List<T> Build(List<T> nodes)
        {
            var result = nodes.Where(i => i.GetPid() == _rootParentId).ToList();
            result.ForEach(u => BuildChildNodes(nodes, u));

            return result;
        }

        /// <summary>
        /// 构造子节点集合
        /// </summary>
        /// <param name="totalNodes"></param>
        /// <param name="node"></param>
        /// <param name="childNodeList"></param>
        private void BuildChildNodes(List<T> totalNodes, T node)
        {
            var nodeSubList = totalNodes.Where(i => i.GetPid() == node.GetId()).ToList();
            nodeSubList.ForEach(u => BuildChildNodes(totalNodes, u));
            if (nodeSubList.Count > 0)
                node.SetChildren(nodeSubList);
        }
    }

    /// <summary>
    /// 树基类
    /// </summary>
    public interface ITreeNode
    {
        /// <summary>
        /// 获取节点id
        /// </summary>
        /// <returns></returns>
        long GetId();

        /// <summary>
        /// 获取节点父id
        /// </summary>
        /// <returns></returns>
        long GetPid();

        /// <summary>
        /// 设置Children
        /// </summary>
        /// <param name="children"></param>
        void SetChildren(IList children);
    }
}
