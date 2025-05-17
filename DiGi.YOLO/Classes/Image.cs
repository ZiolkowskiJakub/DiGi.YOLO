using DiGi.YOLO.Interfaces;
using System.Collections.Generic;

namespace DiGi.YOLO.Classes
{
    public class Image<TBoundingBox> where TBoundingBox : IBoundingBox
    {
        protected Dictionary<int, HashSet<TBoundingBox>> boundingBoxes = new Dictionary<int, HashSet<TBoundingBox>>();
        protected string path;

        public Image(string path)
        {
            this.path = path;
        }

        public string Path
        {
            get
            {
                return path;
            }
        }

        public IEnumerable<int> LabelIndexes
        {
            get
            {
                return boundingBoxes.Keys;
            }
        }

        public IEnumerable<TBoundingBox> this[int labelIndex]
        {
            get
            {
                if (!boundingBoxes.TryGetValue(labelIndex, out HashSet<TBoundingBox> result))
                {
                    return null;
                }

                return result;
            }
        }

        public bool Add(int labelIndex, TBoundingBox boundingBox)
        {
            if (boundingBox == null)
            {
                return false;
            }

            if (!boundingBoxes.TryGetValue(labelIndex, out HashSet<TBoundingBox> boundingBoxes_Temp) || boundingBoxes_Temp == null)
            {
                boundingBoxes_Temp = new HashSet<TBoundingBox>();
                boundingBoxes[labelIndex] = boundingBoxes_Temp;
            }

            return boundingBoxes_Temp.Add(boundingBox);
        }
    }

    public class Image : Image<BoundingBox>
    {
        public Image(string path)
            : base(path)
        {

        }

        public string Path
        {
            get
            {
                return path;
            }
        }
        
        public LabelFile GetLabelFile()
        {
            LabelFile result = new LabelFile();

            foreach(KeyValuePair<int, HashSet<BoundingBox>> keyValuePair in boundingBoxes)
            {
                if(keyValuePair.Value == null)
                {
                    continue;
                }

                foreach (BoundingBox boundingBox in keyValuePair.Value)
                {
                    result.Add(keyValuePair.Key, boundingBox);
                }
            }

            return result;
        }
    }
}
