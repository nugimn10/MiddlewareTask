using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System.IO;

namespace MiddleWareTask.Middleware
{
    public class CustomAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomAuthMiddleware (RequestDelegate next)
        {
            _next =next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
            
            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                //start
                var time_start = DateTime.Now;
                Log_.SaveAllLog(context.Response.StatusCode.ToString(),
                    context.Request.Method.ToString(),
                    context.Request.Path.ToString(),
                    context.Request.Host.ToString());

            }


        } 
    }

    public static class AuthMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomAuthMiddleware>();
        }
    }

    public class Log_
    {
        public static string Msg;
        
        public static void SaveAllLog(string statusCode, string HTTPMethods, string RequestPath, string RequestHost)
        {
                File.AppendAllText(@"C:\Users\Nugi\MiddleWareTask\MiddleWareTask\NotFoundLog.log",
                $"[{DateTime.Now}] Started {HTTPMethods} {RequestPath} for {RequestHost} \n");
                File.AppendAllText(@"C:\Users\Nugi\MiddleWareTask\MiddleWareTask\NotFoundLog.log",
                $"[{DateTime.Now}] Completed {statusCode} {RequestPath} not found for {RequestPath} \n");
        }


    }

}