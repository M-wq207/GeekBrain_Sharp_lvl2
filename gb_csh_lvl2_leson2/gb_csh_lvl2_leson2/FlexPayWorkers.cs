using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_csh_lvl2_leson2
{
    class FlexPayWorkers : BaseWorkerObj
    {
        public FlexPayWorkers(String name, bool pt, double pay) : base(name, pt, pay) { }

        internal override double PayMonthCalc()
        {
            return Pay * 8 * 20.8;
        }
    }
}
