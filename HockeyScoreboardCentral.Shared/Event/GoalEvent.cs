using System;
using HockeyScoreboardCentral.Shared.Entity;

namespace HockeyScoreboardCentral.Shared.Event
{
    public class GoalEvent : IGameEvent
    {
        public Guid GameId { get; set; }
        public Guid EventId { get; set; }
        public DateTime EventTime { get; set; }
        public TimeSpan GameTime { get; set; }
        public TimeSpan PeriodTime { get; set; }
        public EGameEvent EvenType { get; set; }
        public ETeam Team { get; set; }
        public Int32 GamePeriod { get; set; }
        public EGoalType GoalType { get; set; }
        public String GoalScorerNumber { get; set; }
        public String GoalScorerName { get; set; }
        public String PrimaryAssistNumber { get; set; }
        public String PrimaryAssistName { get; set; }
        public String SecondaryAssistNumber { get; set; }
        public String SecondaryAssistName { get; set; }

        public GoalEvent()
        {
            EventId = Guid.NewGuid();
            EvenType = EGameEvent.Goal;
            GoalType = EGoalType.Regular;
        }
    }
}
