namespace VisualCom.DataTypes
{
    public class ImageAnnotation
    {
        public string Name { get; set; } = String.Empty;
        public List<BoundingBox> Boxes { get; set; } = [];
    }
}
