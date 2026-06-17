using Buildline.Platform.Requisition.Domain.Model.Aggregates;

namespace Buildline.Platform.Requisition.Application.QueryServices;

/// <summary>
///     Defines read operations exposed by the Materials application layer.
/// </summary>
/// <remarks>
///     Query services separate read use cases from write commands and keep REST controllers from
///     depending directly on Entity Framework Core repositories.
/// </remarks>
public interface IMaterialQueryService
{
    /// <summary>
    ///     Lists every material currently registered.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel repository access.</param>
    /// <returns>The materials available to requisition and inventory workflows.</returns>
    Task<IEnumerable<Material>> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Finds one material by its unique identifier.
    /// </summary>
    /// <param name="materialId">The identifier of the material to look up.</param>
    /// <param name="cancellationToken">Token used to cancel repository access.</param>
    /// <returns>The material when it exists; otherwise <c>null</c>.</returns>
    Task<Material?> FindByIdAsync(int materialId, CancellationToken cancellationToken = default);
}

