using AzureVisionApiSimpleOcrSdk.Model;
using OcrMetadata.Model;
using OcrMetadata.Tools;

namespace AzureVisionApiSimpleOcrSdk.Integration.Parser
{
    public interface IAzureCreateRelativeCoordinate
    {
        Coordinate Execute(Rectangle rectangle, int imgWidth, int imgHeight);
    }

    public class AzureCreateRelativeCoordinate : IAzureCreateRelativeCoordinate
    {
        private readonly ICreateRelativeCoordinate _createRelativeCoordinate;

        public AzureCreateRelativeCoordinate(ICreateRelativeCoordinate createRelativeCoordinate)
        {
            _createRelativeCoordinate = createRelativeCoordinate;
        }

        public Coordinate Execute(Rectangle rectangle, int imgWidth, int imgHeight)
        {
            double x = rectangle.Left;
            double y = rectangle.Top;
            double height = rectangle.Height;
            double width = rectangle.Width;

            return _createRelativeCoordinate.Execute(x, y, height, width, imgHeight, imgWidth);
        }
    }
}