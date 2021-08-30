using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.StaticFiles;
using MimeTypes.Core;
using Tmuzik.Common.Consts;

namespace Tmuzik.Api.Configurations
{
    public class FileExtensionContentTypeProviderBuilder
    {
        private static readonly Dictionary<string, string> mappings = new List<string>(
                Enumerable.Concat(
                    FileExtensions.Image, 
                    FileExtensions.Audio
                )
            ).ToDictionary(x => x, x => MimeTypeMap.GetMimeType(x));

        public static FileExtensionContentTypeProvider Build()
        {
            var provider = new FileExtensionContentTypeProvider();
            
            foreach (var ext in mappings)
            {
                provider.Mappings[ext.Key] = ext.Value;
            }

            return provider;
        }
    }
}