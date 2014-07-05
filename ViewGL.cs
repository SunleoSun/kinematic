using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenGL
{
    public partial class ViewGL : UserControl
    {
        public ViewGL()
        {
            InitializeComponent();
        }

        double scale_factor;
        public double ScaleFactor
        {
            get { return scale_factor; }
            set { scale_factor = value; }
        }
        int rotate_all_lines_oz = 0;
        public int RotateAllLinesOZ
        {
            get { return rotate_all_lines_oz; }
            set { rotate_all_lines_oz = value; }
        }
        int rotate_all_lines_oy;
        public int RotateAllLinesOY
        {
            get { return rotate_all_lines_oy; }
            set { rotate_all_lines_oy = value; }
        }
        int rotate_all_ox;
        public int RotateAllOX
        {
            get { return rotate_all_ox; }
            set { rotate_all_ox = value; }
        }
        int rotate_all_oy;
        public int RotateAllOY
        {
            get { return rotate_all_oy; }
            set { rotate_all_oy = value; }
        }
        int small_fi;
        public int SmallFi
        {
            get { return small_fi; }
            set { small_fi = value; }
        }
        int large_fi;
        public int LargeFi
        {
            get { return large_fi; }
            set 
            {
                if (large_fi<88 && large_fi > -60)
                    large_fi = value; 
            }
        }
        int rotate_red_line_angle;
        public int RotateRedLineAngle
        {
            get { return rotate_red_line_angle; }
            set
            {
                if (-54 < value && value < 90)
                {
                    rotate_red_line_angle = value;
                }
           }
        }
        int teta;
        public int Teta
        {
            get { return teta; }
            set 
{
                if(teta > -30 && teta < 30) 
                    teta = value; 
            }
        }



        private double[] MultiplyMatrixs3x3(double[] matrix1, double[] matrix2)
        {
            if (matrix1.Length != 9 || matrix2.Length != 9)
            {
                return null;
            }

            int count = 0;
            double[] ResultMatrix = new double[matrix1.Length];
            for (int z = 0; z < matrix1.Length; z += 3)
            {
                for (int x = 0; x < 3; x++)
                {
                    count = 0;
                    for (int y = 0; y < matrix2.Length; y += 3)
                    {
                        ResultMatrix[x + z] += matrix1[z + count] * matrix2[x + y];
                        count++;
                    }
                }
            }
            return ResultMatrix;
        }
        private double[] MultiplyMatrixs4x4(double[] matrix1, double[] matrix2)
        {
            if (matrix1.Length != 16 || matrix2.Length != 16)
            {
                return null;
            }

            int count = 0;
            double[] ResultMatrix = new double[matrix1.Length];
            for (int z = 0; z < matrix1.Length; z += 4)
            {
                for (int x = 0; x < 4; x++)
                {
                    count = 0;
                    for (int y = 0; y < matrix2.Length; y += 4)
                    {
                        ResultMatrix[x + z] += matrix1[z + count] * matrix2[x + y];
                        count++;
                    }
                }
            }
            return ResultMatrix;
        }

        //private double[] MultiplyMatrixs(double[] matrix1, double[] matrix2)
        //{
        //    if (matrix1.Length != 9 || matrix2.Length != 9)
        //    {
        //        return null;
        //    }

        //    long r, z, s, x, y;
        //    double[] ResultMatrix = new double[matrix1.Length];
        //    for (z = 0; z < matrix2.Length; z++)
        //    {
        //        x = Math.DivRem(z, 3, out y);
        //        for (s = 0; s < 3; s++)
        //        {
        //            ResultMatrix[z] += matrix1[3 * x + s] * matrix2[3 * s + y];
        //        }
        //    }
        //    return ResultMatrix;
        //}


        private void CalcYellowLine(int qObj)
        {
            double[] rotate_all_matrix = new double[]
                {Math.Cos(Math.PI/180 * RotateAllLinesOZ),-Math.Sin(Math.PI/180 * RotateAllLinesOZ),0,0,   
                   Math.Sin(Math.PI/180 * RotateAllLinesOZ),Math.Cos(Math.PI/180 * RotateAllLinesOZ),0,0,
                   0,0,1,0,
                   0,0,0,1};
            double[] rotate_all_matrix_oy = new double[]
                {Math.Cos(Math.PI/180 * RotateAllLinesOY),0,Math.Sin(Math.PI/180 * RotateAllLinesOY), 0,  
                   0,1,0,0,
                   -Math.Sin(Math.PI/180 * RotateAllLinesOY),0,Math.Cos(Math.PI/180 * RotateAllLinesOY), 0,
                   0,0,0,1};

            GL.glPushMatrix();
            GL.glMultMatrixd(rotate_all_matrix_oy);
            GL.glMultMatrixd(rotate_all_matrix);
            GL.glRotated(-90, 1, 0, 0);
            GLU.gluCylinder(qObj, 0.02, 0.02, 0.6, 10, 10);
            GL.glPopMatrix();

        }
        private void CalcGreenLine(int qObj)
        {
            //Применяем теорему косинусов
            double StartAngle = 180-((Math.Asin((0.3 * Math.Sin(Math.PI / 180 * 90)) / 0.4) * 180 / Math.PI) + 90);
            double AngleBCD = 180 - (90 - RotateRedLineAngle);
            double AngleDBC = Math.Asin((0.3 * Math.Sin(Math.PI / 180 * AngleBCD)) / 0.4) * 180 / Math.PI;
            double RotateGreenLineAngle =(StartAngle - (180 - (AngleBCD + AngleDBC)));
            double[] rotate_matrix = new double[]
                {Math.Cos(Math.PI/180 * RotateGreenLineAngle),-Math.Sin(Math.PI/180 * RotateGreenLineAngle),0,0,   
                   Math.Sin(Math.PI/180 * RotateGreenLineAngle),Math.Cos(Math.PI/180 * RotateGreenLineAngle),0,0,
                   0,0,1,0,
                   0,0,0,1};
            double[] rotate_all_matrix = new double[]
                {Math.Cos(Math.PI/180 * RotateAllLinesOZ),-Math.Sin(Math.PI/180 * RotateAllLinesOZ),0,0,   
                   Math.Sin(Math.PI/180 * RotateAllLinesOZ),Math.Cos(Math.PI/180 * RotateAllLinesOZ),0,0,
                   0,0,1,0,
                   0,0,0,1};
            double[] rotate_all_matrix_oy = new double[]
                {Math.Cos(Math.PI/180 * RotateAllLinesOY),0,Math.Sin(Math.PI/180 * RotateAllLinesOY), 0,  
                   0,1,0,0,
                   -Math.Sin(Math.PI/180 * RotateAllLinesOY),0,Math.Cos(Math.PI/180 * RotateAllLinesOY), 0,
                   0,0,0,1};

            GL.glPushMatrix();
            GL.glMultMatrixd(rotate_all_matrix_oy);
            GL.glMultMatrixd(rotate_all_matrix);
            GL.glTranslated(0, 0.3, 0);


            GL.glMultMatrixd(rotate_matrix);
            GL.glTranslated(-0.26, 0.3, 0);
            GLU.gluSphere(qObj, 0.04, 10, 10);
            GL.glTranslated(0.26, -0.3, 0);

            GL.glRotated(180+41.40, 0, 0, 1);

            GL.glRotated(90, 1, 0, 0);
            GLU.gluCylinder(qObj, 0.02, 0.02, 0.4, 10, 10);
            GL.glPopMatrix();

        }

        private void CalcRedLine(int qObj)
        {
            double[] rotate_matrix = new double[]
                {Math.Cos(Math.PI/180 * RotateRedLineAngle),-Math.Sin(Math.PI/180 * RotateRedLineAngle),0,0,   
                   Math.Sin(Math.PI/180 * RotateRedLineAngle),Math.Cos(Math.PI/180 * RotateRedLineAngle),0,0,
                   0,0,1,0,
                   0,0,0,1};
            double[] rotate_all_matrix_oz = new double[]
                {Math.Cos(Math.PI/180 * RotateAllLinesOZ),-Math.Sin(Math.PI/180 * RotateAllLinesOZ),0,0,   
                   Math.Sin(Math.PI/180 * RotateAllLinesOZ),Math.Cos(Math.PI/180 * RotateAllLinesOZ),0,0,
                   0,0,1,0,
                   0,0,0,1};
            double[] rotate_all_matrix_oy = new double[]
                {Math.Cos(Math.PI/180 * RotateAllLinesOY),0,Math.Sin(Math.PI/180 * RotateAllLinesOY),0,   
                   0,1,0,0,
                   -Math.Sin(Math.PI/180 * RotateAllLinesOY),0,Math.Cos(Math.PI/180 * RotateAllLinesOY),0,
                   0,0,0,1};

            GL.glPushMatrix();

            GL.glMultMatrixd(rotate_all_matrix_oy);
            GL.glMultMatrixd(rotate_all_matrix_oz);

            GL.glTranslated(-0.6, 0.6, 0);

            GL.glTranslated(0.6, 0, 0);
            GL.glMultMatrixd(rotate_matrix);
            GL.glTranslated(-0.6, 0, 0);

            GLU.gluSphere(qObj, 0.03, 10, 10);

            GL.glTranslated(1.5, 0, 0);
            GLU.gluSphere(qObj, 0.03, 10, 10);
            GL.glTranslated(-1.5, 0, 0);

            GL.glRotated(90, 0, 1, 0);

            GLU.gluCylinder(qObj, 0.03, 0.03, 1.5, 10, 10);
            GL.glPopMatrix();
        }
        private void ScaleAll()
        {
            double[] scale = new double[]
                {1,0,0,0,   
                   0,1,0,0,
                   0,0,1,0,
                   0,0,0,ScaleFactor+1};
            GL.glMultMatrixd(scale);
        }

        public void DrawLines(int qObj)
        {
            CalcRedLine(qObj);
            CalcGreenLine(qObj);
            CalcYellowLine(qObj);
        }

        public float[] LightPos1 = new float[4] { 2.5f, 2.5f, 2.5f, 1 };
        public float[] LightPos2 = new float[4] { -2.5f, -2.5f, 2.5f, 1 };
        public float[] LightColor1 = new float[4] { 0.1f, 0.4f, 0.1f, 1f };
        public float[] LightColor2 = new float[4] { 0.4f, 0.2f, 0.1f, 1f };

        /// <summary> 
        /// Обработчик события WM_PAINT. Здесь выполняются все основные команды рисования OpenGL.
        /// </summary>
        private void ViewGL_Paint(object sender, PaintEventArgs e)
        {
            GL.glLoadIdentity();
            double Max = 2.0;
            const double OneDistance = 0.1;
            GL.glOrtho(-Max, Max, -Max, Max, -Max, Max);

            GL.glLightfv(GL.GL_LIGHT2, GL.GL_POSITION, LightPos2);

            GL.glRotated(RotateAllOX, 0, 1, 0);
            GL.glRotated(RotateAllOY, 1, 0, 0);

            ScaleAll();
            GL.glEnable(GL.GL_DEPTH_TEST);

            DrawCoordinates(Max, OneDistance);

            GL.glEnable(GL.GL_LIGHTING);
            GL.glDisable(GL.GL_LIGHT0);
            GL.glEnable(GL.GL_LIGHT1);
            GL.glEnable(GL.GL_LIGHT2);
            Int32 qObj = GLU.gluNewQuadric();
            GL.glLightfv(GL.GL_LIGHT1, GL.GL_POSITION, LightPos1);
            GL.glLightfv(GL.GL_LIGHT1, GL.GL_AMBIENT, LightColor1);
            GL.glLightfv(GL.GL_LIGHT1, GL.GL_DIFFUSE, LightColor1);
            GL.glLightfv(GL.GL_LIGHT2, GL.GL_AMBIENT, LightColor2);
            GL.glLightfv(GL.GL_LIGHT2, GL.GL_DIFFUSE, LightColor2);
            DrawLines(qObj);
            GL.glDisable(GL.GL_DEPTH_TEST);
            GL.glDisable(GL.GL_LIGHTING);
            GL.glFinish();
            WGL.wglSwapBuffers(DC);
        }


        private void DrawCoordinates(double Max, double OneDistance)
        {
            GL.glColor3f(1.0f, 1.0f, 1.0f);
            GL.glLineWidth(1f);
            GL.glBegin(GL.GL_LINES);
                GL.glVertex3d(0.0, 0.0, 0.0);
                GL.glVertex3d(0.0, Max - OneDistance, 0.0);
                GL.glVertex3d(0.0, 0.0, 0.0);
                GL.glVertex3d(Max - OneDistance, .0, 0.0);
                GL.glVertex3d(0.0, 0.0, 0.0);
                GL.glVertex3d(0.0, 0.0, Max - OneDistance);

                GL.glVertex3d(Max - OneDistance, 0.0, 0.0);
                GL.glVertex3d(Max - OneDistance - OneDistance, -OneDistance / 2, OneDistance / 2);
                GL.glVertex3d(Max - OneDistance, 0.0, 0.0);
                GL.glVertex3d(Max - OneDistance - OneDistance, OneDistance / 2, -OneDistance / 2);

                GL.glVertex3d(0.0, Max - OneDistance, 0.0);
                GL.glVertex3d(-OneDistance / 2, Max - OneDistance - OneDistance, OneDistance / 2);
                GL.glVertex3d(0.0, Max - OneDistance, 0.0);
                GL.glVertex3d(OneDistance / 2, Max - OneDistance - OneDistance, -OneDistance / 2);

                GL.glVertex3d(0.0, 0.0, Max - OneDistance);
                GL.glVertex3d(-OneDistance / 2, OneDistance / 2, Max - OneDistance - OneDistance);
                GL.glVertex3d(0.0, 0.0, Max - OneDistance);
                GL.glVertex3d(OneDistance / 2, -OneDistance / 2, Max - OneDistance - OneDistance);
            GL.glEnd();
            OutText("X", Max - OneDistance, -OneDistance, 0);
            OutText("Y", -OneDistance, Max - OneDistance, 0);
            OutText("Z", 0, -OneDistance, Max - OneDistance);

        }

        private void ViewGL_Resize(object sender, EventArgs e)
        {
            GL.glViewport(0, 0, this.ClientSize.Width, this.ClientSize.Height);
        }

        // / <summary> 
        // / Переопределение перерисовки фона для предотвращения мерцания изображения при изменении размера окна.
        // / </summary>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
        }
    

    }
}
