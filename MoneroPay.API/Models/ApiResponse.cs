using System.Collections.Generic;

namespace MoneroPay.API.Models
{
    public class ApiErrorResponse
    {
        public IEnumerable<ApiError>? Errors { get; set; }
    }

    public class ApiError
    {
        public ApiError(string message, string type, int code)
        {
            this.Message = message;
            this.Type = type;
            this.Code = code;
        }

        public string Message { get; set; }
        public string Type { get; set; }
        public int Code { get; set; }
    }
}