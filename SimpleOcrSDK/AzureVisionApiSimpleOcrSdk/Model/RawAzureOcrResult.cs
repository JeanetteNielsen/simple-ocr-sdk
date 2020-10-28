using System.Linq;

namespace AzureVisionApiSimpleOcrSdk.Model
{
    public class RawAzureOcrResult 
    {
        public string Language { get; set; }
        public string Orientation { get; set; }
        public Region[] Regions { get; set; }
        public double? TextAngle { get; set; }

        public string GetAsPlainText()
        {
            return Regions?.SelectMany(x => x.Lines).SelectMany(x => x.Words).Aggregate("", (i, j) => i + " " + j.Text).Trim() ?? "";
        }

        public bool TextFound()
        {
            return Regions != null && Regions.Any();
        }
    }
}