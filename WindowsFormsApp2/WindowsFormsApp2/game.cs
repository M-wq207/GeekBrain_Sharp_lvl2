using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp2
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        static Asteroid[] _asteroids;
        static Asteroid[] _stars;
        private static comet comet = new comet(new Point(400, 500), new Point(-30, -30), new Size(50, 50));


        public static int Width { get; set; }
        public static int Height { get; set; }


        static Game() { }

        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer() { Interval = 1 };
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Drow();
            Update();
        }

        public static void Drow()
        {
            Buffer.Graphics.Clear(Color.Black);

            //фон
            Buffer.Graphics.DrawImage(new Bitmap(WindowsFormsApp2.Properties.Resources.space_background, new Size(800, 600)), 0, 0);

            //звезды
            foreach (Star obj in _stars)
            {
                obj.Draw();
            }

            //планета
            Buffer.Graphics.DrawImage(new Bitmap(WindowsFormsApp2.Properties.Resources.planet, new Size(200, 200)), 200, 200);


            //астероиды
            foreach (Asteroid obj in _asteroids)
            {
                obj.Draw();
            }
            //комета
            comet.Draw();

            SplashScreen.drawAll();


            Buffer.Render();
        }

        public static void Update()
        {
            foreach (var obj in _asteroids)
            {
                obj.Update();
            }
            foreach (var obj in _stars)
            {
                obj.Update();
            }
            comet.Update();
            SplashScreen.updateAll();
        }

        public static void Load()
        {
            var random = new Random();
            _asteroids = new Asteroid[15];

            //заполняем массив астероидов 
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var size = random.Next(10, 40);
                _asteroids[i] = new Asteroid(new Point(600, i*20), new Point(-i, -i), new Size(size, size));
            }

            //заполняем массив звезд
            _stars = new Asteroid[20];
            for (int i = 0; i < _stars.Length; i++)
            {
                var size = random.Next(10, 40);
                _stars[i] = new Star(new Point(600, i * 40), new Point(-i, -i), new Size(25, 25));
            }

            //создаем комету
            //var comet = new comet(new Point(400, 0), new Point(800, 0), new Size(10, 10));
        }
    }
}
