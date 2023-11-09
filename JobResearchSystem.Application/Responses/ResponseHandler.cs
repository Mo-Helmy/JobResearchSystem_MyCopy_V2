namespace JobResearchSystem.Application.Responses
{
    public class ResponseHandler
    {
        public ResponseHandler()
        {

        }

        public BaseResponse<T> Success<T>(T entity, object Meta = null)
        {
            return new BaseResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Meta = Meta
            };
        }
        
        public PaginationResponse<T> PaginateSuccess<T>(int pageIndex, int pageSize, int totalCount, IReadOnlyList<T> data)
        {
            return new PaginationResponse<T>(pageIndex, pageSize, totalCount, data);
        }

        public BaseResponse<T> Created<T>(T entity, object Meta = null)
        {
            return new BaseResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created Successfully.",
                Meta = Meta
            };
        }

        public BaseResponse<T> Deleted<T>(string Message = null)
        {
            return new BaseResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = Message == null ? "Deleted Successfully." : Message
            };
        }

        public BaseResponse<T> BadRequest<T>( string Message = null, List<string> errors = null)
        {
            return new BaseResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? "BadRequest" : Message,
                Errors = errors
            };
        }

         public BaseResponse<T> NotFound<T>(string message = null)
        {
            return new BaseResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "NotFound" : message
            };
        }

        public BaseResponse<T> Unauthorized<T>(string Message = null)
        {
            return new BaseResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = Message == null ? "UnAuthorized" : Message
            };
        }
       

        public BaseResponse<T> UnprocessableEntity<T>(string Message = null)
        {
            return new BaseResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = Message == null ? "UnprocessableEntity" : Message
            };
        }
    }
}
