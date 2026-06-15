using Buildline.Platform.Materials.Domain.Model.Aggregates;
using Buildline.Platform.Materials.Domain.Model.Queries;

namespace Buildline.Platform.Materials.Application.QueryServices;

public interface IMaterialQueryService
{
    Task<IEnumerable<Material>> Handle(GetAllMaterialsQuery query, CancellationToken cancellationToken = default);
}
