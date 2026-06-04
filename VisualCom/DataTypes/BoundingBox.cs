namespace VisualCom.DataTypes
{
    public class BoundingBox
    {
        public string Class { get; set; } = string.Empty;
        public float[] BL { get; set; } = new float[2];
        public float[] TR { get; set; } = new float[2];
    }
}
