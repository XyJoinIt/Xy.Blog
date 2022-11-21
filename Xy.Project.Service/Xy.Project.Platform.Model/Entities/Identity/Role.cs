namespace Xy.Project.Platform.Model.Entities.Identity
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role : RoleBase<long>, IFullAuditedEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Role()
        {
            Id = YitIdHelper.NextId();
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public CommonStatus Status { get; set; } = CommonStatus.正常;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
