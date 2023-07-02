using OfflineWorkOut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineWorkOut.Application.Models.DTOs
{
    public class ExerciseRoundDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int Repetitions { get; set; }
        public int Rounds { get; set; }
        public int? Weight { get; set; }
    }
}
