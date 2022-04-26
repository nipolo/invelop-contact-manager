using System.Net;

using FluentValidation;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace INV.ContactManager.Api.Exceptions
{
	public class HttpResponseExceptionFilter : IExceptionFilter
	{
		private readonly ILogger<HttpResponseExceptionFilter> _logger;

		public HttpResponseExceptionFilter(ILogger<HttpResponseExceptionFilter> logger)
		{
			_logger = logger;
		}

		public void OnException(ExceptionContext context)
		{
			if (context.Exception != null)
			{
				var errorMessage = "";

				if (context.Exception is ValidationException)
				{
					var exception = (ValidationException)context.Exception;

					foreach (var error in exception.Errors)
					{
						errorMessage += $"{error.PropertyName}: {error.ErrorMessage}\n";
					}
				}
				else
				{
					errorMessage = context.Exception.Message;
				}

				context.Result = new ObjectResult(errorMessage)
				{
					StatusCode = (int)HttpStatusCode.BadRequest
				};

				context.ExceptionHandled = true;
			}


			if (context.Exception != null)
			{
				_logger.LogError(context.Exception, context.Exception.Message);
			}
		}
	}
}
