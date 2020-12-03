using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Leson4
{
    //2. Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
    //а) для целых чисел;
    //б) * для обобщенной коллекции;
    //в) * используя Linq.
    class task2
    {   
        //a)коллекция целых чисел
        public static List<int> myList0 = new List<int>() { 1, 2, 3, 4, 5, 234, 43, 2, 1, 3, 2, 4, 6, 23 };
        public static List<string> getElementCountInList<T>(List<T> myList0)
        {
            List<string> resultList = new List<string>();
            foreach (var a in myList0)
            {
                int counter = 0;

                foreach (var b in myList0)
                {
                    try
                    {
                        if (a.Equals(b)) counter++;
                    }
                    catch
                    {
                        Console.WriteLine("несравнимые элементы");
                    }
                }
                string c = $"Элемент {a} встречается в листе {counter} раз(а)";
                if (!resultList.Contains(c)) resultList.Add(c);
            }
            return resultList;
        }
        //б)обобщенная коллекция? (List<T> и есть обобщенная коллекнция, не до конца понял задание)
        public static List<object> myList1 = new List<object>() { "text", 1, 23.1, myList0, 3, "text" };
    }
}
