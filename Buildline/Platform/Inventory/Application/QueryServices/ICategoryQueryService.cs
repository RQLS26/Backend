using Buildline.Platform.Inventory.Domain.Model.Aggregates;

namespace Buildline.Platform.Inventory.Application.QueryServices;

/// <summary>
///     Defines read operations exposed by the Categories application layer.
/// </summary>
/// <remarks>
///     Query services maintain the CQRS split used in the course sample: controllers translate HTTP
///     requests into queries, while repositories remain hidden behind application contracts.
/// </remarks>
public interface ICategoryQueryService
{
    /// <summary>
    ///     Lists every material category.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel repository access.</param>
    /// <returns>The categories available to material and inventory filters.</returns>
    Task<IEnumerable<Category>> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Finds one material category by identifier.
    /// </summary>
    /// <param name="categoryId">The identifier of the category to look up.</param>
    /// <param name="cancellationToken">Token used to cancel repository access.</param>
    /// <returns>The category when it exists; otherwise <c>null</c>.</returns>
    Task<Category?> FindByIdAsync(int categoryId, CancellationToken cancellationToken = default);
}

