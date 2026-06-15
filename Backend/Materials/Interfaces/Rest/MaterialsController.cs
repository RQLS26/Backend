using System.Net.Mime;
using Buildline.Platform.Materials.Application.QueryServices;
using Buildline.Platform.Materials.Domain.Model.Queries;
using Buildline.Platform.Materials.Interfaces.Rest.Resources;
using Buildline.Platform.Materials.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Buildline.Platform.Materials.Interfaces.Rest;

[ApiController]
[Route("api/v1/materials")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Material Catalog endpoints for requisitions and inventory.")]
public class MaterialsController(IMaterialQueryService materialQueryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all materials",
        Description = "Gets all registered materials available for requisitions and inventory workflows.",
        OperationId = "GetAllMaterials")]
    [SwaggerResponse(StatusCodes.Status200OK, "The materials were found and returned.", typeof(IEnumerable<MaterialResource>))]
    [SwaggerResponse(StatusCodes.Status204NoContent, "No materials are currently registered.")]
    public async Task<IActionResult> GetAllMaterials(CancellationToken cancellationToken)
    {
        var query = new GetAllMaterialsQuery();
        var materials = await materialQueryService.Handle(query, cancellationToken);

        return MaterialsActionResultAssembler.ToActionResultFromGetAllMaterialsResult(
            materials,
            foundMaterials => Ok(foundMaterials.Select(MaterialResourceFromEntityAssembler.ToResourceFromEntity)));
    }
}
