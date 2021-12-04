using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementServices.Models
{
    [Table("StudentTasks")]
    public class StudentTasksLogic
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
