using Buildline.Platform.Materials.Domain.Model.Aggregates;
using Microsoft.AspNetCore.Mvc;

namespace Buildline.Platform.Materials.Interfaces.Rest.Transform;

public static class MaterialsActionResultAssembler
{
    public static IActionResult ToActionResultFromGetAllMaterialsResult(
        IEnumerable<Material> materials,
        Func<IEnumerable<Material>, IActionResult> successAction)
    {
        var materialList = materials.ToList();
        return materialList.Count == 0 ? new NoContentResult() : successAction(materialList);
    }
}
