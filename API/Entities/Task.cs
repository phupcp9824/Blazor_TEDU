using Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }
        public Guid? AssigneeId { get; set; }

        [ForeignKey(nameof(AssigneeId))]
        public User Assignee { get; set; }
        public DateTime CreatedDate { get; set; }
        public Priority priority { get; set; }
        public Status status { get; set; }
    }
}
