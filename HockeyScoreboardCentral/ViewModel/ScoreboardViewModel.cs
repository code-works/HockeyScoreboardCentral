using System;
using HockeyScoreboardCentral.Shared.Entity;

namespace HockeyScoreboardCentral.ViewModel
{
    public class ScoreboardViewModel : ViewModelBase
    {
        public Boolean InProgress { get; set; }

        #region Game Time
        private String _gameTime;
        public String GameTime
        {
            get { return _gameTime; }
            set
            {
                _gameTime = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Goals Home
        private Int32 _goalsHomeTeam;
        public Int32 GoalsHomeTeam
        {
            get { return _goalsHomeTeam; }
            set
            {
                _goalsHomeTeam = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Goals Guest
        private Int32 _goalsGuestTeam;
        public Int32 GoalsGuestTeam
        {
            get { return _goalsGuestTeam; }
            set
            {
                _goalsGuestTeam = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Period
        private Int32 _period;
        public Int32 Period
        {
            get { return _period; }
            set
            {
                _period = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region First Penalty Home
        private String _firstHomePenaltyPlayerNumber;
        public String FirstHomePenaltyPlayerNumber
        {
            get { return _firstHomePenaltyPlayerNumber; }
            set
            {
                _firstHomePenaltyPlayerNumber = value;
                OnPropertyChanged();
            }
        }

        private String _firstHomePenaltyTimeRemaining;
        public String FirstHomePenaltyTimeRemaining
        {
            get { return _firstHomePenaltyTimeRemaining; }
            set
            {
                _firstHomePenaltyTimeRemaining = value;
                OnPropertyChanged();
            }
        }

        public void SetFirstHomePenalty(Penalty penaltyData)
        {
            FirstHomePenaltyPlayerNumber = penaltyData.PlayerNumber;
            FirstHomePenaltyTimeRemaining = penaltyData.Duration.ToString(@"mm\:ss\.f");
        }

        public void ClearFirstHomePenalty()
        {
            FirstHomePenaltyPlayerNumber = String.Empty;
            FirstHomePenaltyTimeRemaining = String.Empty;
        }
        #endregion

        #region Second Penalty Home
        private String _secondHomePenaltyPlayerNumber;
        public String SecondHomePenaltyPlayerNumber
        {
            get { return _secondHomePenaltyPlayerNumber; }
            set
            {
                _secondHomePenaltyPlayerNumber = value;
                OnPropertyChanged();
            }
        }

        private String _secondHomePenaltyTimeRemaining;
        public String SecondHomePenaltyTimeRemaining
        {
            get { return _secondHomePenaltyTimeRemaining; }
            set
            {
                _secondHomePenaltyTimeRemaining = value;
                OnPropertyChanged();
            }
        }

        public void SetSecondHomePenalty(Penalty penaltyData)
        {
            SecondHomePenaltyPlayerNumber = penaltyData.PlayerNumber;
            SecondHomePenaltyTimeRemaining = penaltyData.Duration.ToString(@"mm\:ss\.f");
        }

        public void ClearSecondHomePenalty()
        {
            SecondHomePenaltyPlayerNumber = String.Empty;
            SecondHomePenaltyTimeRemaining = String.Empty;
        }
        #endregion

        #region First Guest Penalty
        private String _firstGuestPenaltyPlayerNumber;
        public String FirstGuestPenaltyPlayerNumber
        {
            get { return _firstGuestPenaltyPlayerNumber; }
            set
            {
                _firstGuestPenaltyPlayerNumber = value;
                OnPropertyChanged();
            }
        }

        private String _firstGuestPenaltyTimeRemaining;
        public String FirstGuestPenaltyTimeRemaining
        {
            get { return _firstGuestPenaltyTimeRemaining; }
            set
            {
                _firstGuestPenaltyTimeRemaining = value;
                OnPropertyChanged();
            }
        }

        public void SetFirstGuestPenalty(Penalty penaltyData)
        {
            FirstGuestPenaltyPlayerNumber = penaltyData.PlayerNumber;
            FirstGuestPenaltyTimeRemaining = penaltyData.Duration.ToString(@"mm\:ss\.f");
        }

        public void ClearFirstGuestPenalty()
        {
            FirstGuestPenaltyPlayerNumber = String.Empty;
            FirstGuestPenaltyTimeRemaining = String.Empty;
        }

        #endregion

        #region Second Guest Penalty
        private String _secondGuestPenaltyPlayerNumber;
        public String SecondGuestPenaltyPlayerNumber
        {
            get { return _secondGuestPenaltyPlayerNumber; }
            set
            {
                _secondGuestPenaltyPlayerNumber = value;
                OnPropertyChanged();
            }
        }

        private String _secondGuestPenaltyTimeRemaining;
        public String SecondGuestPenaltyTimeRemaining
        {
            get { return _secondGuestPenaltyTimeRemaining; }
            set
            {
                _secondGuestPenaltyTimeRemaining = value;
                OnPropertyChanged();
            }
        }

        public void SetSecondGuestPenalty(Penalty penaltyData)
        {
            SecondGuestPenaltyPlayerNumber = penaltyData.PlayerNumber;
            SecondGuestPenaltyTimeRemaining = penaltyData.Duration.ToString(@"mm\:ss\.f");

        }

        public void ClearSecondGuestPenalty()
        {
            SecondGuestPenaltyPlayerNumber = String.Empty;
            SecondGuestPenaltyTimeRemaining = String.Empty;
        }
        #endregion

        public ScoreboardViewModel()
        {
            Period = 1;
            GoalsGuestTeam = 0;
            GoalsHomeTeam = 0;
            GameTime = "20:00.0";
            InProgress = false;
            FirstHomePenaltyPlayerNumber = String.Empty;
            FirstHomePenaltyTimeRemaining = String.Empty;
            SecondHomePenaltyPlayerNumber = String.Empty;
            SecondHomePenaltyTimeRemaining = String.Empty;
            FirstGuestPenaltyPlayerNumber = String.Empty;
            FirstGuestPenaltyTimeRemaining = String.Empty;
            SecondGuestPenaltyPlayerNumber = String.Empty;
            SecondGuestPenaltyTimeRemaining = String.Empty;
        }
    }
}
