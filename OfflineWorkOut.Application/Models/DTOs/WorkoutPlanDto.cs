using OfflineWorkOut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineWorkOut.Application.Models.DTOs
{
    public class WorkoutPlanDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExerciseSetDto> ExerciseSets { get; set; }

        public WorkoutPlanDto()
        {
            ExerciseSets = new List<ExerciseSetDto>();
        }
    }
}
