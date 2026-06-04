namespace VisualCom.DataTypes
{
    public class ModelYaml
    {
        public string Path { get; set; } = string.Empty;
        public string Train { get; set; } = string.Empty;
        public string Val { get; set; } = string.Empty;
        public int Nc { get; set; } = new int();
        public Dictionary<int, string> Names { get; set; } = [];
    }
}
