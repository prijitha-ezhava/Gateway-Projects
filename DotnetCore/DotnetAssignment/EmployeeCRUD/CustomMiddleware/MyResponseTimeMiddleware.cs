﻿using EmployeeCRUD.CustomMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.CustomMiddleware
{
    public class MyResponseTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public MyResponseTimeMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;
            logFactory.AddFile("Logs/ResponseTimeLogger.txt");
            _logger = logFactory.CreateLogger("ResponseTime");
        }

        //Response Time measurement for each each response
        public async Task Invoke(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();
            context.Response.OnStarting(() => {
                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                _logger.LogInformation("{Duration}ms", responseTimeForCompleteRequest);
                return Task.CompletedTask;
            });
            await _next(context);
        }
    }
}

public static class MyMiddleWareExtensions
{
    public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyResponseTimeMiddleware>();
    }
}