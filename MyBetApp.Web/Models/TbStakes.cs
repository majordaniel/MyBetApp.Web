using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBetApp.Web.Models
{
    public class TbStakes
    {
        [Key]
        public int StakeID { get; set; }
        public string UserID { get; set; }

        public string TotalStakeAmount { get; set; }


    }
}
