using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBetApp.Web.Models
{
    public class TbStakeDetails
    {
        [Key]
        public int StakeDetailID { get; set; }
        public int StakeID { get; set; }

        public TbStakes TbStakes { get; set; }
        public int OddId { get; set; }
        public int HomeValue { get; set; }
        public int DrawValue { get; set; }
        public int AwayValue { get; set; }
        public long StakeAmount { get; set; }
        public DateTime StakeDate { get; set; }
    }
}
