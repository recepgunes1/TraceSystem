namespace TraceSystem.Models
{
    public class OperationPagingModel
    {
        public List<Operation>? Operations { get; set; }
        public Operation? OperationForProperties { get; set; }
        public int CurrentPage { get; set; }
        public int MaxIndex { get; set; }
    }
}
