using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace HockeyScoreboardCentral.Shared.Entity
{
    public class Game
    {
        public Int64 TotalGameTime { get; set; }
        public Int64 PeriodTime { get; set; }
        public Int64 CurrentPeriodTime { get; set; }
        public Int32 PeriodNumber { get; set; }
        public Team Home { get; set; }
        public Team Guest { get; set; }
        public Penalty FirstHomePenalty { get; set; }
        public Penalty SecondHomePenalty { get; set; }
        public Penalty FirstGuestPenalty { get; set; }
        public Penalty SecondGuestPenalty { get; set; }
        public Dictionary<Guid, Penalty> PenaltyQueueHome { get; set; }
        public Dictionary<Guid, Penalty> PenaltyQueueGuest { get; set; }
        public Dictionary<Guid, IGameEvent> Events { get; set; }

        public Game()
        {
            TotalGameTime = 0;
            PeriodTime = 20 * 60 * 1000;
            PeriodNumber = 1;
            Events = new Dictionary<Guid, IGameEvent>();
            PenaltyQueueHome = new Dictionary<Guid, Penalty>();
            PenaltyQueueGuest = new Dictionary<Guid, Penalty>();
        }
    }
}
