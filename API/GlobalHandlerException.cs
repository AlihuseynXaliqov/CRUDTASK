﻿using System.Net.Mime;
using Business.Utils.Exception.Base;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace API
{
    public static class GlobalHandlerException
    {
        public static void UseGlobalException(this WebApplication app)
        {
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    // Default to 500 Internal Server Error
                    int statusCode = StatusCodes.Status500InternalServerError;
                    string errorMessage = "An exception was thrown.";

                    var feature = context.Features.Get<IExceptionHandlerPathFeature>();

                    if (feature?.Error is IBaseException ex)
                    {
                        statusCode = ex.StatusCode != 0 ? ex.StatusCode : StatusCodes.Status500InternalServerError;
                        errorMessage = ex.ErrorMessage; // Use custom exception message if available
                    }
                    else if (feature?.Error is FileNotFoundException)
                    {
                        errorMessage += " The file was not found.";
                    }

                    if (feature?.Path == "/")
                    {
                        errorMessage += " Page: Home.";
                    }

                    // Set response details
                    context.Response.StatusCode = statusCode;
                    context.Response.ContentType = MediaTypeNames.Text.Plain;

                    // Write the response
                    await context.Response.WriteAsync(errorMessage);
                });
            });
        }
    }
}
