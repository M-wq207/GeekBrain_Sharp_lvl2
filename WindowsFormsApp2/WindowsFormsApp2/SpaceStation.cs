using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp2
{
    class SpaceStation : SpaceTechObj
    {

        public SpaceStation(Point pos, Point dir, Size size, Image img) : base(pos, dir, size, img) { }

        public override void Update()
        {
            base.Update();
        }
    }
}