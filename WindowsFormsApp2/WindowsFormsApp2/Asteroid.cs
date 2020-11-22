using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Asteroid : BaseObject
    {
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size){}
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(WindowsFormsApp2.Properties.Resources.asteroid01, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);

        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;

        }
    }
}
