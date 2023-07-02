using FluentResults;
using Mapster;
using Microsoft.EntityFrameworkCore;
using OfflineWorkOut.Application.Models.DTOs;
using OfflineWorkOut.Domain.Entities;
using OfflineWorkOut.Infrastructure.DbContexts;
using SqliteWasmHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineWorkOut.Infrastructure.Services
{
    public class WorkoutsService
    {
        private readonly ISqliteWasmDbContextFactory<OfflineWorkoutDbContext> _factory;

        public WorkoutsService(ISqliteWasmDbContextFactory<OfflineWorkoutDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<Result> LoadData(List<WorkoutPlanDto> workoutPlanDtos)
        {
            using var context = await _factory.CreateDbContextAsync();
            foreach(var workoutPlan in workoutPlanDtos) 
            { 
                var created = await CreateWorkoutPlan(workoutPlan, context);
                if(!created.IsSuccess) 
                    return Result.Fail(created.Errors);
            }
            return Result.Ok();
        }

        private async Task<Result> CreateWorkoutPlan(WorkoutPlanDto plan, OfflineWorkoutDbContext context)
        {
            try
            {
                context.WorkoutPlans.Add(new WorkoutPlan
                {
                    Name = plan.Name,
                    ExerciseSets = plan.ExerciseSets.Select(x => x.Adapt<ExerciseSet>()).ToList()
                });
                await context.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception ex) 
            { 
                return Result.Fail(ex.Message);
            }
        }


    }
}
