using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AzureVisionApiSimpleOcrSdk.Integration
{
    public interface IStreamToByteContent
    {
        ByteArrayContent Execute(Stream input);
    }

    public class StreamToByteContent : IStreamToByteContent
    {
        public ByteArrayContent Execute(Stream input)
        {
            using (var ms = new MemoryStream())
            {
                input.CopyTo(ms);
                var content = new ByteArrayContent(ms.ToArray());
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return content;
            }
        }
    }
}