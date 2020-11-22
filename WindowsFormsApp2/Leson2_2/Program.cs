using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leson2_2
{
    class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }

        public class PersonV2 : IComparable<PersonV2>
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public PersonV2(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public int CompareTo(PersonV2 other)
            {
                return other.Age - this.Age;

            }
        }

        public class PersonV3 : ICloneable
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public PersonV3(string name, int age)
            {
                Name = name;
                Age = age;
            }



            public object Clone()
            {
                return new PersonV3(this.Name, this.Age);
            }
        }

        public class IdInfo
        {
            public int IdNumber;

            public IdInfo(int idNumber)
            {
                IdNumber = idNumber;
            }
            public class PersonV4
            {
                public string Name { get; set; }
                public int Age { get; set; }
                public IdInfo IdInfo { get; set; }
                private string originalName { get; set; }

                public PersonV4(string name, int age, IdInfo idInfo)
                {
                    originalName = name;
                    Age = age;
                    IdInfo = idInfo;
                    Name = $"{this.IdInfo.IdNumber} {Name}";
                }

                public PersonV4 Copy()
                {
                    return (PersonV4)this.MemberwiseClone();
                }
                public PersonV4 DeepCopy()
                {
                    var person = (PersonV4)this.MemberwiseClone();
                    this.IdInfo.IdNumber++;
                    //var idInfo = new IdInfo(this.IdInfo.IdNumber++);
                    person.Name = $"{this.IdInfo.IdNumber} {this.originalName}";
                    return person;
                }
            }
            class AgeComparer : IComparer<Person>
            {
                public int Compare(Person x, Person y)
                {
                    return x.Age - y.Age;
                }
            }
            static void Main(string[] args)
            {
                var persons = new Person[]
                {
                new Person("Dmitry", 23),
                new Person("Masha", 18),
                new Person("Pasha", 17),
                new Person("Sveta", 29),
                new Person("Andrey", 18),
                };
                Array.Sort(persons, new AgeComparer());

                for (int i = 0; i < persons.Length; i++)
                {
                    Console.WriteLine($"{persons[i].Name} = {persons[i].Age}");
                }





                var persons02 = new PersonV2[]
                {
                new PersonV2("Dmitry", 23),
                new PersonV2("Masha", 18),
                new PersonV2("Pasha", 17),
                new PersonV2("Sveta", 29),
                new PersonV2("Andrey", 18),
                };

                Array.Sort(persons02);

                for (int i = 0; i < persons.Length; i++)
                {
                    Console.WriteLine($"{persons[i].Name} - {persons[i].Age}");
                }
                

                var person = new PersonV3("", 22);
                var person2 = (PersonV3)person.Clone();
                Console.WriteLine($"{person.Name} - {person.Age}");
                Console.WriteLine($"{person2.Name} - {person2.Age}");

                var person3 = new PersonV4("Andrey", 22, new IdInfo(1001));
                var person4 = person3.Copy();
                Console.WriteLine($"{person3.Name} - {person3.Age}");
                Console.WriteLine($"{person4.Name} - {person4.Age}");


                var person5 = person3.DeepCopy();
                Console.WriteLine($"{person5.Name} - {person5.Age}");

                Console.WriteLine();

                Console.ReadLine();

            }
        }
    }
}
