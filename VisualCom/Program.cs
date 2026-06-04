using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using VisualCom.Forms.Online.Extra;
using VisualCom.Forms.Editor;

namespace VisualCom
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 


        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            if (!Directory.Exists(Configuration.ProgramPath))
                Directory.CreateDirectory(Configuration.ProgramPath);

            foreach (string argument in args)
            {
                if(File.Exists(argument) && Path.GetExtension(argument) == ".asaivc")
                {
                    Configuration.ProjectFile = argument;

                    string[] filecontent = File.ReadAllLines(argument);
                    if (filecontent[1].Contains("Online")) {
                        Configuration.OnlineVariables = XDocument.Load(Configuration.ProjectFile);
                        QuickLogin login = new();
                        login.Show();
                        Application.Run();
                        return;
                    }

                    Configuration.ProjectDir = Path.GetDirectoryName(Configuration.ProjectFile) ?? "";
                    string ProjectDir = Configuration.ProjectDir;
                    Configuration.ProjectImages = Path.Join(ProjectDir, "images");
                    Configuration.ProjectAnnotations = Path.Join(ProjectDir, "annotations");
                    Configuration.ProjectModels = Path.Join(ProjectDir, "models");
                    Configuration.ProjectVersions = Path.Join(ProjectDir, "versions");

                    

                    ApplicationConfiguration.Initialize();
                    MainEditor editor = new();
                    editor.Show();
                    Application.Run();
                    return;
                }
            }

            ApplicationConfiguration.Initialize();
            WelcomeWindow main = new();
            main.Show();
            Application.Run();
        }
    }
}
