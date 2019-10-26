public class Pagination
{
    private const int Index = 1;
    private const int Size = 10;

    private int? pageIndex;
    private int? pageSize;
    public int? PageIndex
    {
        get
        {
            if (pageIndex == null)
            {
                pageIndex = Index;
            }
            return pageIndex;
        }
        set => pageIndex = value;
    }
    public int? PageSize
    {
        get
        {
            if (pageSize == null)
            {
                pageSize = Size;
            }
            return pageSize;
        }
        set => pageSize = value;
    }
    public int Count { get; set; }
}