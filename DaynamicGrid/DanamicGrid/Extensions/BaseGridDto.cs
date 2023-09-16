namespace DanamicGrid.Extensions
{

    public class FilterModel
    {
        public object Key { get; set; }
        public object Value { get; set; }
    }

    public class BaseGridDto
    {
        public List<FilterModel> Filters { get; set; }

        public string SearchTerm { get; set; }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public string Sort { get; set; }

    }
}