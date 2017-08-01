using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallEvents
{
    class BAseballSimulator
    {
        private Ball ball = new Ball();
        private Pitcher pitcher;
        private Fan fan;

        public ObservableCollection<string> FanSays { get { return fan.FanSays; } }
        public ObservableCollection<string> PitcherSays { get { return pitcher.PitcherSays; } }

        public int Trajectory { get; set; }
        public int Distance { get; set; }

        public BAseballSimulator()
        {
            pitcher = new Pitcher(ball);
            fan = new Fan(ball);
            Trajectory = 30;
            Distance = 120;
        }

        public void PlayBall()
        {
            Bat bat = ball.GetNewBat();
            BallEventArgs ballEventArgs = new BallEventArgs(Trajectory, Distance);
            bat.HitTheBall(ballEventArgs);
        }
    }
}
