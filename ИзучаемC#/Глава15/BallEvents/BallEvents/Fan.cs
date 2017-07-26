using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallEvents
{
    class Fan
    {
        public ObservableCollection<string> FanSays;

        public Fan(Ball ball)
        {
            ball.BallInPlay += ball_BallInPlay;
            FanSays = new ObservableCollection<string>();
        }

        private void ball_BallInPlay(object sender, EventArgs e)
        {
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if (ballEventArgs.Distance < 400 && ballEventArgs.Trajectory < 30)
                    Shout();
                else
                    CatchBall();
            }
        }

        public void Shout()
        {
            FanSays.Add("Where this fucking ball.");
        }

        public void CatchBall()
        {
            FanSays.Add("I am trying to catch fucking ball.");
        }
    }
}
