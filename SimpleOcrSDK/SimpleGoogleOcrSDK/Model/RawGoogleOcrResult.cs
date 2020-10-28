using System.Collections.Generic;
using System.Linq;
using Google.Cloud.Vision.V1;

namespace SimpleGoogleOcrSDK.Model
{
    public class RawGoogleOcrResult
    {
        public IList<EntityAnnotation> EntityAnnotations { get; set; }

        public static RawGoogleOcrResult CreateFrom(IList<EntityAnnotation> ocrResults)
        {
            return new RawGoogleOcrResult()
            {
                EntityAnnotations = ocrResults,
            };
        }

        public string GetAsPlainText()
        {
            return EntityAnnotations?.Skip(1).SelectMany(x => x.Description).Aggregate("", (i, j) => i + " " + j).Trim() ?? "";
        }

        public bool TextFound()
        {
            return EntityAnnotations != null && EntityAnnotations.Any();
        }
    }
}
