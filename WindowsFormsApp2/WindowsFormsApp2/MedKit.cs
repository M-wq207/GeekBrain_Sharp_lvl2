using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp2
{
    class MedKit : BaseObject
    {
        public MedKit(Point pos, Point dir, Size size) : base(pos, dir, size) { }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(WindowsFormsApp2.Properties.Resources.first_aid_kit, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);

        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
