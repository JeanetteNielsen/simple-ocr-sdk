using OcrMetadata.Exceptions;
using System;

namespace AzureVisionApiSimpleOcrSdk.Exceptions
{
    public class AzureOcrException : OcrException
    {
        public Exception ClientException { get; set; }

        public AzureOcrException(Exception e) : base("AzureOcrException occured")
        {
            ClientException = e;
        }

        public override string ToString()
        {
            return $"AzureOcrException. Azure could not process image. Error: " + base.ToString();
        }

        public override string StackTrace => ClientException.StackTrace;
    }
}