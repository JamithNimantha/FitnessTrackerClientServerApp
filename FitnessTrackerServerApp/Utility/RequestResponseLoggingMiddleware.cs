using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FitnessTrackerServerApp.Utility
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log the incoming request
            LogRequest(context.Request);

            // Capture the response body to log later
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                // Log the outgoing response
                LogResponse(context.Response);

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private void LogRequest(HttpRequest request)
        {

            string requestDetails = $"Request: {request.Method} {request.Host}{request.Path}{request.QueryString}";


            Console.WriteLine(requestDetails);
        }

        private void LogResponse(HttpResponse response)
        {

            string responseDetails = $"Response StatusCode : {response.StatusCode}";

            Console.WriteLine(responseDetails);

            string responseContent = $"Response Body: {response.Body}";
            Console.WriteLine(responseContent);

            response.Body.Seek(0, SeekOrigin.Begin);
            string responseBody =  new StreamReader(response.Body).ReadToEnd();
            responseBody = $"Response Body: {responseBody}";
            Console.WriteLine(responseBody);

            response.Body.Seek(0, SeekOrigin.Begin);


        }
    }
}
