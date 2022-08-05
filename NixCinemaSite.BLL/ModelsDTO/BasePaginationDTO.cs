namespace NixCinemaSite.BLL.ModelsDTO
{
    public class BasePaginationDTO
    {
        // TODO вынести значения пагинации через опшин
        public string SearchString { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;
        public int TotalPages { get; set; }
    }
}
