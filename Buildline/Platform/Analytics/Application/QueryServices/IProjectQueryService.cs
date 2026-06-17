using Buildline.Platform.Analytics.Domain.Model.Aggregates;

namespace Buildline.Platform.Analytics.Application.QueryServices;

/// <summary>
///     Defines read operations exposed by the Projects application layer.
/// </summary>
/// <remarks>
///     Query services keep REST controllers independent from repository implementations and preserve
///     the CQRS split used across the course sample backend.
/// </remarks>
public interface IProjectQueryService
{
    /// <summary>
    ///     Lists every construction project reference.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel repository access.</param>
    /// <returns>The projects available to frontend filters and dashboard views.</returns>
    Task<IEnumerable<Project>> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Finds one construction project by identifier.
    /// </summary>
    /// <param name="projectId">The identifier of the project to look up.</param>
    /// <param name="cancellationToken">Token used to cancel repository access.</param>
    /// <returns>The project when it exists; otherwise <c>null</c>.</returns>
    Task<Project?> FindByIdAsync(int projectId, CancellationToken cancellationToken = default);
}

