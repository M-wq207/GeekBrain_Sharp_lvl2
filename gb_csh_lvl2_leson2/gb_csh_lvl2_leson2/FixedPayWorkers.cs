using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_csh_lvl2_leson2
{
    internal class FixedPayWorkers : BaseWorkerObj
    {
        public FixedPayWorkers(String name, bool pt, double pay) : base (name, pt, pay) { }
        internal override double PayMonthCalc()
        {
            return Pay;
        }
    }

    
}
