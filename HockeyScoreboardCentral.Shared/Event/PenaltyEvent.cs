using System;
using HockeyScoreboardCentral.Shared.Entity;

namespace HockeyScoreboardCentral.Shared.Event
{
    public class PenaltyEvent : IGameEvent
    {
        public Guid GameId { get; set; }
        public Guid EventId { get; set; }
        public DateTime EventTime { get; set; }
        public TimeSpan GameTime { get; set; }
        public TimeSpan PeriodTime { get; set; }
        public EGameEvent EvenType { get; private set; }
        public Int32 GamePeriod { get; set; }
        public ETeam Team { get; set; }
        public TimeSpan PenaltyDuration { get; set; }
        public String PlayerNumber { get; set; }
        public String PlayerName { get; set; }

        public PenaltyEvent()
        {
            EventId = Guid.NewGuid();
            EvenType = EGameEvent.Penalty;
        }
    }
}
