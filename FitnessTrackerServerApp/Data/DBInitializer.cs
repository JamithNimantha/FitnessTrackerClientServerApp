using FitnessTrackerApp.Model;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerServerApp.Data
{
    public class DBInitializer
    {
        private readonly ModelBuilder _builder;

        public DBInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            // Users
            _builder.Entity<User>( a =>
            {
                a.HasData(new User
                {
                    DateofBirth = new DateTime(1998, 04, 19),
                    UserName = "jamith",
                    Name = "Jamith Nimantha",
                    Password = "pCVA+jmMayKhtXV2/gUGP1wnYX3R5JNvy52q1Vy8Yj4=",
                    Gender = Enumeration.Gender.MALE,
                    Height = 183,
                }
                );

                a.HasData(new User
                {
                    DateofBirth = new DateTime(2000, 01, 01),
                    UserName = "admin",
                    Name = "Admin",
                    Password = "pCVA+jmMayKhtXV2/gUGP1wnYX3R5JNvy52q1Vy8Yj4=",
                    Gender = Enumeration.Gender.MALE,
                    Height = 153,
                }
                );
            });


            // Weight Entries

            _builder.Entity<WeightEntryDTO>(a =>
            {
                a.HasData(new WeightEntryDTO
                {
                    WeightEntryId = new Guid("0a5099b5-d7be-4948-871e-897c487a5f4c"),
                    Date = new DateTime(2021, 04, 19),
                    UserName = "jamith",
                    Weight = 80
                }
                );
            });

            _builder.Entity<WeightEntryDTO>(a =>
            {
                a.HasData(new WeightEntryDTO
                {
                    WeightEntryId = new Guid("1a5099b5-d7be-4948-871e-897c487a5f4c"),
                    Date = new DateTime(2021, 04, 19),
                    UserName = "jamith",
                    Weight = 77
                }
                );
            });


            // Workout Entries

            _builder.Entity<WorkoutEntry>(a =>
            {
                a.HasData(new WorkoutEntry
                {
                    WorkoutEntryId = new Guid("6ef682cc-c428-4021-a18d-04d50e1417bb"),
                    Date = new DateTime(2021, 04, 19),
                    WorkoutName = "Running",
                    UserName = "jamith",
                    Intensity = "High",
                    CaloriesBurned = 1200,
                    WeightEntryId = new Guid("0a5099b5-d7be-4948-871e-897c487a5f4c")
                }
                );
            });
        }
    }
}
