using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBetApp.Web.Models
{
    public partial class TbOdds
    {
        [Key]
        public int OddId { get; set; }
        public string OddName { get; set; }
        public int? GameId { get; set; }
 

        public virtual TbOdds Game { get; set; }
        //public virtual ICollection<TbOddValue> TbOddValue { get; set; }
    }
}
