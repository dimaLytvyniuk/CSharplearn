using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallEvents
{
    class Pitcher
    {
        public ObservableCollection<string> PitcherSays;

        public Pitcher(Ball ball)
        {
            ball.BallInPlay += ball_BallInPlay;
            PitcherSays = new ObservableCollection<string>();
        }

        private void ball_BallInPlay(object sender, EventArgs e)
        {
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance < 95) && (ballEventArgs.Trajectory < 60))
                    CatchBall();
                else
                    CoverFirstBase();
            }
        }

        public void CatchBall()
        {
            PitcherSays.Add("Pitcher caught the ball.");
        }

        public void CoverFirstBase()
        {
            PitcherSays.Add("Pitcher covered first base.");
        }
    }
}
