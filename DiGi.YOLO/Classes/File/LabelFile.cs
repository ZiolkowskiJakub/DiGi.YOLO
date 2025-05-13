using System;
using System.Collections.Generic;

namespace DiGi.YOLO.Classes
{
    public class LabelFile
    {
        public List<Tuple<int, BoundingBox>> tuples = new List<Tuple<int, BoundingBox>>();

        public LabelFile()
        {

        }

        public bool Add(int tagIndex, BoundingBox boundingBox)
        {
            if(boundingBox == null || tagIndex < 0)
            {
                return false;
            }

            tuples.Add(new Tuple<int, BoundingBox>(tagIndex, boundingBox));
            return true;
        }

        public HashSet<int> GetTagIndexes()
        {
            HashSet<int> result = new HashSet<int>();
            foreach (Tuple<int, BoundingBox> tuple in tuples)
            {
                if(tuple == null)
                {
                    continue;
                }

                result.Add(tuple.Item1);
            }

            return result;
        }

        public List<BoundingBox> GetBoundingBoxes(int tagIndex)
        {
            List<BoundingBox> result = new List<BoundingBox>();
            foreach(Tuple<int, BoundingBox> tuple in tuples)
            {
                if(tuple == null)
                {
                    continue;
                }

                if(tuple.Item1 != tagIndex)
                {
                    continue;
                }

                result.Add(tuple.Item2);
            }

            return result;
        }

        public int Count
        {
            get
            {
                return tuples == null ? 0 : tuples.Count;
            }
        }

        public int GetTagIndex(int index)
        {
            return tuples[index].Item1;
        }

        public BoundingBox GetBoundingBox(int index)
        {
            return tuples[index].Item2;
        }

        public override string ToString()
        {
            List<string> values = new List<string>();

            if(tuples != null)
            {
                foreach (Tuple<int, BoundingBox> tuple in tuples)
                {
                    string value = tuple?.Item2?.ToString();
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        continue;
                    }

                    values.Add(string.Format("{0} {1}", tuple.Item1, value));
                }
            }

            return string.Join(Environment.NewLine, values);
        }
    }
}
