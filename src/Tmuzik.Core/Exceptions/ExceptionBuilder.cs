using Microsoft.AspNetCore.Http;

namespace Tmuzik.Core.Exceptions
{
    
    public class ExceptionBuilder
    {
        public static CoreException Build(CoreExceptions type = CoreExceptions.InternalError, string message = null)
        {
            switch (type)
            {
                case CoreExceptions.BadRequest:
                    return BadRequest(message);
                case CoreExceptions.NotFound:
                    return NotFound(message);
                case CoreExceptions.Unauthorized:
                    return Unauthorized();
                case CoreExceptions.Forbidden:
                    return Forbidden();
                case CoreExceptions.InternalError:
                    return InternalError();
                default:
                    return InternalError();            
            }
        }
        
        private static CoreException BadRequest(string message = "Invalid request.")
        {
            return new CoreException(StatusCodes.Status400BadRequest, message);
        }

        private static CoreException NotFound(string message = "This resource is not found.")
        {
            return new CoreException(StatusCodes.Status404NotFound, message);
        }

        private static CoreException Unauthorized()
        {
            return new CoreException(StatusCodes.Status401Unauthorized, "You are not authorized.");
        }

        private static CoreException Forbidden()
        {
            return new CoreException(StatusCodes.Status403Forbidden, "You have no right to access to this resource.");
        }

        private static CoreException InternalError()
        {
            return new CoreException(StatusCodes.Status500InternalServerError, "Internal server error.");
        }

    }
}