using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApp2
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        static BaseObject[] _asteroids;
        static BaseObject[] _stars;
        static MedKit medkit;
        //static Bullet _bullet;
        private static List<Bullet> _bullets = new List<Bullet>();
        private static Timer timer;
        public static Ship _ship = new Ship(new Point(10, 400), new Point(5,5), new Size(40, 40));
        private static comet comet = new comet(new Point(400, 500), new Point(-30, -30), new Size(50, 50));
        //
        public delegate void mainWindowDelegate();
        public static mainWindowDelegate hit;
        public static mainWindowDelegate newGame;
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

            timer = new Timer() { Interval = 1 };
            timer.Tick += Timer_Tick;
            timer.Start();

            //проверка, что размер окна не привышает 1000
            try
            {
                if (form.Size.Width > 1000 || form.Size.Height > 1000) throw new ArgumentOutOfRangeException();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            //доработки 3его урока:
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
            //дз 3 урока:
            Ship.DamagedByAsteroid += Damaged;
            hit += destroy;
            newGame += ng;
            Ship.hill += Hill;

        }
        #region func for delegates
        private static void ng()
        {
            string str = $"Новая игра\n";
            Debug.WriteLine(str);
            SaveToLogFile(str);

        }
        private static void destroy()
        {
            string str = $"Астероид унечтожен!\n";
            Debug.WriteLine(str);
            SaveToLogFile(str);


        }
        private static void Finish()
        {
            timer.Stop();
            string str = "The End!\n";
            Buffer.Graphics.DrawString(str, new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            SaveToLogFile(str);
            Buffer.Render();
        }
        private static void Hill(int n)
        {
            string str = $"Подобранна аптечка, добавленно 20 едениц энергии.\n";
            Debug.WriteLine(str);
            SaveToLogFile(str);
        }
        private static void Damaged(int n)
        {
            string str = $"Столкновение с астероидом! Потерянно {n} энергии.\n";
            Debug.WriteLine(str);
            SaveToLogFile(str);
        }
        private static void SaveToLogFile(string str)
        {
            string path = @".\log.txt";
            File.AppendAllText(path, str);
        }
        #endregion
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _bullets.Add(new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 20), new Point(5, 0), new Size(30, 30)));
            }
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Drow();
            Update();
        }

        public static void Drow()
        {
            try
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
                    if (obj != null)obj.Draw();
                }

                //комета
                comet.Draw();

                //отрисовка фоновых объектов: курсирующего корабля и кос. станции
                SplashScreen.drawAll();

               //пули
               foreach(var bullet in _bullets)
                {
                    bullet.Draw();
                }

               //корабль
                if (_ship != null) _ship.Draw();

                //отображение количества энергии
                if (_ship != null) Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
                if (_ship != null) Buffer.Graphics.DrawString("Score:" + _ship.Point, SystemFonts.DefaultFont, Brushes.White, 0, 10);


                //аптечка
                medkit?.Draw();
                //оставлять последним
                Buffer.Render();
            }
            catch (GameObjectException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static void Update()
        {
            foreach (var bullet in _bullets)
            {
                bullet.Update();
            }
            for (int i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();

                for (int j = 0; j < _bullets.Count; j++)
                {
                    if (_asteroids[i] != null && _bullets[j].Collision(_asteroids[i]))
                    {
                        hit();
                        _ship.PointsUp();
                        System.Media.SystemSounds.Hand.Play();
                        _asteroids[i] = null;
                        _bullets.RemoveAt(j);
                        j--;
                    }
                }

                for (int j = 0; j < _bullets.Count; j++)
                {
                    if (medkit != null && _bullets[j].Collision(medkit))
                    {
                        //hit();
                        _ship.EnergyUp(20);
                        System.Media.SystemSounds.Hand.Play();
                        medkit = null;
                        _bullets.RemoveAt(j);
                        j--;
                        
                    }
                }
                //if (_bullet != null && _bullet.Collision(_asteroids[i]))
                //{
                //    System.Media.SystemSounds.Hand.Play();
                //    _asteroids[i] = null;
                //    _bullet = null;
                //    continue;
                //}

                /*if (obj.Collision(_bullet))
                {
                    _bullet.ReDraw(new Point (0, 200));
                    obj.ReDraw(new Point(550, 200));
                    System.Media.SystemSounds.Hand.Play();
                    Debug.WriteLine($"коллизия");
                }
                */
                if (_asteroids[i] == null || !_ship.Collision(_asteroids[i])) continue;
                var rnd = new Random();
                _ship.EnergyLow(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship.Die();
            }

            //
            foreach (var obj in _stars)
            {
                obj.Update();
            }
            comet.Update();

            //if (_bullet != null)_bullet.Update();

            SplashScreen.updateAll();
            //
        }

        public static void Load()
        {

            ng();
            //_bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(30, 30));
            var random = new Random();
            _asteroids = new Asteroid[15];

            //заполняем массив астероидов 
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var size = random.Next(10, 40);
                _asteroids[i] = new Asteroid(new Point(600, i*20), new Point(-i, -i), new Size(size, size));
            }

            //заполняем массив звезд
            _stars = new Star[20];
            for (int i = 0; i < _stars.Length; i++)
            {
                var size = random.Next(10, 40);
                _stars[i] = new Star(new Point(600, i * 40), new Point(-i, -i), new Size(25, 25));
            }
            medkit = new MedKit(new Point(700, 400), new Point(1, 1), new Size(32, 32));
            //создаем комету
            //var comet = new comet(new Point(400, 0), new Point(800, 0), new Size(10, 10));
        }
    }
}
