using System;
using System.Collections.Generic;

namespace EnglishProject.Models
{
    public class Course
    {
        public int ID { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public List<GrammarPart> PartsWhichWantStudy { get; set; }
        public List<GrammarPart> PartsToLearn { get; set; }
        public List<int> complitedTasks { get; set; }
    }
}