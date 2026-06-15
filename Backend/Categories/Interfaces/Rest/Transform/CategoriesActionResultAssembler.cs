using Buildline.Platform.Categories.Domain.Model.Aggregates;
using Microsoft.AspNetCore.Mvc;

namespace Buildline.Platform.Categories.Interfaces.Rest.Transform;

public static class CategoriesActionResultAssembler
{
    public static IActionResult ToActionResultFromGetAllCategoriesResult(
        IEnumerable<Category> categories,
        Func<IEnumerable<Category>, IActionResult> successAction)
    {
        var categoryList = categories.ToList();
        return categoryList.Count == 0 ? new NoContentResult() : successAction(categoryList);
    }
}
