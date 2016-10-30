using System;

namespace HockeyScoreboardCentral.Shared.Entity
{
    public class Penalty
    {
        public Guid PenaltyId { get; private set; }
        public DateTime PenaltyEventTime { get; set; }
        public EPenaltyType Type { get; set; }
        public TimeSpan Duration { get; set; }
        public String PlayerNumber { get; set; }
        public String PlayerName { get; set; }

        public Penalty()
        {
            PenaltyId = Guid.NewGuid();
            PenaltyEventTime = DateTime.UtcNow;
            Type = EPenaltyType.Minor;
            PlayerNumber = "Unknown";
            PlayerName = "Unknown";
            Duration = TimeSpan.FromMinutes(2);
        }
    }
}
