using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace alecHUndreds
{
    public partial class Form1 : Form
    {
        int mousePositionX;
        int mousePositionY;
        public List<Ball> balls;
        Random rand;
        Graphics gfx;
        Bitmap spriteBatch;
       int total = 0;
        Rectangle mouseHitBox;

        public Form1()
        {
            InitializeComponent();
            balls = new List<Ball>();
            rand = new Random();
            spriteBatch = new Bitmap(ClientSize.Width, ClientSize.Height);
            mouseHitBox = new Rectangle(mousePositionX, mousePositionY, 1, 1);
            gfx = Graphics.FromImage(spriteBatch);


            for (int i = 0; i < 10; i++)
            {
                balls.Add(new Ball(rand.Next(0, ClientSize.Width - 30), rand.Next(0, ClientSize.Height - 30), 2, 2, 30, 30, new SolidBrush(Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)))));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label1.Text = total.ToString();
            total = 0;
            for (int i = 0; i < balls.Count; i++)
            {
                total += (int)balls[i].count;
            }
            if (total >= 100)
            {
                //Debugger.Break();
                timer1.Enabled = false;
                MessageBox.Show("You win!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Close();
            }
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].erase(new SolidBrush(BackColor), gfx);
            }

            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].move(ClientSize, mouseHitBox);
            }


            //check collisions
          
                for (int i = 0; i < balls.Count; i++)
                {
                    if (balls[i].Hitbox.Contains(mouseHitBox))
                    {
                    for (int j = 0; j < balls.Count; j++)
                    {
                        if (i != j)
                        {
                            //check collisions
                            if (balls[i].Hitbox.IntersectsWith(balls[j].Hitbox))
                            {
                                timer1.Enabled = false;
                                MessageBox.Show("You lose");
                                Close();

                            }
                        }
                    }
                }
            }



                mouseHitBox.X = mousePositionX;
                mouseHitBox.Y = mousePositionY;

            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].draw(gfx);
            }

            gameScreen.Image = spriteBatch;
        }

        private void gameScreen_MouseMove(object sender, MouseEventArgs e)
        {
            mousePositionX = e.X;
            mousePositionY = e.Y;
        }
    }
}
