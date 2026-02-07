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

           
            
            modelBuilder.Entity<Apartment>().HasData(

                 new Apartment
                 {
                     Id = 1,
                     Name = "Όροφος Δημήτρη",
                     Type = ApartmentType.Floor
                 },

                  new Apartment
                  {
                      Id = 2,
                      Name = "Καταστημα - Ισογειο Δημήτρη",
                      Type = ApartmentType.Shop
                  },

                   new Apartment
                   {
                       Id = 3,
                       Name = "Υπογειο Δημήτρη",
                       Type = ApartmentType.Basement
                   },

                    new Apartment
                    {
                        Id = 4,
                        Name = "Όροφος Νικου",
                        Type = ApartmentType.Floor
                    },

                     new Apartment
                     {
                         Id = 5,
                         Name = "Καταστημα - Ισογειο Νικου",
                         Type = ApartmentType.Shop
                     },

                      new Apartment
                      {
                          Id = 6,
                          Name = "Υπογειο Νικου",
                          Type = ApartmentType.Basement
                      }

                     


            );







        }
    }
}
