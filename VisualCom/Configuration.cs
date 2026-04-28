using System.Xml.Linq;
using Windows.Media.Streaming.Adaptive;
using VisComClient;


namespace VisualCom
{

    public class BoundingBox
    {
        public string Class { get; set; } = string.Empty;
        public float[] BL { get; set; } = new float[2];
        public float[] TR { get; set; } = new float[2];
    }

    public class ImageAnnotation
    {
        public string Name { get; set; } = String.Empty;
        public List<BoundingBox> Boxes { get; set; } = new();
    }

    public static class Configuration
    {

        public static string UserName = "";
        public static string ProjectFile = "project.xml";
        public static Boolean Saved = true;
        public static Boolean PythonStarted = false;
        public static Boolean Online = false;
        public static string ServerAddress = "";
        public static ServerConnection Connection = new(null, null);


        public static XDocument ProjectVariables = new(
            new XElement("Project",
                new XComment("NEVER CHANGE DATA HERE, ALWAYS CHANGE IT FROM THE PROGRAM"),
                new XElement("Name", ""),
                new XElement("Type", ""),
                new XElement("Version", "0.0.1"),
                new XElement("Created", ""),
                new XElement("Modified", ""),
                new XElement("Directories",
                    new XElement("Main", ""),
                    new XElement("Images", ""),
                    new XElement("Annotations", ""),
                    new XElement("Models", ""),
                    new XElement("Versions", "")
                ),
                new XElement("Classes",
                    new XElement("Objetos", "#55FF22")
                ),
                new XComment("NEVER CHANGE DATA HERE, ALWAYS CHANGE IT FROM THE PROGRAM")
            )
        );

        public static List<Tuple<PointF, PointF>> CurrentImageCoordinates = [];
        public static string CurrentImageString = "";
        public static string CurrentImageFile = "";
        public static string JsonPath = "";
        public static ImageAnnotation CurrentImageJson = new()
        {
            Name = "imageName",
            Boxes = CurrentImageCoordinates.Select(b => new BoundingBox
            {
                BL = new float[] { b.Item1.X, b.Item1.Y },
                TR = new float[] { b.Item2.X, b.Item2.Y },
            }).ToList()
        };
    }
}
