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
            if (
                pos.X < 0 ||
                pos.Y < 0 ||
                pos.X > 1000 ||
                pos.Y > 1000 ||
                dir.X < -600 ||
                dir.Y < -600 ||
                dir.X > 600 ||
                dir.Y > 600 ||
                size.Width < 0 ||
                size.Height < 0 ||
                size.Width > 600 ||
                size.Height > 800
                )
            {
                throw new GameObjectException("Параметры заданны не верно", pos, dir, size);
            }
            else
            {
                Pos = pos;
                Dir = dir;
                Size = size;
            }
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
