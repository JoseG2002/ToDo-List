using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ToDoListAPI
{
    public class HttpErrors
    {
        public static NotFoundObjectResult NotFound(string? message = null, object? data = null )
        {
            return new NotFoundObjectResult(APIResponseErrors(HttpStatusCode.NotFound, message, data));     
        }

        public static APIResponse APIResponseErrors(HttpStatusCode statusCode, string? message, object? data)
        {
            APIResponse response = new()
            {
                StatusCode = statusCode,
                Success = false,
                Data = data
            };

            if (!string.IsNullOrWhiteSpace(message))
            {
                response.Messages.Add(message);
            }

            return response;
        }
    }
}
