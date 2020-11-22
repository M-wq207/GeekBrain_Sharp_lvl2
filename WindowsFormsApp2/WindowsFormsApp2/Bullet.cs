using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp2
{
    public class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(WindowsFormsApp2.Properties.Resources.bullet, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);

        }
        public override void Update()
        {
            Pos.X = Pos.X + 30;
            if (Pos.X > 800) Pos.X = 0;
        }
    }
}
