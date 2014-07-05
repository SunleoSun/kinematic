using System;

using System.Windows.Forms;

namespace glWinForm
{
    static class Program
    {
        static Form _this = null;
        public static Form App
        {
            get
            {
                if (_this == null)
                    _this = new MainForm();
                return _this;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(App);
        }
    }
}
