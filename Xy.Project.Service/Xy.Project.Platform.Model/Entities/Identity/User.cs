namespace Xy.Project.Platform.Model.Entities.Identity
{
    public class User : UserBase<long>, IFullAuditedEntity
    {
        public User()
        {
            Id = YitIdHelper.NextId();
        }
        /// <summary>
        /// 头像
        /// </summary>
        public string? Avatar { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 性别-男_1、女_2
        /// </summary>
        public Gender Sex { get; set; } = Gender.未知;

        /// <summary>
        /// 账户状态
        /// </summary>
        public CommonStatus Status { get; set; } = CommonStatus.正常;

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
