using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Tmuzik.Infrastructure.Services;

namespace Tmuzik.Services
{
    public interface ITestService : IService
    {
        Task WriteToStream(Stream outputStream, HttpContent content, TransportContext context);
        Task<string> TestApi();
    }
}