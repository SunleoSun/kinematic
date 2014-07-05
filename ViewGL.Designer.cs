using System;
using System.Text;
using System.Windows.Forms;

namespace OpenGL
{
    partial class ViewGL
    {

        uint mDC = 0;
        protected uint DC
        {
            get { return mDC;  }
            set { mDC = value; }
        }

        uint mRC = 0;
        protected uint RC
        {
            get { return mRC;  }
            set { mRC = value; } 
        }

        uint mhWnd = 0;
        protected uint hWnd
        {
            get { return mhWnd;  }
            set { mhWnd = value; }
        }

        uint mnFont = 0;
        protected uint nFont
        {
            get { return mnFont; }
            set { mnFont = value; }
        }

        protected virtual void BeginOpenGL(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.ResizeRedraw, true);

            hWnd = (uint)this.Handle.ToInt32();
            DC = WGL.GetDC(this.hWnd);

            WGL.PIXELFORMATDESCRIPTOR pfd = new WGL.PIXELFORMATDESCRIPTOR();
            WGL.ZeroPixelDescriptor(ref pfd);
            pfd.nVersion = 1;
            pfd.dwFlags = (WGL.PFD_DRAW_TO_WINDOW | WGL.PFD_SUPPORT_OPENGL | WGL.PFD_DOUBLEBUFFER);
            pfd.iPixelType = (byte)(WGL.PFD_TYPE_RGBA);
            pfd.cColorBits = 32;
            pfd.cDepthBits = 32;
            pfd.iLayerType = (byte)(WGL.PFD_MAIN_PLANE);


            int pixelFormat = 0;
            pixelFormat = WGL.ChoosePixelFormat(DC, ref pfd);
            WGL.SetPixelFormat(DC, pixelFormat, ref pfd);
            RC = WGL.wglCreateContext(DC);
            WGL.wglMakeCurrent(DC, RC);

            GL.glClearColor(0, 0, 0, 0);

            LoadFont();

        }

        protected void EndOpenGL()
        {
            WGL.wglMakeCurrent(0, 0);
            WGL.wglDeleteContext(RC);
            WGL.ReleaseDC(hWnd, DC);
        }

        protected void LoadFont()
        {
            nFont = GL.glGenLists(1);
            WGL.wglUseFontBitmaps(DC, 0, 256, nFont);
        }

        protected void OutText(string s, double x, double y)
        {
            OutText(s, x, y, 0);
        }

        protected void OutText(string s, double x, double y, double z)
        {
            // Create two different encodings.
            Encoding ascii = Encoding.GetEncoding(1251);
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte[].
            byte[] unicodeBytes = unicode.GetBytes(s);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            GL.glListBase(nFont);
            GL.glRasterPos3d(x, y, z);
            GL.glCallLists(s.Length, GL.GL_UNSIGNED_BYTE, asciiBytes);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {

            EndOpenGL();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ViewGL
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "ViewGL";
            this.Size = new System.Drawing.Size(179, 207);
            this.Load += new System.EventHandler(this.BeginOpenGL);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewGL_Paint);
            this.Resize += new System.EventHandler(this.ViewGL_Resize);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
