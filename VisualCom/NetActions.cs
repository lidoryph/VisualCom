using Python.Runtime;

namespace VisualCom
{
    internal class NetActions
    {
        public static dynamic pingServer()
        {
            using (Py.GIL())
            {
                dynamic mod = Py.Import("netclient");
                dynamic returns = mod.ping_server(Configuration.ServerAddress);
                return returns;
            }
        }

        public static dynamic CreateProject((string, string, string, string) netArgs)
        {
            using (Py.GIL())
            {
                string url = netArgs.Item1;
                string name = netArgs.Item2;
                string type = netArgs.Item3;
                string user = netArgs.Item4;

                dynamic mod = Py.Import("netclient");
                dynamic returns = mod.new_project(url, name, type, user);
                return returns;
            }
        }

        public static dynamic GetProjects()
        {
            using (Py.GIL())
            {
                dynamic mod = Py.Import("netclient");
                dynamic returns = mod.get_projects(Configuration.ServerAddress, Configuration.UserName);
                return returns;
            }
        }

        public static dynamic DeleteProject((string, string, string) netargs)
        {

            string url = netargs.Item1;
            string project = netargs.Item2;
            string user = netargs.Item3;

            using(Py.GIL())
            {
                dynamic net = Py.Import("netclient");
                dynamic returns = net.delete_project(url, project, user);
                return returns;
            }
        }

        public static dynamic GetClasses((string, string) netArgs)
        {
            using (Py.GIL())
            {
                string url = netArgs.Item1;
                string project = netArgs.Item2;

                dynamic mod = Py.Import("netclient");
                dynamic returns = mod.get_classes(url, project);
                return returns;
            }
        }

        public static dynamic GetVersions((string, string) netArgs)
        {
            using (Py.GIL())
            {
                string url = netArgs.Item1;
                string project = netArgs.Item2;

                dynamic mod = Py.Import("netclient");
                dynamic returns = mod.get_versions(url, project);

                return returns;
            }
        }

        public static dynamic GetImages((string, string) netArgs)
        {
            using (Py.GIL())
            {
                string url = netArgs.Item1;
                string project = netArgs.Item2;

                dynamic mod = Py.Import("netclient");
                dynamic returns = mod.get_images(url, project);

                return returns;
            }
        }

    }
}
