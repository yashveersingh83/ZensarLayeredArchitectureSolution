namespace Zensar.Core.DBEntities.Filters
{
    public class FilterCriteria
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public BitWiseOperation Operation { get; set; }
        public Operator Operator { get; set; }
        public FilterType FilterType { get; set; }
    }


    public enum BitWiseOperation
    {
        Default = 0,
        Or
    }

    public enum FilterType
    {
        Default = 0,
        ImportFilter = 1
    }

    public enum Operator
    {
        EqualTo = 0,
        NotEqualTo,
        Contains,
        NotContains
    }
}
