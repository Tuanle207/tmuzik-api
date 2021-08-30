using System;
using System.Collections.Generic;

namespace Tmuzik.Core.Contract.Responses
{
    public class UploadAudioResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Artists { get; set; }
        public string AlbumTag { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public string Genre { get; set; }
        public string Privacy { get; set; }
        public string Cover { get; set; }
        public string File { get; set; }
    }
}