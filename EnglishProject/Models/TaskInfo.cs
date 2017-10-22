using System;
using System.ComponentModel.DataAnnotations;

namespace EnglishProject.Models
{
    public class TaskInfo
    {
        [Required]
        public int UserID { get; set; }
        
        [Required]
        public int TaskID { get; set; }
        
        [Required]
        public int CorrectAnswers { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DateComplete { get; set; }
        public bool InCourse { get; set; }
    }
}