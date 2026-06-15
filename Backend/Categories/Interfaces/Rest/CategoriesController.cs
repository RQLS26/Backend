using System.Net.Mime;
using Buildline.Platform.Categories.Application.QueryServices;
using Buildline.Platform.Categories.Domain.Model.Queries;
using Buildline.Platform.Categories.Interfaces.Rest.Resources;
using Buildline.Platform.Categories.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Buildline.Platform.Categories.Interfaces.Rest;

[ApiController]
[Route("api/v1/categories")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Material Category endpoints.")]
public class CategoriesController(ICategoryQueryService categoryQueryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all material categories",
        Description = "Gets all material categories available for catalog and inventory filters.",
        OperationId = "GetAllCategories")]
    [SwaggerResponse(StatusCodes.Status200OK, "The categories were found and returned.", typeof(IEnumerable<CategoryResource>))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "No categories are currently registered.")]
    public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken)
    {
        var query = new GetAllCategoriesQuery();
        var categories = await categoryQueryService.Handle(query, cancellationToken);

        return CategoriesActionResultAssembler.ToActionResultFromGetAllCategoriesResult(
            categories,
            foundCategories => Ok(foundCategories.Select(CategoryResourceFromEntityAssembler.ToResourceFromEntity)));
    }
}
