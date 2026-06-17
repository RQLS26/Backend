using Buildline.Platform.Inventory.Application.QueryServices;
using Buildline.Platform.Inventory.Domain.Model.Aggregates;
using Buildline.Platform.Inventory.Domain.Repositories;

namespace Buildline.Platform.Inventory.Application.Internal.QueryServices;

/// <summary>
///     Application query service that coordinates read access to material categories.
/// </summary>
/// <param name="categoryRepository">Repository used to retrieve persisted category aggregates.</param>
/// <remarks>
///     Categories are read-only reference data in the current Sprint 3 backend. This service keeps
///     the controller aligned with the CQRS style and prepares the context for future filtering rules.
/// </remarks>
public class CategoryQueryService(ICategoryRepository categoryRepository) : ICategoryQueryService
{
    /// <summary>
    ///     Retrieves every material category available in material references.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the repository call.</param>
    /// <returns>A collection of category aggregates, possibly empty.</returns>
    public async Task<IEnumerable<Category>> ListAsync(CancellationToken cancellationToken = default)
        => await categoryRepository.ListAsync(cancellationToken);

    /// <summary>
    ///     Retrieves a single material category by identifier.
    /// </summary>
    /// <param name="categoryId">Identifier of the category aggregate to look up.</param>
    /// <param name="cancellationToken">Token used to cancel the repository call.</param>
    /// <returns>The category aggregate when found; otherwise <c>null</c>.</returns>
    public async Task<Category?> FindByIdAsync(int categoryId, CancellationToken cancellationToken = default)
        => await categoryRepository.FindByIdAsync(categoryId, cancellationToken);
}


