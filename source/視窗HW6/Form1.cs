using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace 視窗HW6
{
    public partial class Form1 : Form
    {
        Image banana = Properties.Resources.Banana;
        Image bowl = Properties.Resources.Bowl;
        Image strawberry = Properties.Resources.StawBerry;
        Image tomato = Properties.Resources.Tomato;
        Image egg1 = Properties.Resources.C0iEi37;
        Image egg2 = Properties.Resources.XT5Bh4j;
        Image egg1thumb;
        Image egg2thumb;
        Image[] fruit = new Image[3];
        int a = 120;
        int timeforbackpicture = 0;
        int numforbackpicture = 0;
        Random rd = new Random();
        int x1, y1, speed1;
        int x2, y2;
        int x3, y3;
        int mouseposx;
        int catchnum;
        int x, y;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            egg1thumb = egg1.GetThumbnailImage(500, (int)(500 * egg1.Height / egg1.Width), null, (IntPtr)0);
            egg2thumb = egg2.GetThumbnailImage(500, (int)(500 * egg1.Height / egg1.Width), null, (IntPtr)0);
            if(egg1thumb != null && egg2thumb != null)
            {
                float[][] cmarray = 
                {
                  new float[] {1, 0, 0, 0,    0},
                  new float[] {0, 1, 0, 0,    0},
                  new float[] {0, 0, 1, 0,    0},
                  new float[] {0, 0, 0, 0.3f, 0},
                  new float[] {0, 0, 0, 0,    1}

                };
                ColorMatrix cm = new ColorMatrix(cmarray);
                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                if (numforbackpicture == 1)
                {
                    Rectangle recdest = new Rectangle(0, 0, egg1thumb.Width, egg1thumb.Height);
                    e.Graphics.DrawImage(egg1thumb, recdest, 0, 0, egg1thumb.Width, egg1thumb.Height, GraphicsUnit.Pixel, ia);
                }
                if (numforbackpicture == 2)
                {
                    Rectangle recdest = new Rectangle(0, 0, egg2thumb.Width, egg2thumb.Height);
                    e.Graphics.DrawImage(egg2thumb, recdest, 0, 0, egg2thumb.Width, egg2thumb.Height, GraphicsUnit.Pixel, ia);
                }

                Rectangle bananadest = new Rectangle(x1, y1, banana.Width, banana.Height);
                e.Graphics.DrawImage(banana, bananadest);

                Rectangle strawberrydest = new Rectangle(x2, y2, strawberry.Width, strawberry.Height);
                e.Graphics.DrawImage(strawberry, strawberrydest);

                Rectangle tomatodest = new Rectangle(x3, y3, tomato.Width, tomato.Height);
                e.Graphics.DrawImage(tomato, tomatodest);

                Rectangle bowldest = new Rectangle(mouseposx, 280, bowl.Width, bowl.Height);
                e.Graphics.DrawImage(bowl, bowldest);

               
             
            }
            
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeforbackpicture % 10 == 0)
            {
                if (numforbackpicture == 2)
                    numforbackpicture = 0;
                numforbackpicture++;
                this.Invalidate();
            }
            timeforbackpicture++;  
            a--;
            label2.Text = a + "seconds";
            
            
            
            if (a == 0)//所有的時間都要暫停
            {
                timer1.Stop();
                timer2.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer2.Interval = 500;
            timer1.Start();
            timer2.Start();
            label2.Text = a + "seconds";
            this.ClientSize = new Size(500, 400);
            catchnum = 0;
            speed1 = 30;

            x1 = rd.Next(0, 450);
            y1 = rd.Next(1, 20);
            y1 = -y1;
            x2 = rd.Next(0,450);
            y2 = rd.Next(1,100);
            y2 = -y2;
            x3 = rd.Next(0, 450);
            y3 = rd.Next(1, 100);
            y3 = -y3;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            a = 120;
            timeforbackpicture = 0;
            numforbackpicture = 0;
            x1 = rd.Next(0, 400);
            y1 = rd.Next(1, 20);
            y1 = -y1;
            x2 = rd.Next(0, 400);
            y2 = rd.Next(1, 100);
            y2 = -y2;
            x3 = rd.Next(0, 400);
            y3 = rd.Next(1, 100);
            y3 = -y3;
            timer1.Start();
            timer2.Start();
            catchnum = 0;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            fruit[0] = banana;
            fruit[1] = strawberry;
            fruit[2] = tomato;

            y1 += speed1;
            y2 += speed1;
            y3 += speed1;
            if (x1 >= mouseposx && (x1 + 24) <= (mouseposx + 70) && (y1 + 35) >= 280 && y1 < 280)
            {
                y1 += 500;
                catchnum++;
            }

            if (x2 >= mouseposx && (x2 + 38) <= (mouseposx + 70) && (y2 + 40) >= 280 && y2 < 280)
            {
                y2 += 500;
                catchnum++;
            }

            if (x3 >= mouseposx && (x3 + 38) <= (mouseposx + 70) && (y3 + 40) >= 280 && y3<280)
            {
                y3 += 500;
                catchnum++;
            }
            if (y1 >= 280 && y2 >= 280 && y3 >= 280)
            {
                x1 = rd.Next(0, 400);
                y1 = rd.Next(1, 20);
                y1 = -y1;
                x2 = rd.Next(0, 400);
                y2 = rd.Next(1, 100);
                y2 = -y2;
                x3 = rd.Next(0, 400);
                y3 = rd.Next(1, 100);
                y3 = -y3;
 
            }
            label4.Text = catchnum.ToString();
            this.Invalidate();
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseposx = e.X;
            if ((e.X + 70) >= 500)
                mouseposx = 430;
            this.Invalidate();
        }
    }
}
