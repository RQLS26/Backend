using Buildline.Platform.Iam.Application.QueryServices;
using Buildline.Platform.Iam.Domain.Model.Aggregates;
using Buildline.Platform.Iam.Domain.Repositories;

namespace Buildline.Platform.Iam.Application.Internal.QueryServices;

/// <summary>
///     Application query service that coordinates read access to IAM users.
/// </summary>
/// <param name="userRepository">Repository used to retrieve persisted user aggregates.</param>
/// <remarks>
///     The service supports authentication lookups and the users-management API while keeping
///     controllers independent from Entity Framework Core.
/// </remarks>
public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    /// <summary>
    ///     Retrieves every registered user.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the repository call.</param>
    /// <returns>A collection of user aggregates, possibly empty.</returns>
    public async Task<IEnumerable<User>> ListAsync(CancellationToken cancellationToken = default)
        => await userRepository.ListAsync(cancellationToken);

    /// <summary>
    ///     Retrieves one user by identifier.
    /// </summary>
    /// <param name="userId">Identifier of the user aggregate to look up.</param>
    /// <param name="cancellationToken">Token used to cancel the repository call.</param>
    /// <returns>The user aggregate when found; otherwise <c>null</c>.</returns>
    public async Task<User?> FindByIdAsync(int userId, CancellationToken cancellationToken = default)
        => await userRepository.FindByIdAsync(userId, cancellationToken);

    /// <summary>
    ///     Retrieves one user by email.
    /// </summary>
    /// <param name="email">Email address of the user aggregate to look up.</param>
    /// <param name="cancellationToken">Token used to cancel the repository call.</param>
    /// <returns>The user aggregate when found; otherwise <c>null</c>.</returns>
    public async Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
        => await userRepository.FindByEmailAsync(email, cancellationToken);
}
