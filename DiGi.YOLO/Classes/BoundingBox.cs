using DiGi.YOLO.Interfaces;

namespace DiGi.YOLO.Classes
{
    public class BoundingBox : IBoundingBox
    {
        private double height;
        private double width;
        private double x;
        private double y;
        
        public BoundingBox(double x, double y, double width, double height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public double Height
        {
            get
            {
                return height;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }
        }

        public double X
        {
            get 
            { 
                return x; 
            }
        }

        public double Y
        {
            get
            {
                return y;
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
            return string.Format("{0} {1} {2} {3}", x, y, width, height);
        }
    }
}
