using Buildline.Platform.Profiles.Application.QueryServices;
using Buildline.Platform.Profiles.Domain.Model.Aggregates;
using Buildline.Platform.Profiles.Domain.Repositories;

namespace Buildline.Platform.Profiles.Application.Internal.QueryServices;

/// <summary>
///     Application query service for profile read use cases.
/// </summary>
public class ProfileQueryService(IProfileRepository profileRepository) : IProfileQueryService
{
    /// <summary>
    ///     Retrieves one company profile by identifier.
    /// </summary>
    /// <param name="profileId">Identifier of the profile aggregate to look up.</param>
    /// <param name="cancellationToken">Token used to cancel the repository call.</param>
    /// <returns>The profile aggregate when found; otherwise <c>null</c>.</returns>
    public async Task<Profile?> FindByIdAsync(int profileId, CancellationToken cancellationToken = default)
        => await profileRepository.FindByIdAsync(profileId, cancellationToken);

    /// <summary>
    ///     Retrieves every company profile registered in the platform.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the repository call.</param>
    /// <returns>A collection of profile aggregates, possibly empty.</returns>
    public async Task<IEnumerable<Profile>> ListAsync(CancellationToken cancellationToken = default)
        => await profileRepository.ListAsync(cancellationToken);
}
