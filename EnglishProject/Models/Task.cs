using System;

namespace EnglishProject.Models
{
    public class Task
    {
        public int ID { get; set; }
        public TaskType TaskType { get; set; }
        public GrammarPart GrammarPart { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public int Count { get; set; }
        public string Text { get; set; }
    }
}