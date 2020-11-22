using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_csh_lvl2_leson2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("unsorted");
            WorkerArrClass.ArrPrint();

            WorkerArrClass.ArrSort();

            Console.WriteLine("\n\nunsorted");
            WorkerArrClass.ArrPrint();

            Console.ReadLine();
        }
    }
}
