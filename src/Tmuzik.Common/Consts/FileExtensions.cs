using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Tmuzik.Common.Consts
{
    public class FileExtensions
    {
        public static readonly IEnumerable<string> Image = new string[]
        {
             ".png",
            ".jpg",
            ".jpeg",
            ".gif",
            ".webp",
            ".tiff",
            ".bmp"
        };

        public static readonly IEnumerable<string> Audio = new string[]
        {
            ".mp3",
            ".m4a",
            ".flac",
            ".mp4",
            ".wav",
            ".wma",
            ".aac",
        };
    }
}