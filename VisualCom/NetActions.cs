using System;
using Python.Runtime;
using System.Collections.Generic;
using System.Text;
using Windows.System.UserProfile;

namespace VisualCom
{
    internal class NetActions
    {
        public static bool pingServer(string url)
        {
            using(Py.GIL())
            {
                dynamic mod = Py.Import("netclient");
                dynamic returns = mod.ping_server(url);
                return returns;
            }
        }

        public static bool createProject((string, string, string) netArgs)
        {
            using(Py.GIL())
            {
                string url = netArgs.Item1;
                string name = netArgs.Item2;
                string type = netArgs.Item3;

                dynamic mod = Py.Import("netclient");
                dynamic returns = mod.new_project(url, name, type);
                return returns;
            }
        }

        public static dynamic GetProjects(string url)
        {
            using(Py.GIL())
            {
                dynamic mod = Py.Import("netclient");
                dynamic returns = mod.get_projects(url);
                return returns;
            }
        }

        public static dynamic GetClasses((string, string) netArgs)
        {
            using(Py.GIL())
            {
                string url = netArgs.Item1;
                string name = netArgs.Item2;

                dynamic mod = Py.Import("netclient");
                dynamic returns = mod.get_classes(url, name);
                return returns;
            }
        }

    }
}
