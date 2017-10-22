using System;
using EnglishProject.Models;
using System.Linq;
using System.Collections.Generic;

namespace EnglishProject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EnglishContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }


            var tasks = new Task[]
            {
                new Task{ID=1,TaskType=TaskType.CorrectAlternative,GrammarPart=GrammarPart.PRContinuous,EnglishLevel=EnglishLevel.Advanced,Count=10,Text="adaaaad",Answer="dajds",Example=null},
                new Task{ID=2,TaskType=TaskType.CorrectOrder,GrammarPart=GrammarPart.PRSimple,EnglishLevel=EnglishLevel.PreIntermediate,Count=10,Text="dsafasad",Example="dkjas",Answer="dssad"}
            };
            foreach (Task t in tasks)
            {
                context.Tasks.Add(t);
            }
            context.SaveChanges();

            List<TaskInfo> taskInfos = new List<TaskInfo>
            {
                new TaskInfo{UserID=1,TaskID=1,CorrectAnswers=10,DateComplete=DateTime.Now,InCourse=true},
                new TaskInfo{UserID=1,TaskID=2,CorrectAnswers=8,DateComplete=DateTime.Now,InCourse=false}
            };
            foreach (TaskInfo tInfo in taskInfos)
            {
                context.TaskInfos.Add(tInfo);
            }
            context.SaveChanges();

            List<DateTime> loginHistory1 = new List<DateTime>
            {
                DateTime.Now,
                DateTime.UtcNow
            };

            var users = new User[]
            {
                new User{ID=1,Login="user",Password="user",Email="user@gmail.com",HasCourse=true,ComplitedTaskHistory=taskInfos,LoginingHistory=loginHistory1},
                new User{ID=2,Login="root",Password="root",Email="root@mail.ru",HasCourse=false,ComplitedTaskHistory=null,LoginingHistory=loginHistory1}
            };
            foreach (User user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            List<GrammarPart> grammarParts = new List<GrammarPart>
            {
                GrammarPart.PRContinuous,
                GrammarPart.PRSimple
            };

            var courses = new Course[]
            {
                new Course{ID=1,UserId=1,EnglishLevel=EnglishLevel.PreIntermediate,PartsWhichWantStudy=grammarParts}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

        }
    }
}