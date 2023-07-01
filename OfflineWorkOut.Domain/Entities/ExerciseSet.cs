using OfflineWorkOut.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineWorkOut.Domain.Entities
{
    public class ExerciseSet : BaseEntity<int>
    {
        public Exercise Exercise { get; set; }
        public ICollection<ExerciseRound> Rounds { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public int RestTime { get; set; }
        public string Note { get; set; }

        public ExerciseSet()
        { 
            Rounds = new List<ExerciseRound>();
        }
    }
}
