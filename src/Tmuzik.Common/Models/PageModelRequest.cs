namespace Tmuzik.Common.Models
{
    public class PageModelRequest
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }

        public PageModelRequest()
        {
            PageIndex = 1;
            PageSize = 10;
        }
    }
}