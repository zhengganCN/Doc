/// <summary>
/// 获取枚举描述
/// </summary>
/// <param name="value">枚举值</param>
/// <returns></returns>
public static string GetDescription(this Enum value)
{
    if (value == null)
    {
        return string.Empty;
    }
    var field = value.GetType().GetField(value.ToString());
    if (field == null)
    {
        return string.Empty;
    }
    return !(Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute) ? value.ToString() : attribute.Description;
}