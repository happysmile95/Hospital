namespace Hospital.Api
{
    public abstract class BaseFilterDto
    {
        public string OrderField { get; set; }
        public string SortDirect { get; set; }
        public int Take { get; set; } = 5;
        public int Page { get; set; } = 1;
    }
}