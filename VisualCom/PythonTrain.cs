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
        public static void Initialize()
        {

            string ProjectDir = AppDomain.CurrentDomain.BaseDirectory;
            string TrainModPath = Path.GetFullPath( Path.Combine(ProjectDir, @".\..\..\..\TrainMod\") );

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
            string PythonExe = proc.StandardOutput.ReadToEnd().Trim();
            string? PythonDir = Path.GetDirectoryName(PythonExe);


            if (PythonDir == null)
                return;

            Runtime.PythonDLL = Path.Combine(PythonDir, "python312.dll");

            string VenvPath = Path.Combine(TrainModPath, @".venv");
            string SitePackages = Path.Combine(VenvPath, @"Lib\site-packages");

            PythonEngine.PythonHome = PythonDir;
            Environment.SetEnvironmentVariable("PYTHONPATH", SitePackages + ";" + TrainModPath);

            if (Configuration.PythonStarted == false)
            {
                PythonEngine.Initialize();

                PythonEngine.BeginAllowThreads();
            }


            using (Py.GIL())
            {
                dynamic sys = Py.Import("sys");
                sys.path.insert(0, TrainModPath);
                sys.path.insert(0, SitePackages);

                Console.WriteLine("sys.path: " + sys.path.ToString());
            }


        }

        public static double StartTrain((string, int, int, int, string) PythonArguments)
        {
            using (Py.GIL())
            {
                string? Version = PythonArguments.Item1;
                int Epoch = PythonArguments.Item2;
                int Rate = PythonArguments.Item3;
                int Images = PythonArguments.Item4;
                string Device = PythonArguments.Item5;


                dynamic mod = Py.Import("miscriptpqnofunciona");
                dynamic returns = mod.calcular(Version, Epoch, Rate, Images, Device);

                double status = returns["status"].As<double>();

                return status;
            }
        }

    }
}
