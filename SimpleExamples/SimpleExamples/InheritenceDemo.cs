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
        }
    }

    public class Parent
    {
        public virtual void GetValue(string a)
        {
            Console.WriteLine("class Parent:GetValue -> string a = {0}", a);
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
    }
}
