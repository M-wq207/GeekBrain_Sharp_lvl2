using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_csh_lvl2_leson2
{
    abstract class BaseWorkerObj : IComparable <BaseWorkerObj>
    {
        internal string Name { get; }
        internal bool PayType { get; }
        internal double PayMonth { get; }
        internal double Pay {get;}


        protected BaseWorkerObj (String name, bool pt, double pay)
        {
            Name = name;
            PayType = pt;
            Pay = pay;
            PayMonth = PayMonthCalc();
        }
        public override string ToString()
        {
            string PayTypeStr = PayType ? "Фиксированная" : "Почасовая";
            return $"Имя: {Name} \t Тип зарплаты: {PayTypeStr} \t Месячный оклад: {PayMonth}";
        }
        internal abstract double PayMonthCalc();

        public int CompareTo(BaseWorkerObj other)
        {
            return (int)this.PayMonth - (int)other.PayMonth;
        }
    }
}
