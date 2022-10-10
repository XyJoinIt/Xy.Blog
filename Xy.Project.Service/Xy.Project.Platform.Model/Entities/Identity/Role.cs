namespace Xy.Project.Platform.Model.Entities.Identity
{
    public class Role : RoleBase<long>, IFullAuditedEntity
    {
        public Role()
        {
            Id = YitIdHelper.NextId();
        }
        public string? Remarks { get; set; }
        public CommonStatus Status { get; set; } = CommonStatus.正常;
        public DateTime? CreateTime { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
