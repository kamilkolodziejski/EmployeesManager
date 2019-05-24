using EmployeesManager.Core.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Infrastructure.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Items["OrginalPath"] = context.Request.Path;
                context.Request.Path = "/Error";

                var exceptionType = ex.GetType();
                if(exceptionType == typeof(EmployeeManagerException))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Items["ExceptionMsg"] = ex.Message;
                    context.Items["ExceptionType"] = "Błąd aplikacji";
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Items["ExceptionMsg"] = ex.InnerException.Message;
                    context.Items["ExceptionType"] = "Błąd wewnętrzny serwera";
                }
                await _next(context);
            }
        }
    }
}
