using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leson4
{
    class Program
    {
        static void Main(string[] args)
        {   //2

            //a
            var resultList0 = task2.getElementCountInList(task2.myList0);
            foreach (var a in resultList0) Console.WriteLine(a);
            //б
            Console.WriteLine("===================================");
            var resultList1 = task2.getElementCountInList(task2.myList1);
            foreach (var a in resultList1) Console.WriteLine(a);
            //с
            Console.WriteLine("===================================");
            var cnt = from n in task2.myList1
                      group n by n into groups
                      select new
                      {
                          element = groups.Key,
                          count = groups.Count(),
                      };
            foreach (var a in cnt) Console.WriteLine(a);
            Console.WriteLine("===================================");
            task3.taskMethod();
            Console.WriteLine("===================================");
            task3.myMethod1();

            Console.ReadLine();
        }
    }
}
