using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MiniDbApp.Lib.Constants;

namespace MiniDbApp.API.Filters;

public class ApiKeyAuthFilter : IActionFilter
{
    private const string API_KEY_SETTINGS_NAME = "Api:ApiKey";

    public void OnActionExecuting(ActionExecutingContext context)
    {
        
        var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var validApiKey = configuration[API_KEY_SETTINGS_NAME]; // TODO: Replace by ApiKeyService
        
        if (!context.HttpContext.Request.Headers.TryGetValue(Setup.Api.API_KEY_HEADER_NAME, out var extractedApiKey) ||
            extractedApiKey != validApiKey)
        {
            context.Result = new UnauthorizedObjectResult("Invalid or missing API Key.");
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {

    }
}