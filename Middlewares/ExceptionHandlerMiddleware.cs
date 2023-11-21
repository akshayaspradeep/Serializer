using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Sample_Serializer.Middlewares
{
      
        
    public class ExceptionHandlerMiddleware
    {
            
       private readonly RequestDelegate _next;
       private readonly ILogger<ExceptionHandlerMiddleware> _logger;
       public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
       {
                    _logger = logger;
                    _next = next;
       }

       public async Task InvokeAsync(HttpContext httpContext)
       {
          try
          { 
            await _next(httpContext);  
          }
          catch (Exception ex)
          {
             var errorId = Guid.NewGuid();

           //Log this Exception
           _logger.LogError(ex, $"{errorId} : {ex.Message}" );

             // Return a custom Error Response
             httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
             httpContext.Response.ContentType = "application/json";

             var error = new
             {
                  Id = errorId,
                  ErrorMessage = "Something went wrong! we are looking into resolving this."
             };
             await httpContext.Response.WriteAsJsonAsync(error);
         }
    }
     }
 }