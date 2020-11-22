using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp2
{
    
    class SpaceShip : SpaceTechObj
    {
        Point PlanetPos = new Point();
        Point StationPos = new Point();
        

        public SpaceShip(Point pos, Point dir, Size size, Image img, Point planetPos, Point stationPos) : base(pos, dir, size, img) 
        {
            PlanetPos = planetPos;
            StationPos = stationPos;
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < PlanetPos.X +20)
            {
                Dir.Y *= -1;
                Dir.X *= -1;
                this.Img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            if (Pos.Y > StationPos.Y)
            {
                Dir.Y *= -1;
                Dir.X *= -1;
                this.Img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
        }
    }
}
