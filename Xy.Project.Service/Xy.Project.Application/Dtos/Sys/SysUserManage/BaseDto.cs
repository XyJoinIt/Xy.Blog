namespace Xy.Project.Application.Dtos.Sys.SysUserManage
{
    public class BaseDto
    {
        /// <summary>
        /// 名字 例如 .NET/JAVA/JS
        /// </summary>
        public string Name { get; set; } = default!;


        /// <summary>
        /// 编码
        /// </summary>

        public string Code { get; set; } = default!;

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remarks { get; set; }

    }
}
