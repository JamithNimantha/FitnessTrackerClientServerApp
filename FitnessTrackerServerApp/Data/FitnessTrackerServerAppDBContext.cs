using Microsoft.EntityFrameworkCore;
using FitnessTrackerServerApp.Model;

namespace FitnessTrackerServerApp.Data
{
    public class FitnessTrackerServerAppDBContext : DbContext
    {
        public FitnessTrackerServerAppDBContext (DbContextOptions<FitnessTrackerServerAppDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<WorkoutEntry>()
                .HasOne(x => x.WeightEntry);

            builder.Entity<CheatMealEntry>()
                .HasOne(x => x.WeightEntry);

            new DBInitializer(builder).Seed();
        }

        public DbSet<FitnessTrackerServerApp.Model.User> User { get; set; } = default!;
        public DbSet<FitnessTrackerServerApp.Model.WeightEntry> WeightEntry { get; set; } = default!;
        public DbSet<FitnessTrackerServerApp.Model.WorkoutEntry> WorkoutEntry { get; set; } = default!;
        public DbSet<FitnessTrackerServerApp.Model.CheatMealEntry> CheatMealEntry { get; set; } = default!;

    }
}
