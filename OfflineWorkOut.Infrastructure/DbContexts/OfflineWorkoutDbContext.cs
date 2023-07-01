using Microsoft.EntityFrameworkCore;
using OfflineWorkOut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineWorkOut.Infrastructure.DbContexts
{
    public class OfflineWorkoutDbContext : DbContext
    {
        public OfflineWorkoutDbContext(DbContextOptions<OfflineWorkoutDbContext> opts) : base(opts)
        {
        }

        public DbSet<WorkoutPlan> WorkoutPlans { get; set; } = null!;
        public DbSet<ExerciseRound> ExerciseRounds { get; set; } = null!;
        public DbSet<ExerciseSet> ExerciseSets { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;
    }
}
