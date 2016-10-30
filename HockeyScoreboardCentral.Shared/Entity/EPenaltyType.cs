using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyScoreboardCentral.Shared.Entity
{
    public enum EPenaltyType
    {
        /// <summary>
        /// Used if no matching penalty is found (custom)
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// 2 minutes (penalty box)
        /// </summary>
        Minor = 1,
        /// <summary>
        /// 5 minutes, will not end if goal scored unless the goal is scored 
        /// during an overtime period
        /// </summary>
        Major = 2,
        /// <summary>
        /// 10 minutes, normally used as a 2+10.
        /// </summary>
        Misconduct = 3,
        /// <summary>
        /// 
        /// </summary>
        GameMisconduct = 4,
        /// <summary>
        /// A player who receives a match penalty is ejected.
        /// A match penalty is imposed for deliberately injuring another player 
        /// as well as attempting to injure another player.
        /// A substitute player will serve a 5 min penalty in the box
        /// </summary>
        MatchPenalty = 5,
        GrossMisconductPenalty = 6
    }
}
