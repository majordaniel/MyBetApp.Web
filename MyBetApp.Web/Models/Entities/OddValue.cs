using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBetApp.Web.Models.Entities
{
    public class OddValue
    {
        public int OddValueId { get; set; }
        public int? OddValueFigure { get; set; }
        public int? OddId { get; set; }

        public virtual TbOdds Odd { get; set; }
    }
}
