namespace AzureVisionApiSimpleOcrSdk.Model
{
    public class Word
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
        public string Text { get; set; }
    }
}