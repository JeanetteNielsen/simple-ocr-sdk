using System.Collections.Generic;

namespace AzureVisionApiSimpleOcrSdk.Model
{
    public class Region
    {
        public string BoundingBox { get; set; }
        public List<Line> Lines { get; set; }
    }
}