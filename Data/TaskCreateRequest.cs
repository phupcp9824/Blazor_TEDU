using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;

namespace Data
{
    public class TaskCreateRequest
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
        public Priority priority { get; set; }
        public Status status { get; set; }
    }
}
