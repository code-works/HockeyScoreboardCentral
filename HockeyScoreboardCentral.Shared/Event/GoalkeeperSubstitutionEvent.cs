using System;
using HockeyScoreboardCentral.Shared.Entity;

namespace HockeyScoreboardCentral.Shared.Event
{
    public class GoalkeeperSubstitutionEvent : IGameEvent
    {
        public Guid GameId { get; set; }
        public Guid EventId { get; set; }
        public DateTime EventTime { get; set; }
        public TimeSpan GameTime { get; set; }
        public TimeSpan PeriodTime { get; set; }
        public EGameEvent EvenType { get; private set; }
        public Int32 GamePeriod { get; set; }
        public ETeam Team { get; set; }
        public String GoalkeeperOutNumber { get; set; }
        public String GoalkeeperOutName { get; set; }
        public String GoalkeeperInNumber { get; set; }
        public String GoalkeeperInName { get; set; }

        public GoalkeeperSubstitutionEvent()
        {
            EventId = Guid.NewGuid();
            EvenType = EGameEvent.GoalkeeperSubstitution;
        }
    }
}
