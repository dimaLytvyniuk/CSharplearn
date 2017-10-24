using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishProject.Models
{
    public class Course
    {
        public int ID { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public EnglishLevel EnglishLevel { get; set; }
        
        [NotMapped]
        public IList<GrammarPart> PartsWhichWantStudy { get; set; }

        [NotMapped]
        public IList<GrammarPart> PartsToLearn { get; set; }

        [Required]
        public byte[] PartsWhichWantStudyByte 
        { 
            get
            {
                byte[] toReturn = new byte[PartsWhichWantStudy.Count];
                for (int i = 0; i < PartsWhichWantStudy.Count; i++)
                    toReturn[i] = (byte)PartsWhichWantStudy[i];
                return toReturn;
            } 
            set
            {
                PartsWhichWantStudy = new List<GrammarPart>();
                foreach (byte val in value)
                {
                    try
                    {
                        GrammarPart gr = (GrammarPart)Enum.ToObject(typeof(GrammarPart), val);
                        PartsWhichWantStudy.Add(gr);
                    }
                    catch (ArgumentException)
                    { 

                    }
                }
            }
        }

        public byte[] PartsToLearnByte
        {
            get
            {
                byte[] toReturn = new byte[PartsToLearn.Count];
                for (int i = 0; i < PartsToLearn.Count; i++)
                    toReturn[i] = (byte)PartsToLearn[i];
                return toReturn;
            }

            set
            {
                PartsToLearn = new List<GrammarPart>();
                foreach (Byte val in value)
                {
                    GrammarPart gr;
                    try
                    {
                        gr = (GrammarPart)Enum.ToObject(typeof(GrammarPart), val);
                        PartsToLearn.Add(gr);
                    }
                    catch (ArgumentException)
                    {

                    }
                }
            }
        }
    }
}