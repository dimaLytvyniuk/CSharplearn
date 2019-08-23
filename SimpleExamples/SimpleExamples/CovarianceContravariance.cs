using System;
using System.Collections.Generic;

namespace SimpleExamples
{
    public class CovarianceContravariance
    {
        public static void DoDemo()
        {
            // Assignment compatibility.   
            string str = "test";
            // An object of a more derived type is assigned to an object of a less derived type.   
            object obj = str;

            // Covariance.   
            IEnumerable<string> strings = new List<string>();
            // An object that is instantiated with a more derived type argument   
            // is assigned to an object instantiated with a less derived type argument.   
            // Assignment compatibility is preserved.   
            IEnumerable<object> objects = strings;

            // Contravariance.             
            // Assume that the following method is in the class:   
            // static void SetObject(object o) { }   
            Action<object> actObject = DoActionObject;
            // An object that is instantiated with a less derived type argument   
            // is assigned to an object instantiated with a more derived type argument.   
            // Assignment compatibility is reversed.
            Action<string> actString = actObject;

            // It's not allowed because action will be worked with string as parameter
            // but will be passed object
            // actObject = actString;
            
            actObject(new object());
            actString("str");
            
            IMyInterface<A> realizationA = new MyRealization<A>();
            IMyInterface<B> realizationB = new MyRealization<B>();

            realizationA = realizationB;
            realizationA.DoSmth();// will always return type derived from A
        }

        public static void CovariantDemo()
        {
            IMyInterface<A> realizationA = new MyRealization<A>();
            IMyInterface<B> realizationB = new MyRealization<B>();

            realizationA = realizationB;
            A result = realizationA.DoSmth();// will always return type derived from A
        }

        public static void ContravariantDemo()
        {
            IMyContravariantInterface<A> realizationA = new MyRealization<A>();
            IMyContravariantInterface<B> realizationB = new MyRealization<B>();

            realizationB = realizationA;
            realizationB.DoSmth(new B());// will be invoked method with parameter A, B derived from A
        }
        
        public static void DoActionObject(object o)
        { 
            Console.WriteLine(o.GetType());
        }
    }
    
    public class A { }
    public class B: A { }

    public interface IMyInterface<out T>
    {
        T DoSmth();
    }

    public interface IMyContravariantInterface<in T>
    {
        void DoSmth(T doSmth);
    }
    
    public class MyRealization<T>: IMyInterface<T>, IMyContravariantInterface<T> where T: new()
    {
        public T DoSmth()
        {
            return new T();
        }

        public void DoSmth(T doSmth)
        {
            throw new NotImplementedException();
        }
    }
}