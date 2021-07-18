using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tmuzik.Services
{
    public interface ITestService
    {
        Task WriteToStream(Stream outputStream, HttpContent content, TransportContext context);
        Task<string> TestApi();
    }
}