using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext:DbContext
    {
        public HotelListingDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id=1,
                    Name="Türkiye",
                    ShortName="Tr"
                },
                new Country
                {
                    Id = 2,
                    Name = "İngiltere",
                    ShortName = "En"
                },
                new Country
                {
                    Id = 3,
                    Name = "Fransa",
                    ShortName = "Fr"
                },
                new Country
                {
                    Id = 4,
                    Name = "Bahama",
                    ShortName = "Bs"
                }
                );
            modelBuilder.Entity<Hotel>().HasData(
                
                new Hotel
                {
                    Id=1,
                    Name="Türkiye Hotel",
                    Adress="İstanbul",
                    Rating=4.7,
                    CountryId=1,
                },
                  new Hotel
                  {
                      Id = 2,
                      Name = "İngiltere Hotel",
                      Adress = "İstanbul",
                      Rating = 4.7,
                      CountryId = 2,
                  },
                    new Hotel
                    {
                        Id = 3,
                        Name = "Fıransa Hotel",
                        Adress = "İstanbul",
                        Rating = 4.2,
                        CountryId = 3,
                    },
                      new Hotel
                      {
                          Id = 4,
                          Name = "Bahama Hotel",
                          Adress = "İstanbul",
                          Rating = 3.7,
                          CountryId = 4,
                      },
                        new Hotel
                        {
                            Id = 5,
                            Name = "Türkiye Hotel",
                            Adress = "İstanbul",
                            Rating = 5.0,
                            CountryId = 1,
                        }


                );
        }
    }
}
