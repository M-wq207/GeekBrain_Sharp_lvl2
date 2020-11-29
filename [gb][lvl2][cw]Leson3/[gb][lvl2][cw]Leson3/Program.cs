using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _gb__lvl2__cw_Leson3
{
    class Program
    {//обобщенный делегат
        public delegate void myDelegate<T>(T param);
        //экземпляры обобщенного делегате
        public static myDelegate<int> myDelegateInt;
        public static myDelegate<string> myDelegateString;

        public enum Sex
        {
            Male,
            Female,
            Undefined
        }
        public class BaseClass { }
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public object Sex { get; set; }
        }
        public class PersonV2 <T> where T : new() 
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public T Sex { get; set; }

            public PersonV2 (string name, int age, T sex)
            {
                Name = name;
                Age = age;
                Sex = sex;
            }
        }


        static void Swap(ref int A, ref int B)
        {
            int t;
            t = A;
            A = B;
            B = t;
        }
        static void Swap(ref double A, ref double B)
        {
            double t;
            t = A;
            A = B;
            B = t;
        }

        static void Swap<T>(ref T A, ref T B)
        {
            T t;
            t = A;
            A = B;
            B = t;
        }
        static void Main(string[] args)
        {
            
            var person1 = new Person() { Name = "Andry", Age = 22, Sex = "Man" };
            var person2 = new Person() { Name = "Andry2", Age = 22, Sex = Sex.Male };

            var person3 = new PersonV2<Sex>("Andry3", 22, Sex.Male);
            var person4 = new PersonV2<object>("Andry3", 22, "Man");
            //
            myDelegateInt += intForDelegate;
            myDelegateString += strForDelegate;
            //
            myDelegateInt?.Invoke(2);
            myDelegateString?.Invoke("text");
            //
            Console.ReadLine();
        }
        //методы для обобщенного делегата
        public static void intForDelegate(int i)
        {
            Console.WriteLine($"это вызов метода с int параметром, переданное число - {i}");
        }
        public static void strForDelegate(string i)
        {
            Console.WriteLine($"это вызов метода с string параметром, переданная строка - \"{i}\"");
        }
    }
}
