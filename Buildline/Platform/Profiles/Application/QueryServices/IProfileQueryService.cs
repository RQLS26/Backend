using Buildline.Platform.Profiles.Domain.Model.Aggregates;

namespace Buildline.Platform.Profiles.Application.QueryServices;

/// <summary>
///     Defines read operations exposed by the Profiles application layer.
/// </summary>
public interface IProfileQueryService
{
    /// <summary>
    ///     Finds one company profile by identifier.
    /// </summary>
    /// <param name="profileId">The identifier of the profile to look up.</param>
    /// <param name="cancellationToken">Token used to cancel repository access.</param>
    /// <returns>The profile when it exists; otherwise <c>null</c>.</returns>
    Task<Profile?> FindByIdAsync(int profileId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lists every company profile registered in the platform.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel repository access.</param>
    /// <returns>The registered company profiles.</returns>
    Task<IEnumerable<Profile>> ListAsync(CancellationToken cancellationToken = default);
}
