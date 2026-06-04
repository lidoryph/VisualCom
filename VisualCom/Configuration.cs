using System.Xml.Linq;
using VisComClient.Connection;
using VisualCom.DataTypes;


namespace VisualCom
{
    public static class Configuration
    {
        public static string UserName = "";


        public static Boolean Saved = true;
        public static Boolean PythonStarted = false;
        public static Boolean Online = false;
        public static string ServerAddress = "";
        public static ServerConnection? Connection;
        private readonly static string RoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string ProgramPath = Path.Join(RoamingPath, "VisualCom");
        public static string OnlinePath = "";


        public static XDocument ProjectVariables = new(
            new XElement("Project",
                new XComment("NEVER CHANGE DATA HERE, ALWAYS CHANGE IT FROM THE PROGRAM"),
                new XElement("Name", ""),
                new XElement("Type", ""),
                new XElement("Version", "0.0.1"),
                new XElement("Created", ""),
                new XElement("Modified", ""),
                new XElement("Classes",
                    new XElement("Objetos", "#55FF22")
                ),
                new XComment("NEVER CHANGE DATA HERE, ALWAYS CHANGE IT FROM THE PROGRAM")
            )
        );

        public static XDocument OnlineVariables = new(
            new XElement("Online",
                new XComment("NEVER CHANGE DATA HERE, ALWAYS CHANGE IT FROM THE PROGRAM"),
                new XElement("Address", ""),
                new XElement("Port", ""),
                new XElement("Created", ""),
                new XElement("Classes",
                    new XElement("Objetos", "#55FF22")
                ),
                new XComment("NEVER CHANGE DATA HERE, ALWAYS CHANGE IT FROM THE PROGRAM")
            )
        );

        public static string ProjectName = "";
        public static string ProjectType = "";
        public static string ProjectVersion = "";
        public static string ProjectCreated = "";
        public static string ProjectModified = "";
        public static string ProjectFile = "project.asaivc";
        public static string ProjectDir = Path.GetDirectoryName(Configuration.ProjectFile) ?? "";
        public static string ProjectImages = Path.Join(ProjectDir, "images");
        public static string ProjectAnnotations = Path.Join(ProjectDir, "annotations");
        public static string ProjectModels = Path.Join(ProjectDir, "models");
        public static string ProjectVersions = Path.Join(ProjectDir, "versions");

        public static List<Tuple<PointF, PointF>> CurrentImageCoordinates = [];
        public static string CurrentImageString = "";
        public static string CurrentImageFile = "";
        public static string JsonPath = "";
        public static ImageAnnotation CurrentImageJson = new()
        {
            Name = "imageName",
            Boxes = [.. CurrentImageCoordinates.Select(b => new BoundingBox
            {
                BL = [b.Item1.X, b.Item1.Y],
                TR = [b.Item2.X, b.Item2.Y],
            })]
        };
    }
}