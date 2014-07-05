using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using OpenGL;

namespace glWinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        bool MouseDowns = false;
        double Xdown = 0;
        double Ydown = 0;

        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            MouseDowns = true;
            Xdown = e.X;
            Ydown = e.Y;
        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (MouseDowns)
            {
                double Xcurrent = e.X;
                double Ycurrent = e.Y;

                double length_x = Xcurrent - Xdown;
                double length_y = Ycurrent - Ydown;
                view.RotateAllOX = (int)length_x / 2;
                view.RotateAllOY = (int)length_y / 2;
                view.Invalidate();
            }
        }

        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            MouseDowns = false;
        }
        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            view.ScaleFactor += 0.1 * Math.Sign(e.Delta);
            view.Invalidate();
        }
        private void Key_Pressed1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                view.RotateRedLineAngle += 1;
            }
            if (e.KeyData == Keys.Left)
            {
                view.RotateRedLineAngle -= 1;
            }
            if (e.KeyData == Keys.Up)
            {
                view.RotateAllLinesOZ += 2;
            }
            if (e.KeyData == Keys.Down)
            {
                view.RotateAllLinesOY += 2;
            }
            view.Invalidate();
        }


    }
}
