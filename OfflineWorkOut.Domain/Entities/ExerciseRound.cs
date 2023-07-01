using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineWorkOut.Domain.Entities
{
    public class ExerciseRound : BaseEntity<int>
    {
        public int Order { get; set; }
        public int Repetitions { get; set; }
        public int Rounds { get; set; }
        public int? Weight { get; set; }
    }
}
