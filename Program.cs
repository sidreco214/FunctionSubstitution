using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace FunctionSubsitution
{
    internal static partial class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //profiles 폴더 있는지 확인후 없으면 만들기
            if (!Directory.Exists("profiles"))
            {
                Directory.CreateDirectory("profiles");
            }

            string cwd = Assembly.GetExecutingAssembly().Location;
            int err = Core.init_python(cwd, "python");

            if (err != 0)
            {
                MessageBox.Show(
                    "Error: can not initialize python",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            //caches 폴더 있는지 확인후 없으면 만들기
            if (!Directory.Exists("caches"))
            {
                Directory.CreateDirectory("caches");
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            Core.deinit_python();

            Directory.Delete("caches", recursive:true);
        }
    }
}