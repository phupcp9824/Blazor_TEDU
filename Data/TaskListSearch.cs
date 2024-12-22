using Data.Enums;
using Data.SeedWork;

namespace Data
{
    public class TaskListSearch : PagingParameters
    {
        public string? name { get; set; }
        public Guid? AssigneeId { get; set; }
        public Priority? Priority { get; set; }
    }
}
