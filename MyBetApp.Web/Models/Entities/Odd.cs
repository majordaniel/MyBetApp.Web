using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBetApp.Web.Models.Entities
{
    public class Odd
    {

        public int OddId { get; set; }
        public string GameName { get; set; }
        public int HomeValue { get; set; }
        public int DrawValue { get; set; }
        public int AwayValue { get; set; }
        public DateTime GameDate { get; set; }

        public long StakeAmount { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public bool Status { get; set; }


        public string OddCreator { get; set; }
    }
}
