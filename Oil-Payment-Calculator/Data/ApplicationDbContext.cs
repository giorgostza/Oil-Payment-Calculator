using Microsoft.EntityFrameworkCore;
using Oil_Payment_Calculator.Models;

namespace Oil_Payment_Calculator.Data
{
    public class ApplicationDbContext : DbContext
    {




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }


        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<MeterReading> MeterReadings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Apartment>().Property(a => a.Coefficient).HasPrecision(18, 2); // 18 συνολικα ψηφια , 2 δεκαδικα



            modelBuilder.Entity<Apartment>().HasData(

                 new Apartment
                 {
                     Id = 1,
                     Name = "Όροφος Δημήτρη",
                     Type = ApartmentType.Floor,
                     Coefficient = 17500m
                 },

                  new Apartment
                  {
                      Id = 2,
                      Name = "Καταστημα - Ισογειο Δημήτρη",
                      Type = ApartmentType.Shop,
                      Coefficient = 16640m
                  },

                   new Apartment
                   {
                       Id = 3,
                       Name = "Υπογειο Δημήτρη",
                       Type = ApartmentType.Basement,
                       Coefficient = 6000m
                   },

                    new Apartment
                    {
                        Id = 4,
                        Name = "Όροφος Νικου",
                        Type = ApartmentType.Floor,
                        Coefficient = 17500m
                    },

                     new Apartment
                     {
                         Id = 5,
                         Name = "Καταστημα - Ισογειο Νικου",
                         Type = ApartmentType.Shop,
                         Coefficient = 16640m
                     },

                      new Apartment
                      {
                          Id = 6,
                          Name = "Υπογειο Νικου",
                          Type = ApartmentType.Basement,
                          Coefficient = 6000m
                      }

                     


            );







        }
    }
}
