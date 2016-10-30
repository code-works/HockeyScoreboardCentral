using System;
using HockeyScoreboardCentral.Shared.Entity;

namespace HockeyScoreboardCentral.Shared.Event
{
    public class TimeoutEvent : IGameEvent
    {
        public Guid GameId { get; set; }
        public Guid EventId { get; set; }
        public DateTime EventTime { get; set; }
        public TimeSpan GameTime { get; set; }
        public TimeSpan PeriodTime { get; set; }
        public EGameEvent EvenType { get; private set; }
        public ETeam Team { get; set; }
        public Int32 GamePeriod { get; set; }
        public TimeoutEvent()
        {
            EventId = Guid.NewGuid();
            EvenType = EGameEvent.Timeout;
        }
    }
}
