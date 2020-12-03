using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leson4
{
    //Дан фрагмент программы:
    //а) Свернуть обращение к OrderBy с использованием лямбда-выражения $.
    //б) Развернуть обращение к OrderBy с использованием делегата Predicate<T>.

    class task3
    {
        public static Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            {"four",4 },
            {"two",2 },
            { "one",1 },
            {"three",3 },
        };
        public static void taskMethod()
        {
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
        //а) Свернуть обращение к OrderBy с использованием лямбда-выражения $.
        public static void myMethod1()
        {
            foreach (var pair in dict.OrderBy(pair => pair.Value)) Console.WriteLine(pair);
        }
        //б) Развернуть обращение к OrderBy с использованием делегата Predicate<T>.
        public static Predicate<KeyValuePair<int, int>> myPredicate;
        public static void myMethid2()
        {
            myPredicate += sortDict;
            foreach (var pair1 in dict)
            {
                foreach (var pair2 in dict)
                {
                    var a = new KeyValuePair<int, int>(pair1.Value, pair2.Value);
                    myPredicate(a);
                }
            }    

        }
        public static bool sortDict(KeyValuePair<int, int> dct)
        {
            return dct.Key > dct.Value;
        }

    }
}
