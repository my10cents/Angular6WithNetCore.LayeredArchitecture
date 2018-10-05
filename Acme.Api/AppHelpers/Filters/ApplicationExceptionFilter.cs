using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Acme.Api.AppHelpers.Filters
{
    public class ApplicationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            //TODO: record log of exception, return code of log in the message

            var errorModel = new ErrorModel
            {
                Key = "-",
                Message = exception.Message
            };

            var response = new ObjectResult(errorModel)
            {
                StatusCode = StatusCodes.Status417ExpectationFailed
            };
            context.Result = response;

        }
    }

    [DataContract]
    internal class ErrorModel
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
