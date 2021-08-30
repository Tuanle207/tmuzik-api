using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Tmuzik.Core.Interfaces
{
    public interface IStorageHandler
    {
        Task<string> SaveFileAsync(IFormFile fileName);
        Task RemoveFileAsync(string file);
    }
}