using Buildline.Platform.Materials.Domain.Model.Aggregates;
using Buildline.Platform.Materials.Domain.Repositories;
using Buildline.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Buildline.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace Buildline.Platform.Materials.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class MaterialRepository(AppDbContext context) : BaseRepository<Material>(context), IMaterialRepository;
