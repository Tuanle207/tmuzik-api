using System;

namespace Tmuzik.Infrastructure.Models
{
    public class CoreException : Exception
    {
        public int StatusCode { get; set; }
        public CoreException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public CoreException(int statusCode)
        {
            StatusCode = statusCode;
        }
    }

    public enum CoreExceptions
    {
        BadRequest,
        NotFound,
        Unauthorized,
        Forbidden,
        InternalError
    }
}