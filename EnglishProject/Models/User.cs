using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Display(Name = "Has Course")]
        public bool HasCourse { get; set; }
        public ICollection<TaskInfo> ComplitedTaskHistory { get; set; }
        
        [NotMapped]
        public List<DateTime> LoginingHistory { get; set; }

         
        public string LoginingHistoryArray
        {
            get
            {
                string str = String.Empty;
                if (LoginingHistory != null)
                {
                    foreach (DateTime date in LoginingHistory)
                        str += date.ToString() + "_";
                }

                return str;
            }

            set
            {
                if (value != null)
                {
                    LoginingHistory = new List<DateTime>();
                    string[] strs = value.Split("_");
                    foreach (string val in strs)
                    {
                        DateTime date;
                        if (DateTime.TryParse(val.ToString(), out date))
                            LoginingHistory.Add(date);
                    }
                }
            }
        }
    }
}