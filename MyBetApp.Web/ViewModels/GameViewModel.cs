using System;

namespace MyBetApp.Web.Repositories.Abstracts
{
    public class GameViewModel
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string StakeAmount { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? Status { get; set; }
    }
}