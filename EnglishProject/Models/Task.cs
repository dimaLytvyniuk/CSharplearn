using System;
using System.ComponentModel.DataAnnotations;

namespace EnglishProject.Models
{
    public class Task
    {
        public int ID { get; set; }
        public TaskType TaskType { get; set; }
        public GrammarPart GrammarPart { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        
        [Required]
        public uint Count { get; set; }
        public string Example { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        [Required]
        public string Answer { get; set; }
    }
}