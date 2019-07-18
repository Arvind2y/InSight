using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerAPI.Core.Models
{
    public class TaskDetail
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [Column (TypeName ="NVARCHAR(200)")]
        public string TaskName { get; set; }

        public int? ParentTask { get; set; }

        [Required]
        [Column(TypeName="datetime")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }

        [Required]
        public int Priority { get; set; }

        [Column(TypeName ="bit")]
        public bool IsCompleted { get; set; }

    }
}
