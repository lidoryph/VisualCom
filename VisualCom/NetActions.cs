using System;
using Python.Runtime;
using System.Collections.Generic;
using System.Text;

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
            string url = netArgs.Item1;
            string name = netArgs.Item2;
            string type = netArgs.Item3;

            dynamic mode = Py.Import("netclient");
            dynamic returns = mode.new_project(url, name, type);
            return returns;
        }
    }
}
