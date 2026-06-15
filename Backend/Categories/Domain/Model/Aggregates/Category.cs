using Buildline.Platform.Shared.Domain.Model.Entities;

namespace Buildline.Platform.Categories.Domain.Model.Aggregates;

/// <summary>
///     Material category aggregate root for catalog classification.
/// </summary>
public partial class Category : IAuditableEntity
{
    protected Category()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
