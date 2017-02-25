using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndyneGame_1._12
{
    public partial class Form1 : Form
    {
        public enum From
        {
            Left, Right, Up, Down
        }

        public enum Position
        {
            Left, Right, Up, Down
        }

       
        public Position BladePos;
        public From SpearFrom1;
        public From SpearFrom2;
        public From SpearFrom3;
        public From SpearFrom4;
        private int _x1;
        private int _y1;
        private int _x2;
        private int _y2;
        private int _x3;
        private int _y3;
        private int _x4;
        private int _y4;
        private int Health = 100;
        private int Score = 0;
        Random rnd = new Random();
        public Form1()
        {
            _x1 = 425;
            _y1 = 127;
            _x2 = 0;
            _y2 = 127;
            _x3 = 200;
            _y3 = 0;
            _x4 = 200;
            _y4 = 300;
            SpearFrom1 = From.Right;
            SpearFrom2 = From.Left;
            SpearFrom3 = From.Up;
            SpearFrom4 = From.Down;
            InitializeComponent();

           
                
        }
  public void drawScore(int n, int x, int y, PaintEventArgs e)
  {
      int A, B, C, D, E, F, G;
      A = B = C = D = E = F = G = 0;
      if (n == 0)
      {
          A = B = C = E = F = G = 1;
      }
      if (n  == 1)
      {
          C = F = 1;
      }
            if (n  == 2)
            {
                A = C = D = E = G = 1;
            }
             if (n  == 3)
             {
                 A = C = D = F = G = 1;
             }
            if (n  == 4)
            {
                B = C = D = F = 1;
            }
            if (n  == 5)
            {
                A = B = D = F = G = 1;
            }
             if (n  == 6)
             {
                 A = B = D = E = F = G = 1;
             }
            if (n  == 7)
            {
                A = C = F = 1;
            }
            if (n  == 8)
            {
                A = B = C = D = E = F = G = 1;
            }
            if (n == 9)
            {
                A = B = C = D = F = 1;
            }
         

      if (A == 1)
      {
          e.Graphics.FillRectangle(Brushes.Green, x+3, y, 5, 1);
      }
            if (B == 1)
            {
                e.Graphics.FillRectangle(Brushes.Green, x, y+3, 1, 5);
            }
            if (C == 1)
            {
                e.Graphics.FillRectangle(Brushes.Green, x+10, y+3, 1, 5);
            }
            if (D == 1)
            {
                e.Graphics.FillRectangle(Brushes.Green, x+3, y+9, 5, 1);
            }
            if (E == 1)
            {
                e.Graphics.FillRectangle(Brushes.Green, x, y+11, 1, 5);
            }
           if (F == 1)
            {
                e.Graphics.FillRectangle(Brushes.Green, x+10, y+11, 1, 5);
            }
          if (G == 1)
            {
                e.Graphics.FillRectangle(Brushes.Green, x+3, y+17, 5, 1);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawScore(Score/1 % 10, 362, 10, e);
            drawScore(Score / 10 % 10, 348, 10, e);
            drawScore(Score / 100 % 10, 334, 10, e);
            drawScore(Score / 1000 % 10, 320, 10, e);
            drawScore(Score / 10000 % 10, 306, 10, e);
            drawScore(Score / 100000 % 10, 292, 10, e);

            e.Graphics.FillRectangle(Brushes.DarkBlue, _x1, _y1, 10, 1);
           // e.Graphics.FillRectangle(Brushes.DarkBlue, _x2, _y2, 10, 1);
           // e.Graphics.FillRectangle(Brushes.DarkBlue, _x3, _y3, 10, 1);
          //  e.Graphics.FillRectangle(Brushes.DarkBlue, _x4, _y4, 10, 1);

            e.Graphics.FillRectangle(Brushes.Red, 45, 235, Health*3, 3);
            e.Graphics.FillRectangle(Brushes.Red,195,125, 5, 5);

            if (BladePos == Position.Left)
            {
                e.Graphics.FillRectangle(Brushes.Blue, 175, 115, 1, 24);
            }
            else if (BladePos == Position.Right)
            {
                e.Graphics.FillRectangle(Brushes.Blue, 218, 115, 1, 24);
            }
            else if (BladePos == Position.Up)
            {
                e.Graphics.FillRectangle(Brushes.Blue, 185, 105, 24, 1);
            }
            else if (BladePos == Position.Down)
            {
                e.Graphics.FillRectangle(Brushes.Blue, 185, 145, 24, 1);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w' || e.KeyChar == 'W')
            {
                BladePos = Position.Up;
            }
            else if (e.KeyChar == 'd' || e.KeyChar == 'D')
            {
                BladePos = Position.Right;
            }
            else if (e.KeyChar == 's' || e.KeyChar == 'S')
            {
                BladePos = Position.Down;
            }
            else if (e.KeyChar == 'a' || e.KeyChar == 'A')
            {
                BladePos = Position.Left;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         if (Health == 0)
         {
                Application.Exit();
         }

            if (SpearFrom1 == From.Right)
            {
                _x1 -= 3;
                if (_x1 <= 218 && BladePos != Position.Right)
                {
                    
                    Health -= 10;
                    _x1 = 424;
                }else if (_x1 <= 218 && BladePos == Position.Right)
                {
                    Score += 1;
                     _x1 = 424;
                }


            }
            if (SpearFrom2 == From.Left)
            {
              //  _x2 += 3;
                if (_x2 >= 175 && BladePos != Position.Left)
                {

                    Health -= 10;
                    _x2 = rnd.Next(-20, 0);
                }
                else if (_x2 >= 175 && BladePos == Position.Left)
                {
                    Score += 1;
                   // _x2 = rnd
                }


            }
            if (SpearFrom3 == From.Up)
            {
            //    _y3 -= 3;
                if (_y3 >= 105 && BladePos != Position.Up)
                {

                    Health -= 10;
                    _y3 = 0;
                }
                else if (_y3 >= 105 && BladePos == Position.Up)
                {
                    Score += 1;
                    _y3 = 0;
                }


            }
            if (SpearFrom4 == From.Down)
            {
            //    _y4 += 3;
                if (_y4 <= 145 && BladePos != Position.Down)
                {

                    Health -= 10;
                    _y4 = 300;
                }
                else if (_y4 <= 145 && BladePos == Position.Down)
                {
                    Score += 1;
                    _y4 = 300;
                }


            }
            Invalidate();
        }

       

       
    }
}
