using Buildline.Platform.Shared.Application.Model;
using Buildline.Platform.Shared.Interfaces.Rest.ProblemDetails;
using Microsoft.AspNetCore.Mvc;

namespace Buildline.Platform.Shared.Interfaces.Rest.Transform;

/// <summary>
///     Converts application command results into HTTP responses for bounded contexts that follow the
///     shared command-service pattern.
/// </summary>
public static class ApplicationResultActionResultAssembler
{
    /// <summary>
    ///     Converts a result containing a value into either the success response selected by the
    ///     controller or a standardized Problem Details response.
    /// </summary>
    /// <typeparam name="T">Type returned by the successful application operation.</typeparam>
    /// <param name="controller">Controller instance used to create framework-compatible Problem Details.</param>
    /// <param name="result">Application result returned by the command service.</param>
    /// <param name="problemDetailsFactory">Factory responsible for standardized error payloads.</param>
    /// <param name="successAction">Action used to shape the successful response.</param>
    /// <returns>An HTTP action result for the application operation.</returns>
    public static IActionResult ToActionResult<T>(
        ControllerBase controller,
        Result<T> result,
        ProblemDetailsFactory problemDetailsFactory,
        Func<T, IActionResult> successAction)
    {
        if (result.IsSuccess) return successAction(result.Value!);
        return problemDetailsFactory.CreateProblemDetails(
            controller,
            ToStatusCodeFromError(result.Error),
            result.Error,
            result.Message);
    }

    /// <summary>
    ///     Converts a value-less result into either the success response selected by the controller or
    ///     a standardized Problem Details response.
    /// </summary>
    /// <param name="controller">Controller instance used to create framework-compatible Problem Details.</param>
    /// <param name="result">Application result returned by the command service.</param>
    /// <param name="problemDetailsFactory">Factory responsible for standardized error payloads.</param>
    /// <param name="successAction">Action used to shape the successful response.</param>
    /// <returns>An HTTP action result for the application operation.</returns>
    public static IActionResult ToActionResult(
        ControllerBase controller,
        Result result,
        ProblemDetailsFactory problemDetailsFactory,
        Func<IActionResult> successAction)
    {
        if (result.IsSuccess) return successAction();
        return problemDetailsFactory.CreateProblemDetails(
            controller,
            ToStatusCodeFromError(result.Error),
            result.Error,
            result.Message);
    }

    /// <summary>
    ///     Maps bounded-context error names to REST status codes using a suffix convention.
    ///     Each application error enum value SHOULD end with one of the recognised suffixes so that
    ///     the controller layer can produce appropriate HTTP Problem Details without per-context wiring.
    /// </summary>
    /// <param name="error">Error enum emitted by the application layer.</param>
    /// <returns>The HTTP status code that best represents the failure.</returns>
    private static int ToStatusCodeFromError(Enum? error)
    {
        return error?.ToString() switch
        {
            { } name when name.EndsWith("NotFound", StringComparison.OrdinalIgnoreCase) => StatusCodes.Status404NotFound,
            { } name when name.EndsWith("Invalid", StringComparison.OrdinalIgnoreCase) => StatusCodes.Status400BadRequest,
            { } name when name.EndsWith("AlreadyTaken", StringComparison.OrdinalIgnoreCase) => StatusCodes.Status409Conflict,
            { } name when name.EndsWith("AlreadyExists", StringComparison.OrdinalIgnoreCase) => StatusCodes.Status409Conflict,
            { } name when name.EndsWith("Cancelled", StringComparison.OrdinalIgnoreCase) => 499,
            { } name when name.EndsWith("DatabaseError", StringComparison.OrdinalIgnoreCase) => StatusCodes.Status500InternalServerError,
            { } name when name.EndsWith("InternalServerError", StringComparison.OrdinalIgnoreCase) => StatusCodes.Status500InternalServerError,
            { } name when name.EndsWith("Unauthorized", StringComparison.OrdinalIgnoreCase) => StatusCodes.Status401Unauthorized,
            { } name when name.EndsWith("Forbidden", StringComparison.OrdinalIgnoreCase) => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status400BadRequest
        };
    }
}
