using System.Collections.Generic;

namespace AzureVisionApiSimpleOcrSdk.Model
{
    public class Line
    {
        private string _boundingBox;
        public string BoundingBox
        {
            get { return _boundingBox; }
            set
            {
                _boundingBox = value;
                Rectangle = Rectangle.FromString(_boundingBox);
            }
        }

        public Rectangle Rectangle { get; protected set; }
        public List<Word> Words { get; set; }
    }
}