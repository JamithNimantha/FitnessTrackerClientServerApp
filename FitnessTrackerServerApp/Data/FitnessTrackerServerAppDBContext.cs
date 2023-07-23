using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FitnessTrackerApp.Model;

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

        public DbSet<FitnessTrackerApp.Model.User> User { get; set; } = default!;
        public DbSet<FitnessTrackerApp.Model.WeightEntry> WeightEntry { get; set; } = default!;
        public DbSet<FitnessTrackerApp.Model.WorkoutEntry> WorkoutEntry { get; set; } = default!;
    }
}
