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
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Cat>()
          .HasData(
              new Cat { CatId = 1, Name = "Tom", Age = 1, Sex = "Male"},
              new Cat { CatId = 2, Name = "Spot", Age = 5, Sex = "Male"},
              new Cat { CatId = 3, Name = "Kuki", Age = 5, Sex = "Female"},
              new Cat { CatId = 4, Name = "Pichy", Age = 4, Sex = "Male"},
              new Cat { CatId = 5, Name = "Lola", Age = 3, Sex = "Female"}
          );

      builder.Entity<Dog>()
          .HasData(
              new Dog { DogId = 1, Name = "Goofy", Age = 3, Sex = "Male"},
              new Dog { DogId = 2, Name = "Luna", Age = 2, Sex = "Female"},
              new Dog { DogId = 3, Name = "Tobias", Age = 1, Sex = "Male"},
              new Dog { DogId = 4, Name = "Rumbo", Age = 9, Sex = "Male"},
              new Dog { DogId = 5, Name = "Pluto", Age = 8, Sex = "Male"}
          );

          builder.Entity<User>()
          .HasData(
              new User { UserId = 1, Name = "Matt", Password = "Goofy"},
              new User { UserId = 2, Name = "Don", Password = "Luna"},
              new User { UserId = 3, Name = "Lisa", Password = "Tobias"}
          );
    }
  }
}