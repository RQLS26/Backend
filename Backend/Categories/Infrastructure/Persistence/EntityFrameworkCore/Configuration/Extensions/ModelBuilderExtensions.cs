using Buildline.Platform.Categories.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Buildline.Platform.Categories.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyCategoriesConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Category>().HasKey(category => category.Id);
        builder.Entity<Category>().Property(category => category.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(category => category.Name).IsRequired().HasMaxLength(60);
        builder.Entity<Category>().Property(category => category.Description).IsRequired().HasMaxLength(180);

        builder.Entity<Category>().HasData(
            new { Id = 1, Name = "Steel", Description = "Structural steel materials such as rebar and beams." },
            new { Id = 2, Name = "Concrete", Description = "Cement and concrete materials for construction work." },
            new { Id = 3, Name = "Aggregate", Description = "Sand, gravel and related aggregate materials." },
            new { Id = 4, Name = "Plumbing", Description = "Pipes and plumbing-related materials." },
            new { Id = 5, Name = "Electrical", Description = "Electrical wiring and installation materials." },
            new { Id = 6, Name = "Wood", Description = "Plywood and wood-based construction materials." },
            new { Id = 7, Name = "Equipment", Description = "Safety and site operation equipment." },
            new { Id = 8, Name = "General", Description = "General construction supplies." });
    }
}
