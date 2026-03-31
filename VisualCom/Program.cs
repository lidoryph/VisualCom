using System.ComponentModel;
using System.Diagnostics;

namespace VisualCom
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            try
            {
                ProcessStartInfo pythoncheck = new()
                {
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    FileName = "python",
                    Arguments = "--version"
                };
                Process.Start(pythoncheck);
            }
            catch (Win32Exception)
            {
                ApplicationConfiguration.Initialize();
                MessageBox.Show("Se necesita Python para cargar este programa.");
                return;
            }

            try
            {
                ProcessStartInfo uvcheck = new()
                {
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    FileName = "uv",
                    Arguments = "-V"
                };
                Process.Start(uvcheck);
            }
            catch (Win32Exception)
            {
                ProcessStartInfo uvinstall = new()
                {
                    UseShellExecute = true,
                    CreateNoWindow = false,
                    FileName = "pip",
                    Arguments = "install uv"
                };
                var install = Process.Start(uvinstall);
                install.WaitForExit();

                ProcessStartInfo py312 = new()
                {
                    UseShellExecute = true,
                    CreateNoWindow = false,
                    FileName = "uv",
                    Arguments = "python install 3.12"
                };
                var install312 = Process.Start(py312);
                install312.WaitForExit();
            }

            ApplicationConfiguration.Initialize();
            WelcomeWindow main = new();
            main.Show();
            Application.Run();

        }
    }
}