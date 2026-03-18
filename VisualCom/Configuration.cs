using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace VisualCom
{
    public static class Configuration
    {
        public static string ProjectFile = "project.xml";


        public static XDocument ProjectVariables = new XDocument(
            new XElement("Project",
                new XComment("NEVER CHANGE DATA HERE, ALWAYS CHANGE IT FROM THE PROGRAM"),
                new XElement("Name", ""),
                new XElement("Type", ""),
                new XElement("Version", 1.0),
                new XElement("Created", ""),
                new XElement("Modified", ""),
                new XElement("Directories",
                    new XElement("Main", ""),
                    new XElement("Images", ""),
                    new XElement("Annotations", ""),
                    new XElement("Models", ""),
                    new XElement("Versions", "")
                ),
                new XComment("NEVER CHANGE DATA HERE, ALWAYS CHANGE IT FROM THE PROGRAM")
            )
        );
    }
}
