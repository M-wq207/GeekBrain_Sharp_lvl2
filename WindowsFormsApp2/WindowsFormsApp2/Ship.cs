using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp2
{
    class Ship : BaseObject
    {
        private int _energy = 100;
        private int _point = 0;
        public static event Message MessageDie;
        public static event backlog DamagedByAsteroid;
        public static event backlog hill;
        public int Energy => _energy;
        public int Point => _point;
        public void PointsUp()
        {
            _point += 10;
        }
        public void EnergyLow(int n)
        {
            DamagedByAsteroid?.Invoke(n);
            _energy -= n;
        }
        public void EnergyUp(int n)
        {
            hill?.Invoke(n);
            _energy += n;
        }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size) { }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(WindowsFormsApp2.Properties.Resources.ship2, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }

        public void Die()
        {
            MessageDie?.Invoke();
           //if (MessageDie != null) MessageDie.Invoke();
        }
    }
}
