using Buildline.Platform.Categories.Domain.Model.Aggregates;
using Buildline.Platform.Categories.Interfaces.Rest.Resources;

namespace Buildline.Platform.Categories.Interfaces.Rest.Transform;

public static class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category category)
    {
        return new CategoryResource(category.Id, category.Name, category.Description);
    }
}
