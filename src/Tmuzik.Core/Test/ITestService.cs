using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Tmuzik.Core.Interfaces;

namespace Tmuzik.Services
{
    public interface ITestService : IAppService
    {
        Task WriteToStream(Stream outputStream, HttpContent content, TransportContext context);
        Task<string> TestApi();
    }
}