using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace alecHUndreds
{
    public class Ball
    {
        public int _x;
        public int _y;
        public int _speedx;
        public int _speedy;
        int _width;
        int _height;
        private Brush _color;
        private Brush _originalColor;
        public Rectangle Hitbox;
        public float count = 0;

        public Ball(int x, int y, int speedx, int speedy, int width, int height, Brush color)
        {
            _x = x;
            _y = y;
            _speedx = speedx;
            _speedy = speedy;
            _width = width;
            _height = height;
            _color = color;
            _originalColor = _color;
            Hitbox = new Rectangle(_x, _y, _width, _height);
        }

        public void draw(Graphics gfx)
        {
            gfx.FillEllipse(_color, _x, _y, _width, _height);

        }

        public void move(Size ClientSize, Rectangle mouseHitBox)
        {

            if (Hitbox.Contains(mouseHitBox))
            {
                _color = Brushes.Red;
                _width++;
                _height++;
                count += 0.5f;
            }
            else
            {
                _color = _originalColor;
            }

            if (_x <= 0)
            {
                _speedx *= -1;
            }

            if (_x >= ClientSize.Width - _width)
            {
                _speedx *= -1;
            }

            if (_y <= 0)
            {
                _speedy *= -1;
            }
            if (_y >= ClientSize.Height - _height)
            {
                _speedy *= -1;
            }

            _x += _speedx;
            Hitbox.X = _x;
            _y += _speedy;
            Hitbox.Y = _y;
            Hitbox.Width = _width;
            Hitbox.Height = _height;
        }

        public void erase(Brush BackColor, Graphics gfx)
        {
            gfx.FillEllipse(BackColor, _x, _y, _width, _height);
        }
    }
}

