using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp2
{
    public class SpaceTechObj
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected Image Img;
        public SpaceTechObj (Point pos, Point dir, Size size, Image img)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            Img = img;
        }
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Img, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
        }
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
        }
    }
}
