using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallEvents
{
    delegate void BatCallback(BallEventArgs e);

    class Bat
    {
        private BatCallback hitBallCallback;
        public Bat(BatCallback callbackDelegate)
        {
            this.hitBallCallback = new BatCallback(callbackDelegate);
        }

        public void HitTheBall(BallEventArgs e)
        {
            if (hitBallCallback != null)
                hitBallCallback(e);
        }
    }
}
