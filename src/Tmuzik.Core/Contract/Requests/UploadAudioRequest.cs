using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Tmuzik.Core.Contract.Requests
{
    public class UploadAudioRequest
    {
        public string Name { get; set; }
        public string Artists { get; set; }
        public string Description { get; set; }
        public string AlbumTag { get; set; }
        public int Length { get; set; }
        public string Genre { get; set; }
        public string Privacy { get; set; }
        public IFormFile CoverFile { get; set; }
        public IFormFile AudioFile { get; set; }
    }
}