using System;

namespace HockeyScoreboardCentral.Shared.Entity
{
    public interface IGameEvent
    {
        Guid GameId { get; set; }
        Guid EventId { get; set; }
        DateTime EventTime { get; set; }
        TimeSpan GameTime { get; set; }
        TimeSpan PeriodTime { get; set; }
        EGameEvent EvenType { get; }
        ETeam Team { get; set; }
        Int32 GamePeriod { get; set; }
    }
}
