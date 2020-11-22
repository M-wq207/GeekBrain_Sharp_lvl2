using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp2
{
    public static class SplashScreen
    {
        static Point StationStartPoint = new Point(450, 450);
        static Point PlanetStartPoint = new Point(200, 200);
        private static SpaceStation station = new SpaceStation(StationStartPoint, new Point(0,0), new Size(70, 70), WindowsFormsApp2.Properties.Resources.station3);
        private static SpaceShip ship = new SpaceShip(new Point(300, 300), new Point(10, 10), new Size(50, 50), WindowsFormsApp2.Properties.Resources.ship2, PlanetStartPoint, StationStartPoint);

        public static void drawAll()
            {                
                station.Draw();
                ship.Draw();
        }
        public static void updateAll()
        {
            ship.Update();
        }
    }
}
