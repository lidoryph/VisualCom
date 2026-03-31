using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using VisualCom.Forms.Editor;

namespace VisualCom
{
    public static class PythonTrain
    {
        private static bool _initialized = false;

        public static void Initialize()
        {
            if (_initialized == true) return;

            string ProjectDir = AppDomain.CurrentDomain.BaseDirectory;
            string TrainModPath = Path.GetFullPath(Path.Combine(ProjectDir, @".\..\..\..\TrainMod\"));

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
            string PYTHONPATH = SitePackages + ";" + TrainModPath;
            Environment.SetEnvironmentVariable("PYTHONPATH", PYTHONPATH);

            if (Configuration.PythonStarted == false)
            {
                PythonEngine.Initialize();

                PythonEngine.BeginAllowThreads();
                Configuration.PythonStarted = true;
            }


            using (Py.GIL())
            {
                dynamic sys = Py.Import("sys");
                sys.path.insert(0, TrainModPath);
                sys.path.insert(0, SitePackages);
            }

            _initialized = true;
        }

        public static int GetListModel(string ModelName)
        {
            using (Py.GIL())
            {
                dynamic mod = Py.Import("pullmodel");
                dynamic returns = mod.download_model(ModelName);
                return returns;
            }
        }

        public static int PullModel(string ModelName)
        {
            using (Py.GIL())
            {
                dynamic mod = Py.Import("pullmodel");
                dynamic returns = mod.pull_model(ModelName);
                return returns;
            }
        }

        public static double StartTrain((string, int, int, int, string, string, string) PythonArguments, CancellationTokenSource cts, CancellationToken cToken, Action<int, int>? onEpochEnd = null)
        {
            using (Py.GIL())
            {
                string? Version = PythonArguments.Item1;
                int Epoch = PythonArguments.Item2;
                int ImgSz = PythonArguments.Item3;
                int Seed = PythonArguments.Item4;
                string Device = PythonArguments.Item5;
                string Model = PythonArguments.Item6;
                string OutPath = PythonArguments.Item7;


                dynamic mod = Py.Import("trainmodel");
                PyObject? cb = onEpochEnd?.ToPython();
                dynamic? result = null;

                try
                {
                    result = cb is not null
                        ? mod.train(Version, Epoch, ImgSz, Device, Model, Seed, OutPath, cb)
                        : mod.train(Version, Epoch, ImgSz, Device, Model, Seed, OutPath);
                } catch (Python.Runtime.PythonException error)
                {
                    if (error.ToString().Contains("Invalid CUDA"))
                    {
                        MessageBox.Show("Invalid CUDA");
                    }
                    cts.Cancel();
                } catch(OperationCanceledException)
                {
                    PythonEngine.Shutdown();
                }


                if (result == null)
                    return 0;

                var pyResult = new PyDict((PyObject)result);

                if (!pyResult.HasKey("status"))
                    return 0.0;

                return pyResult["status"].As<double>();
            }
        }

    }
}
