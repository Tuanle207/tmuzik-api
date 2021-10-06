using Tmuzik.Common.Models;

namespace Tmuzik.Core.Contract.Requests
{
    public class GetSearchResultsRequest : PageModelRequest
    {
        public string Query { get; set; }
        public string Category { get; set; }
    }

    public static class SearchCategory
    {
        public const string User = "user";
        public const string Artist = "artist";
        public const string Audio = "audio";
        public const string Album = "album";
        public const string Playlist = "playlist";
        public const string Genre = "genre";
    }
}