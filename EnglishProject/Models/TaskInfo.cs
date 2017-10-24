using System;
using System.ComponentModel.DataAnnotations;

namespace EnglishProject.Models
{
    public class TaskInfo
    {
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }
        
        [Required]
        public int EnglishTaskID { get; set; }
        
        [Required]
        public int CorrectAnswers { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DateComplete { get; set; }
        public bool InCourse { get; set; }
    }
}