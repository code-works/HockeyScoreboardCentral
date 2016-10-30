using System;
using HockeyScoreboardCentral.Shared.Entity;

namespace HockeyScoreboardCentral.Shared.Event
{
    public class StartPeriodEvent : IGameEvent
    {
        public Guid GameId { get; set; }
        public Guid EventId { get; set; }
        public DateTime EventTime { get; set; }
        public TimeSpan GameTime { get; set; }
        public TimeSpan PeriodTime { get; set; }
        public EGameEvent EvenType { get; }
        public ETeam Team { get; set; }
        public Int32 GamePeriod { get; set; }

        public StartPeriodEvent()
        {
            EventId = Guid.NewGuid();
            EvenType = EGameEvent.PeriodStart;
        }
    }
}
