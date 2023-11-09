using Microsoft.AspNetCore.Http;
using System.Net;

namespace JobResearchSystem.Application.Responses
{
    public class PaginationResponse<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IReadOnlyList<T> Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool Succeeded { get; set; }

        public PaginationResponse(int pageIndex, int pageSize, int totalCount, IReadOnlyList<T> data)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
            this.Data = data;
            this.StatusCode = HttpStatusCode.OK;
            this.Succeeded = true;
        }
    }
}
