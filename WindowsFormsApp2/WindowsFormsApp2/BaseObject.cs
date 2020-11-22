using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp2 
{
    public abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            if (
                pos.X < 0 ||
                pos.Y < 0 ||
                pos.X > 1000 ||
                pos.Y > 1000 ||
                dir.X < -600 ||
                dir.Y < -600 ||
                dir.X > 600 ||
                dir.Y > 600 ||
                size.Width < 0 ||
                size.Height < 0 ||
                size.Width > 600 ||
                size.Height > 800
                )
            {
                throw new GameObjectException("Параметры заданны не верно", pos, dir, size);
            }
            else
            {
                Pos = pos;
                Dir = dir;
                Size = size;
            }
        }

        #region ICollision implementation

        public Rectangle Rect => new Rectangle(Pos, Size);

        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }
        #endregion
        public virtual void ReDraw(Point NewPosition)
        {
            this.Pos = NewPosition;
        }
        public abstract void Draw();

        public abstract void Update();
    }
}
/*          Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
 */
