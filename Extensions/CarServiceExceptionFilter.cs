using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CarService.API.Exceptions;
using CarService.Services.Contracts.Exceptions;

namespace CarService.API.Extensions
{
    /// <summary>
    /// Фильтр для обработки ошибок раздела администрирования
    /// </summary>
    public class CarServiceExceptionFilter : IExceptionFilter
    {
        /// <inheritdoc/>
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception as CarServiceException;
            if (exception == null)
            {
                return;
            }

            switch (exception)
            {
                case CarServiceValidationException ex:
                    SetDataToContext(
                        new ConflictObjectResult(new ApiValidationExceptionsDetail
                        {
                            Errors = ex.Errors,
                        }),
                        context);
                    break;

                case CarServiceInvalidOperationException ex:
                    SetDataToContext(
                        new BadRequestObjectResult(new ApiExceptionsDetail { Message = ex.Message, })
                        {
                            StatusCode = StatusCodes.Status406NotAcceptable,
                        },
                        context);
                    break;

                case CarServiceNotFoundException ex:
                    SetDataToContext(new NotFoundObjectResult(new ApiExceptionsDetail
                    {
                        Message = ex.Message,
                    }), context);
                    break;
           
                default:
                    SetDataToContext(new BadRequestObjectResult(new ApiExceptionsDetail
                    {
                        Message = $"Ошибка записи в БД (Проверьте индексы). {exception.Message}",
                    }), context);
                    break;
            }
        }

        /// <summary>
        /// Определяет контекст ответа
        /// </summary>
        static protected void SetDataToContext(ObjectResult data, ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            response.StatusCode = data.StatusCode ?? StatusCodes.Status400BadRequest;
            context.Result = data;
        }
    }
}
