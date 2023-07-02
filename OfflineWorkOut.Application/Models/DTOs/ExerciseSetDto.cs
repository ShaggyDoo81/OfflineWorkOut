using OfflineWorkOut.Domain.Entities;
using OfflineWorkOut.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineWorkOut.Application.Models.DTOs
{
    public class ExerciseSetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ExerciseDto Exercise { get; set; } 
        public List<ExerciseRoundDto> Rounds { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public int RestTime { get; set; }
        public string Note { get; set; }

        public ExerciseSetDto()
        {
            Rounds = new List<ExerciseRoundDto>();
            Exercise = new ExerciseDto();
        }
    }
}
