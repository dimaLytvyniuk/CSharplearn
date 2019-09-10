using System;

namespace SimpleExamples
{
    public class InheritenceDemo
    {
        public static void DoDemo()
        {
            var value = "Hello World"; 
            var parent = new Parent();
            var child = new Child(); 
            parent.GetValue(value);
            child.GetValue(value);
            
            var alone = new Alone();
            alone.GetValue(value);
            
            Parent parent1 = new Child();
            parent1.Test();
            parent1.TestPartent();
        }
    }

    public class Parent
    {
        public virtual void GetValue(string a)
        {
            Console.WriteLine("class Parent:GetValue -> string a = {0}", a);
        }
        
        public virtual void Test(int a = 10)
        {
            Console.WriteLine(a);
        }
        
        public virtual void TestPartent()
        {
            Console.WriteLine("Parent");
        }
    }

    public class Child: Parent
    {
        public override void GetValue(string a)
        {
            Console.WriteLine("class Child:GetValue -> string a = {0}", a);
        }

        public void GetValue(object a)
        {
            Console.WriteLine("class Child:GetValue -> object a = {0}", a);
        }
        
        public override void Test(int a = 20)
        {
            Console.WriteLine(a);
        }
        
        public override void TestPartent()
        {
            Console.WriteLine("Child");
        }
    }

    public class Alone
    {
        public void GetValue(string a)
        {
            Console.WriteLine("class Child:GetValue -> string a = {0}", a);
        }

        public void GetValue(object a)
        {
            Console.WriteLine("class Child:GetValue -> object a = {0}", a);
        }
    }
}
