using System.Collections.Generic;

namespace DiGi.YOLO.Classes
{
    public class Image
    {
        private Dictionary<int, HashSet<BoundingBox>> boundingBoxes = new Dictionary<int, HashSet<BoundingBox>>();
        private string path;
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

        public IEnumerable<int> TagIndexes
        {
            get
            {
                return boundingBoxes.Keys;
            }
        }

        public IEnumerable<BoundingBox> this[int tagIndex]
        {
            get
            {
                if(!boundingBoxes.TryGetValue(tagIndex, out HashSet<BoundingBox> result))
                {
                    return null;
                }

                return result;
            }
        }

        public bool Add(int tagIndex, BoundingBox boundingBox)
        {
            if(boundingBox == null)
            {
                return false;
            }

            if(!boundingBoxes.TryGetValue(tagIndex, out HashSet<BoundingBox> boundingBoxes_Temp) || boundingBoxes_Temp == null)
            {
                boundingBoxes_Temp = new HashSet<BoundingBox>();
                boundingBoxes[tagIndex] = boundingBoxes_Temp;
            }

            return boundingBoxes_Temp.Add(boundingBox);
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
