using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBetApp.Web.Models
{
    public partial class TbOddValue
    {
        [Key]
        public int OddValueId { get; set; }
        public int? OddValueFigure { get; set; }
        public int? OddId { get; set; }

        public virtual TbOdds Odd { get; set; }
    }
}
