using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp2
{
    class comet : BaseObject
    {
        public Image img { get; set; }
        public comet(Point pos, Point dir, Size size) : base (pos, dir, size)
        {
            img = WindowsFormsApp2.Properties.Resources.comet6;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(img, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
        }

        public override void Update()
        {
         Pos.X = Pos.X + Dir.X;
         Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < -200)
            {
                Pos.X = 400;
                Pos.Y = 500;
                //Dir.Y *= -1;
                //Dir.X *= -1;
                //img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            //if (Pos.Y > 700)
            //{
               // Dir.Y *= -1;
                //Dir.X *= -1;
                //img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //}
            

        }
    }
}
