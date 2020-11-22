using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp2
{
    class GameObjectException : Exception
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected string Message;
        public GameObjectException(string message, Point pos, Point dir, Size size)
        {
            Message = message;
            Pos = pos;
            Dir = dir;
            Size = size;
        }
    }
}
