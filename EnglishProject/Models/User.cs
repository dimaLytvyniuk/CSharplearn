using System;
using System.Collections.Generic;

namespace EnglishProject.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool HasCourse { get; set; }
        public List<TaskInfo> complitedTaskHistory { get; set; }
        public List<DateTime> LoginingHistory { get; set; }
    }
}