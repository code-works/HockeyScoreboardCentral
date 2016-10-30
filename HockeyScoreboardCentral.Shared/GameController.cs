using System;
using System.Threading;
using System.Timers;
using HockeyScoreboardCentral.Shared.Entity;
using System.Linq;

namespace HockeyScoreboardCentral.Shared
{
    public class GameController
    {
        private readonly ReaderWriterLockSlim AccessLock = new ReaderWriterLockSlim();
        private System.Timers.Timer ClockTimer { get; set; }
        private Game GameData { get; set; }
        private Boolean InProgress { get; set; }
        private Boolean IsGameLoaded { get; set; }

        public event EventHandler PeriodFinished;
        public event EventHandler NewGameEventHandler;
        public event EventHandler UpdateTimerEventHandler;
        public event EventHandler PenaltyInfoChangedHandler;

        public GameController()
        {
            ClockTimer = new System.Timers.Timer(100);
            ClockTimer.Elapsed += UpdateGameTime;
            ClockTimer.AutoReset = true;
            InProgress = false;
            IsGameLoaded = false;
        }

        private void UpdateGameTime(Object source, ElapsedEventArgs e)
        {
            if (IsGameLoaded == false)
            {
                return;    
            }

            var triggerPenaltyInfoChangedHandler = false;
            var triggerUpdateTimerEventHandler = false;

            AccessLock.EnterWriteLock();
            try
            {
                if (GameData.PeriodTime >= 100)
                {
                    GameData.TotalGameTime += 100;
                    GameData.PeriodTime -= 100;
                    triggerUpdateTimerEventHandler = true;
                    triggerPenaltyInfoChangedHandler = ProcessPenalties();
                }
            }
            finally
            {
                AccessLock.ExitWriteLock();
            }

            if (triggerUpdateTimerEventHandler)
            {
                UpdateTimerEventHandler?.Invoke(
                    GameData.PeriodTime,
                    EventArgs.Empty
                );
            }

            if (triggerPenaltyInfoChangedHandler)
            {
                PenaltyInfoChangedHandler?.Invoke(null, EventArgs.Empty);
            }

            if (GameData.PeriodTime == 0)
            {
                StopClock();
                PeriodFinished?.Invoke(null, EventArgs.Empty);
            }
        }

        private Boolean ProcessPenalties()
        {
            var home = PocessHomePenalties();
            var guest = PocessGuestPenalties();
            return (home || guest);
        }

        private Boolean PocessHomePenalties()
        {
            var penaltyInfoChanged = false;
            var penaltySubstractTime = TimeSpan.FromMilliseconds(100);

            if (GameData.FirstHomePenalty != null)
            {
                GameData.FirstHomePenalty.Duration -= penaltySubstractTime;
                penaltyInfoChanged = true;

                if (GameData.FirstHomePenalty.Duration == TimeSpan.Zero)
                {
                    GameData.FirstHomePenalty = null;
                }
            }

            if (GameData.SecondHomePenalty != null)
            {
                GameData.SecondHomePenalty.Duration -= penaltySubstractTime;
                penaltyInfoChanged = true;

                if (GameData.SecondHomePenalty.Duration == TimeSpan.Zero)
                {
                    GameData.SecondHomePenalty = null;
                }
                else if (GameData.FirstHomePenalty == null)
                {
                    GameData.FirstHomePenalty = GameData.SecondHomePenalty;
                    GameData.SecondHomePenalty = null;
                }
            }

            if ((GameData.FirstHomePenalty == null ||
                 GameData.SecondHomePenalty == null) &&
                 GameData.PenaltyQueueHome.Count > 0)
            {
                var penaltyItem = GameData.PenaltyQueueHome.Values.OrderBy(d =>
                    d.PenaltyEventTime
                ).First();

                GameData.PenaltyQueueHome.Remove(penaltyItem.PenaltyId);

                if (GameData.FirstHomePenalty == null)
                {
                    GameData.FirstHomePenalty = penaltyItem;
                }
                else
                {
                    GameData.SecondHomePenalty = penaltyItem;
                }

                penaltyInfoChanged = true;
            }

            return penaltyInfoChanged;
        }

        private Boolean PocessGuestPenalties()
        {
            var penaltyInfoChanged = false;
            var penaltySubstractTime = TimeSpan.FromMilliseconds(100);

            if (GameData.FirstGuestPenalty != null)
            {
                GameData.FirstGuestPenalty.Duration -= penaltySubstractTime;
                penaltyInfoChanged = true;

                if (GameData.FirstGuestPenalty.Duration == TimeSpan.Zero)
                {
                    GameData.FirstGuestPenalty = null;
                }
            }

            if (GameData.SecondGuestPenalty != null)
            {
                GameData.SecondGuestPenalty.Duration -= penaltySubstractTime;
                penaltyInfoChanged = true;

                if (GameData.SecondGuestPenalty.Duration == TimeSpan.Zero)
                {
                    GameData.SecondHomePenalty = null;
                }
                else if (GameData.FirstGuestPenalty == null)
                {
                    GameData.FirstGuestPenalty = GameData.SecondGuestPenalty;
                    GameData.SecondGuestPenalty = null;
                }
            }

            if ((GameData.FirstGuestPenalty == null ||
                 GameData.SecondGuestPenalty == null) &&
                 GameData.PenaltyQueueHome.Count > 0)
            {
                var penaltyItem = GameData.PenaltyQueueGuest.Values.OrderBy(d =>
                    d.PenaltyEventTime
                ).First();

                GameData.PenaltyQueueGuest.Remove(penaltyItem.PenaltyId);

                if (GameData.FirstGuestPenalty == null)
                {
                    GameData.FirstGuestPenalty = penaltyItem;
                }
                else
                {
                    GameData.SecondGuestPenalty = penaltyItem;
                }

                penaltyInfoChanged = true;
            }

            return penaltyInfoChanged;
        }

        public void LoadGame(Game gameData)
        {
            AccessLock.EnterWriteLock();
            try
            {
                GameData = gameData;
                IsGameLoaded = true;
            }
            finally
            {
                AccessLock.ExitWriteLock();
            }
            
        }

        public void StartClock()
        {
            if (IsGameLoaded)
            {
                ClockTimer.Start();
            }
        }

        public void StopClock()
        {
            if (IsGameLoaded)
            {
                ClockTimer.Stop();
            }
        }

        public Int64 GetTotalGameTime()
        {
            AccessLock.EnterReadLock();
            try
            {
                return GameData.TotalGameTime;
            }
            finally
            {
                AccessLock.ExitReadLock();
            }
        }

        public Int64 GetPeriodTime()
        {
            AccessLock.EnterReadLock();
            try
            {
                return GameData.TotalGameTime;
            }
            finally
            {
                AccessLock.ExitReadLock();
            }
        }

        public Penalty GetFirstPenaltyHome()
        {
            AccessLock.EnterReadLock();
            try
            {
                return GameData.FirstHomePenalty;
            }
            finally
            {
                AccessLock.ExitReadLock();
            }
        }

        public Penalty GetSecondPenaltyHome()
        {
            AccessLock.EnterReadLock();
            try
            {
                return GameData.SecondHomePenalty;
            }
            finally
            {
                AccessLock.ExitReadLock();
            }
        }

        public Penalty GetFirstPenaltyGuest()
        {
            AccessLock.EnterReadLock();
            try
            {
                return GameData.FirstGuestPenalty;
            }
            finally
            {
                AccessLock.ExitReadLock();
            }
        }

        public Penalty GetSecondPenaltyGuest()
        {
            AccessLock.EnterReadLock();
            try
            {
                return GameData.SecondGuestPenalty;
            }
            finally
            {
                AccessLock.ExitReadLock();
            }
        }

        public void AddGameEvent(IGameEvent gameEvent)
        {
            AccessLock.EnterWriteLock();
            try
            {
                GameData.Events.Add(gameEvent.EventId, gameEvent);
            }
            finally
            {
                AccessLock.ExitWriteLock();
            }
            NewGameEventHandler?.Invoke(gameEvent, EventArgs.Empty);
        }
    }
}
