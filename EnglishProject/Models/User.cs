using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnglishProject.Models
{
    public class User
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Login cannot be longer than 50 characters.")]
        public string Login { get; set; }
        
        [Required]
        [StringLength(25, ErrorMessage = "Password cannot be longer than 25 characters.")]
        public string Password { get; set; }
        
        [Required]
        public string Email { get; set; }
        public bool HasCourse { get; set; }
        public ICollection<TaskInfo> ComplitedTaskHistory { get; set; }
        public ICollection<DateTime> LoginingHistory { get; set; }
    }
}