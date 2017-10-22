using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnglishProject.Models
{
    public class Course
    {
        public int ID { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public EnglishLevel EnglishLevel { get; set; }
        
        [Required]
        public ICollection<GrammarPart> PartsWhichWantStudy { get; set; }
        public ICollection<GrammarPart> PartsToLearn { get; set; }
    }
}