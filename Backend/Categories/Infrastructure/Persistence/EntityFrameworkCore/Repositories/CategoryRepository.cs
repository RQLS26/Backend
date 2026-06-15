using Buildline.Platform.Categories.Domain.Model.Aggregates;
using Buildline.Platform.Categories.Domain.Repositories;
using Buildline.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Buildline.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace Buildline.Platform.Categories.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class CategoryRepository(AppDbContext context) : BaseRepository<Category>(context), ICategoryRepository;
