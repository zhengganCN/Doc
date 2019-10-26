public class ModelResult<T>
{
    /// <summary>
    /// 返回数据
    /// </summary>
    public T Data { get; set; }
    /// <summary>
    /// 分页信息
    /// </summary>
    public Pagination Pagination { get; set; }
    /// <summary>
    /// 提示信息
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// 代码
    /// </summary>
    public int? Code { get; set; }
    /// <summary>
    /// 成功标识,操作执行是否成功
    /// </summary>
    public bool Success { get; set; }
}