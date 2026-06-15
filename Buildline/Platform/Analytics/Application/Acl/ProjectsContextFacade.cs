using Buildline.Platform.Analytics.Application.QueryServices;
using Buildline.Platform.Analytics.Domain.Model.Queries;
using Buildline.Platform.Analytics.Interfaces.Acl;

namespace Buildline.Platform.Analytics.Application.Acl;

/// <summary>
///     Application implementation of the Projects anti-corruption facade.
/// </summary>
/// <param name="projectQueryService">Projects query service used to retrieve shared project reference data.</param>
/// <remarks>
///     The facade keeps project reference lookups consistent for downstream contexts that will use
///     project ids, names and statuses during requisition filtering and budgeting workflows.
/// </remarks>
public class ProjectsContextFacade(IProjectQueryService projectQueryService) : IProjectsContextFacade
{
    /// <inheritdoc />
    public async Task<int> FetchProjectIdByName(string projectName, CancellationToken cancellationToken = default)
    {
        var projects = await projectQueryService.Handle(new GetAllProjectsQuery(), cancellationToken);
        var project = projects.FirstOrDefault(candidate =>
            string.Equals(candidate.Name, projectName, StringComparison.OrdinalIgnoreCase));
        return project?.Id ?? 0;
    }

    /// <inheritdoc />
    public async Task<string> FetchProjectNameById(int projectId, CancellationToken cancellationToken = default)
    {
        var project = await projectQueryService.Handle(new GetProjectByIdQuery(projectId), cancellationToken);
        return project?.Name ?? string.Empty;
    }

    /// <inheritdoc />
    public async Task<string> FetchProjectStatusById(int projectId, CancellationToken cancellationToken = default)
    {
        var project = await projectQueryService.Handle(new GetProjectByIdQuery(projectId), cancellationToken);
        return project?.Status ?? string.Empty;
    }
}

