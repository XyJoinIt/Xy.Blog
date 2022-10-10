namespace Xy.Project.Core.Base;

public class BaseInputId : IBaseInputId
{
    /// <summary>
    /// 传入主键Id
    /// </summary>
    [Required(ErrorMessage = "Id不能为空")]
    public virtual long Id { get; set; }
}

public interface IBaseInputId
{
    /// <summary>
    /// 主键
    /// </summary>
    long Id { get; set; }
}