namespace HockeyScoreboardCentral.Shared.Entity
{
    public enum EGameEvent
    {
        Unknown = 0,
        PeriodStart = 1,
        PeriodEnd = 2,
        Goal = 3,
        PenaltyShot = 4,
        Penalty = 5,
        Timeout = 6,
        GoalkeeperSubstitution = 7
    }
}
