using System.IO;
using System.IO.Compression;
using Microsoft.AspNetCore.ResponseCompression;

namespace core2._1.test {
    public class BrotliCompressionProvider : ICompressionProvider {
        public string EncodingName => "br";
        public bool SupportsFlush => true;

        public Stream CreateStream(Stream outputStream) {
            return new BrotliStream(outputStream, CompressionLevel.Fastest);
        }
    }
}