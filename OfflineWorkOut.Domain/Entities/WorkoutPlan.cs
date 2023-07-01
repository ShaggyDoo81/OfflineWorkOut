using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineWorkOut.Domain.Entities
{
    public class WorkoutPlan : BaseEntity<int>
    {
        public WorkoutPlan()
        {
            ExerciseSets = new List<ExerciseSet>();
        }

        public ICollection<ExerciseSet> ExerciseSets { get; set; }
    } 
}
