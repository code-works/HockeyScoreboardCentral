using System;
using System.Windows;
using System.Windows.Input;
using HockeyScoreboardCentral.Shared;
using HockeyScoreboardCentral.Shared.Entity;
using HockeyScoreboardCentral.ViewModel;

namespace HockeyScoreboardCentral
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GameController Controller = new GameController();
        private readonly ScoreboardViewModel ViewModel = new ScoreboardViewModel();
        private readonly RoutedCommand CmdStartStopClock = new RoutedCommand();

        public MainWindow()
        {
            InitializeGameController();
            InitializeComponent();
            SetShortCuts();
            base.DataContext = ViewModel;
        }

        private void SetShortCuts()
        {
            CmdStartStopClock.InputGestures.Add(
                new KeyGesture(Key.NumPad0)
            );
            CommandBindings.Add(new CommandBinding(
                CmdStartStopClock, 
                btnStartStopClock_Click
            ));
        }

        private void InitializeGameController()
        {
            var testGame = new Game()
            {
                Home = new Team()
                {
                    Name = "Aachener EC"
                },
                Guest = new Team()
                {
                    Name = "Random Team"
                },
                FirstHomePenalty = new Penalty()
                {
                    PlayerName = "Arme Sau",
                    PlayerNumber = "44",
                    Duration = TimeSpan.FromSeconds(5)
                },
                SecondHomePenalty = new Penalty()
                {
                    PlayerName = "Arme Sau 2",
                    PlayerNumber = "46",
                },
                FirstGuestPenalty = new Penalty()
                {
                    PlayerName = "Idiot",
                    PlayerNumber = "99",
                    Duration = TimeSpan.FromSeconds(73)
                },
                SecondGuestPenalty = new Penalty()
                {
                    PlayerName = "Idiot 2",
                    PlayerNumber = "72"
                }
            };

            var queuedHomePenalty = new Penalty()
            {
                PlayerName = "Arme Sau 3",
                PlayerNumber = "64"
            };

            testGame.PenaltyQueueHome.Add(
                queuedHomePenalty.PenaltyId, 
                queuedHomePenalty
            );

            Controller.LoadGame(testGame);
            UpdatePenaltyInfo();

            Controller.UpdateTimerEventHandler += (o, e) =>
            {
                var newClockTime = TimeSpan.FromMilliseconds((Int64)o);
                ViewModel.GameTime = newClockTime.ToString(@"mm\:ss\.f");
            };

            Controller.PenaltyInfoChangedHandler += (o, e) =>
            {
                UpdatePenaltyInfo();
            };
        }

        private void UpdatePenaltyInfo()
        {
            var firstPenaltyHome = Controller.GetFirstPenaltyHome();
            if (firstPenaltyHome != null)
            {
                ViewModel.SetFirstHomePenalty(firstPenaltyHome);
            }
            else
            {
                ViewModel.ClearFirstHomePenalty();
            }

            var secondPenaltyHome= Controller.GetSecondPenaltyHome();
            if (secondPenaltyHome != null)
            {
                ViewModel.SetSecondHomePenalty(secondPenaltyHome);
            }
            else
            {
                ViewModel.ClearSecondHomePenalty();
            }

            var firstePenaltyGuest = Controller.GetFirstPenaltyGuest();
            if (firstePenaltyGuest != null)
            {
                ViewModel.SetFirstGuestPenalty(firstePenaltyGuest);
            }
            else
            {
                ViewModel.ClearFirstGuestPenalty();
            }

            var secondPenaltyGuest = Controller.GetSecondPenaltyGuest();
            if (secondPenaltyGuest != null)
            {
                ViewModel.SetSecondGuestPenalty(secondPenaltyGuest);
            }
            else
            {
                ViewModel.ClearSecondGuestPenalty();
            }
        }

        private void btnStartStopClock_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.InProgress == false)
            {
                Controller.StartClock();
                ViewModel.InProgress = true;
                btnStartStopClock.Content = "Stop Clock";
            }
            else
            {
                Controller.StopClock();
                ViewModel.InProgress = false;
                btnStartStopClock.Content = "Start Clock";
            }
        }

        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            var eventWindow = new NewEventWindow();
            var result = eventWindow.ShowDialog();
            eventWindow.Close();
        }
    }
}
