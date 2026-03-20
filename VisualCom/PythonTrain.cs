using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Python.Runtime;
using VisualCom.Forms.Editor;

namespace VisualCom
{
    public static class PythonTrain
    {

        public static int status = 0;
        public static void Initialize()
        {

            string projectDIR = AppDomain.CurrentDomain.BaseDirectory;
            string TrainModPATH = Path.GetFullPath( Path.Combine(projectDIR, @".\..\..\..\TrainMod\") );

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "uv",
                    Arguments = "run python -c \"import sys; print(sys.executable)\"",
                    //WorkingDirectory = TrainModPATH,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            

            proc.Start();
            string pythonEXE = proc.StandardOutput.ReadToEnd().Trim();
            string pythonDIR = Path.GetDirectoryName(pythonEXE);

            Runtime.PythonDLL = Path.Combine(pythonDIR, "python312.dll");

            string venvPath = Path.Combine(TrainModPATH, @".venv");
            string sitePackages = Path.Combine(venvPath, @"Lib\site-packages");

            PythonEngine.PythonHome = pythonDIR;
            Environment.SetEnvironmentVariable("PYTHONPATH", sitePackages + ";" + TrainModPATH);

            if (Configuration.PythonStarted == false)
            {
                PythonEngine.Initialize();

                PythonEngine.BeginAllowThreads();
            }


            using (Py.GIL())
            {
                dynamic sys = Py.Import("sys");
                sys.path.insert(0, TrainModPATH);
                sys.path.insert(0, sitePackages);

                Console.WriteLine("sys.path: " + sys.path.ToString());
            }


        }

        public static double startTrain(string version, int epoch, int rate, int images, string device)
        {
            using (Py.GIL())
            {
                dynamic mod = Py.Import("miscriptpqnofunciona");

                dynamic returns = mod.calcular(version, epoch, rate, images, device);


                double status = returns["status"].As<double>();

                return status;
            }
        }

    }
}
