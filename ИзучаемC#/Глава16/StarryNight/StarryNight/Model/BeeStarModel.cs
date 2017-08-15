using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace StarryNight.Model
{
    class BeeStarModel
    {
        public static readonly Size StarSize = new Size(150, 100);

        private readonly Dictionary<Bee, Point> _bees = new Dictionary<Bee, Point>();
        private readonly Dictionary<Star, Point> _stars = new Dictionary<Star, Point>();
        private Random _random = new Random();
        private Size _playAreaSize;

        public BeeStarModel()
        {
            _playAreaSize = Size.Empty;
        }

        public void Update()
        {
            MoveOneBee();
            AddOrRemoveAStar();
        }

        public static bool RectsOverlap(Rect r1, Rect r2)
        {
            r1.Intersect(r2);
            if (r1.Width > 0 || r1.Height > 0)
                return true;
            return false;
        }

        public Size PlayAreaSize
        {
            get
            {
                return _playAreaSize;
            }
            set
            {
                _playAreaSize = value;
                CreateAStar();
                CreateBees();
            }
        }

        private void CreateBees()
        {
            if (_playAreaSize == null)
                return;

            if (_bees.Count > 0)
            {
                foreach (KeyValuePair<Bee, Point> bee in _bees)
                    MoveOneBee(bee.Key);
            }
            else
            {
                int count = _random.Next(5, 16);

                for (int i = 0; i < count; i++)
                {
                    int s = _random.Next(40, 151);
                    Size beeSize = new Size(s, s);
                    Point beeLocation = FindNonOverlappingPoint(beeSize);
                    Bee newBee = new Bee(beeLocation, beeSize);
                    _bees[newBee] = new Point(beeLocation.X, beeLocation.Y);
                    OnBeeMoved(newBee, beeLocation.X, beeLocation.Y);
                }
            }
        }

        private void CreateAStar()
        {
            Point starLocation = FindNonOverlappingPoint(StarSize);
            Star star = new Star(starLocation);
            _stars[star] = new Point(starLocation.X, starLocation.Y);
            OnStarChanged(star, false);
        }

        private void CreateStars()
        {
            if (_stars == null)
                return;

            if (_stars.Count > 0)
            {
                foreach(Star star in _stars.Keys)
                {
                    star.Location = FindNonOverlappingPoint(StarSize);
                    OnStarChanged(star, false);
                }
            }
            else
            {
                int count = _random.Next(5, 11);

                for (int i = 0; i < count; i++)
                    CreateAStar();
            }
        }

        private Point FindNonOverlappingPoint(Size size)
        {
            Rect newRect;
            bool noOverloop = false;
            int count = 0;

            while(!noOverloop)
            {
                newRect = new Rect(_random.Next((int)(_playAreaSize.Width - 151)),
                    _random.Next((int)(_playAreaSize.Height - 150)),
                    size.Width, size.Height);

                var overlappingBees = from bee in _bees.Keys
                                      where RectsOverlap(bee.Position, newRect)
                                      select bee;

                var overlappingStars = from star in _stars.Keys
                                       where RectsOverlap(new Rect(star.Location.X, star.Location.Y, StarSize.Width, StarSize.Height), newRect)
                                       select star;

                if ((overlappingBees.Count() + overlappingStars.Count() == 0) || (count++ > 1000))
                    noOverloop = true;
            }

            return new Point(newRect.X, newRect.Y);
        }

        private void MoveOneBee(Bee bee = null)
        {
            if (_bees.Count == 0)
                return;

            if (bee == null)
                bee = _bees.Keys.ToList()[_random.Next(_bees.Count)];

            Point newLocation = FindNonOverlappingPoint(bee.Size);
            bee.Location = newLocation;
            _bees[bee] = newLocation;
            OnBeeMoved(bee, newLocation.X, newLocation.Y);
              
        }

        private void AddOrRemoveAStar()
        {
            if ((_random.Next(2) == 0 || _stars.Count <= 5) && (_stars.Count < 20))
                CreateAStar();
            else
            {
                Star starToRemove = _stars.Keys.ToList()[_random.Next(_stars.Count)];
                _stars.Remove(starToRemove);
                OnStarChanged(starToRemove, true);
            }
        }

        public event EventHandler<BeeMovedEventArgs> BeeMoved;

        private void OnBeeMoved(Bee beeThatMoved, double x, double y)
        {
            EventHandler<BeeMovedEventArgs> beeMoved = BeeMoved;
            if (beeMoved != null)
                BeeMoved(this, new BeeMovedEventArgs(beeThatMoved, x, y));
        }

        public event EventHandler<StarChangedEventArgs> StarChanged;

        private void OnStarChanged(Star starThatChanged, bool removed)
        {
            EventHandler<StarChangedEventArgs> starChanged = StarChanged;
            if (starChanged != null)
                starChanged(this, new StarChangedEventArgs(starThatChanged, removed));
        }
    }
}
