using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeTypes.Core;
using Tmuzik.Common.Consts;
using Tmuzik.Common.DependencyInjections;
using Tmuzik.Core.Interfaces;

namespace Tmuzik.Infrastructure.Storage
{
    public class PhysicalStorageHandler : IStorageHandler, ISingletonDependency<IStorageHandler>
    {
        private readonly string _contentRootPath;
        private readonly string _appUrl;

        public PhysicalStorageHandler(IWebHostEnvironment env, IConfiguration configuration)
        {
            _contentRootPath = Path.Join(env.ContentRootPath, "Storage");
            _appUrl = configuration["Url:SelfUrl"];
        }

        public Task RemoveFileAsync(string fileName)
        {
            var filePath = Path.Join(_contentRootPath, fileName);
            if (File.Exists(filePath))
            {
                return Task.Run(() => File.Delete(filePath));
            }
            return Task.CompletedTask;
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
           
            var uniqueName = Guid.NewGuid().ToString();
            uniqueName += MimeTypeMap.GetExtension(file.ContentType);

            var storePath = Path.Join(_contentRootPath, uniqueName);

            using (var stream = File.Create(storePath))
            {
                await file.CopyToAsync(stream);
            }

            return $"{_appUrl}/storage/{uniqueName}";
        }
    }
}