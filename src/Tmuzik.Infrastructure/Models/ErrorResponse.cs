using System.Collections.Generic;

namespace Tmuzik.Infrastructure.Models
{
    public class ErrorResponse
    {
        public int Status { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }
        public string RequestId { get; set; }
    }
}