using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


//Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полет в звездном пространстве.

namespace WindowsFormsApp2
{
   
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var form = new Form()
            {
                MinimumSize = new System.Drawing.Size(800, 600),
                MaximumSize = new System.Drawing.Size(800, 600),
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Asteroids"
            };
            Game.Init(form);
            form.Show();
            Game.Drow();
            Application.Run(form);

        }
    }
}
