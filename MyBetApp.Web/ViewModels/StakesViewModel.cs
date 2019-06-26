using MyBetApp.Web.Models;
using System.Collections.Generic;

namespace MyBetApp.Web.ViewModels
{
    public class StakesViewModel
    {
        public TbStakes Stakes { get; set; }
        public List<TbStakeDetails> StakesDetails { get; set; }
    }
}