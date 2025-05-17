using System;
using System.Collections.Generic;

namespace DiGi.YOLO.Classes
{
    public class BoundingBoxResultFile : List<BoundingBoxResult>
    {
        public List<BoundingBoxResult> boundingBoxResults = new List<BoundingBoxResult>();

        public BoundingBoxResultFile()
        {

        }

        public override string ToString()
        {
            List<string> values = new List<string>();

            if(boundingBoxResults != null)
            {
                foreach (BoundingBoxResult boundingBoxResult in boundingBoxResults)
                {
                    string value = boundingBoxResult?.ToString();
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        continue;
                    }

                    values.Add(value);
                }
            }

            return string.Join(Environment.NewLine, values);
        }
    }
}
