using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message  ?? GetDefaultMessageForStatusCode(StatusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "you made a Bad request ",
                401 => "you are not Athorized ",
                404 => "request not found",
                500 => "Internal Server error",
                _ => null
            };
        }

        public int StatusCode{get;set;}
        public string Message { get; set; }

        
    }
}