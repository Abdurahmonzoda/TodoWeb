using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Wrapper
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public Response(T data)
        {
            Data = data;
            StatusCode = HttpStatusCode.OK;
            Message = null; 
        }
        public Response(HttpStatusCode statusCode, string messenge)
        {
            StatusCode = statusCode;
            Message = messenge;
        }
    }
}
