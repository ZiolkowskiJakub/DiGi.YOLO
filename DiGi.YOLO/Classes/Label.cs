namespace DiGi.YOLO.Classes
{
    public class Label
    {
        public int index;
        public string name;

        public Label(int index, string name)
        {
            this.index = index;
            this.name = name;
        }

        public int Index
        {
            get
            {
                return index;
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
            return string.Format("{0}: {1}", index, name == null ? string.Empty : name);
        }
    }
}
