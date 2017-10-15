using System;

namespace EnglishProject.Models
{
    public class TaskInfo
    {
        public int TaskID { get; set; }
        public int CorrectAnswers { get; set; }
        public DateTime DateComplete { get; set; }
        public bool InCourse { get; set; }
    }
}