namespace DiGi.YOLO.Classes
{
    public class BoundingBoxResult : BoundingBox
    {
        private double confidence;
        private int labelIndex;
        private string name;
        
        public BoundingBoxResult(string name, int labelIndex, double x, double y, double width, double height, double confidence)
            : base(x, y, width, height)
        {
            this.name = name;
            this.labelIndex = labelIndex;
            this.confidence = confidence;
        }

        public double Confidence
        {
            get
            {
                return confidence;
            }
        }

        public int LabelIndex
        {
            get
            {
                return labelIndex;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
        
        public override bool Equals(object @object)
        {
            return @object != null && @object.GetType() == GetType() && ToString() == @object.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", name, labelIndex, X, Y, Width, Height, confidence);
        }
    }
}
