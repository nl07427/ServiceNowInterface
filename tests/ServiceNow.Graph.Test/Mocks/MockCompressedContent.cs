using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace ServiceNow.Graph.Test.Mocks
{
    public class MockCompressedContent : HttpContent
    {
        private readonly HttpContent originalContent;

        public MockCompressedContent(HttpContent httpContent)
        {
            originalContent = httpContent;

            foreach (KeyValuePair<string, IEnumerable<string>> header in originalContent.Headers)
                Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            Stream compressedStream = new GZipStream(stream, CompressionMode.Compress, true);

            return originalContent.CopyToAsync(compressedStream).ContinueWith(t =>
            {
                if (compressedStream != null)
                {
                    compressedStream.Dispose();
                }
            });
        }

        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
}
