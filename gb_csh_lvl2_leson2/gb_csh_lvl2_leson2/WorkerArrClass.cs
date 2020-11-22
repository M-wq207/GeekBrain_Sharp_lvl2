using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_csh_lvl2_leson2
{
    static class WorkerArrClass
    {
        
        private static BaseWorkerObj[] WorkerArr = new BaseWorkerObj[11]
            {
                new FixedPayWorkers("Иван", true, 3000),
                new FixedPayWorkers("Дмитрий", true, 4000),
                new FixedPayWorkers("Евгений", true, 3500),
                new FixedPayWorkers("Алексей", true, 6000),
                new FixedPayWorkers("Екатерина", true, 1110),
                new FixedPayWorkers("Елена", true, 2500),
                new FlexPayWorkers("Сергей", false, 20),
                new FlexPayWorkers("Мария", false, 30),
                new FlexPayWorkers("Валерия", false, 22),
                new FlexPayWorkers("Пётр", false, 17),
                new FlexPayWorkers("Алекс", false, 33)
            };
        public static void ArrPrint()
        {
            foreach (BaseWorkerObj a in WorkerArr) Console.WriteLine(a);
        }
        public static void ArrSort()
        {
            Array.Sort(WorkerArr);
        }
    }
}
