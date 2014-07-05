namespace glWinForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.view = new OpenGL.ViewGL();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(650, 90);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // view
            // 
            this.view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.view.LargeFi = 0;
            this.view.Location = new System.Drawing.Point(12, 108);
            this.view.Name = "view";
            this.view.RotateAllOX = 0;
            this.view.RotateAllLinesOY = 0;
            this.view.RotateAllLinesOZ = 0;
            this.view.RotateRedLineAngle = 0;
            this.view.ScaleFactor = 0;
            this.view.Size = new System.Drawing.Size(675, 591);
            this.view.SmallFi = 0;
            this.view.TabIndex = 0;
            this.view.Teta = 0;
            this.view.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Key_Pressed1);
            this.view.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mouse_Move);
            this.view.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mouse_Down);
            this.view.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Mouse_Up);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(699, 711);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.view);
            this.Name = "MainForm";
            this.Text = "OpenGL Form";
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseWheel);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenGL.ViewGL view;
        private System.Windows.Forms.Label label1;
    }
}

