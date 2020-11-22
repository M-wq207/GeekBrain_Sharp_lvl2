using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Leson2
{
    class Program
    {
        interface ICollision
        {
            bool Collision(ICollision obj);
            Rectangle Rect { get; }

        }
        static void Main(string[] args)
        {
        }
    }
}
