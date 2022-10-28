using Microsoft.EntityFrameworkCore;

namespace Animal_Shelter.Models
{
  public class Animal_ShelterContext : DbContext
  {
    public Animal_ShelterContext(DbContextOptions<Animal_ShelterContext> options)
      : base(options)
    {
    }

    public DbSet<Cat> Cats { get; set; }
    public DbSet<Dog> Dogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Cat>()
          .HasData(
              new Cat { CatId = 1, Name = "Tom", Age = 1},
              new Cat { CatId = 2, Name = "Spot", Age = 2.5},
              new Cat { CatId = 3, Name = "Kuki", Age = 0.5},
              new Cat { CatId = 4, Name = "Pichy", Age = 4},
              new Cat { CatId = 5, Name = "Lola", Age = 3}
          );

      builder.Entity<Dog>()
          .HasData(
              new Dog { DogId = 1, Name = "Goofy", Age = 3},
              new Dog { DogId = 2, Name = "Luna", Age = 2},
              new Dog { DogId = 3, Name = "Tobias", Age = 1.8},
              new Dog { DogId = 4, Name = "Rumbo", Age = 0.9},
              new Dog { DogId = 5, Name = "Pluto", Age = 8}
          );
    }
  }
}