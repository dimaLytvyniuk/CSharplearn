using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using StarryNight.Model;
using StarryNight.View;
using DispatcherTime = Windows.UI.Xaml.DispatcherTimer;
using UIElement = Windows.UI.Xaml.UIElement;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace StarryNight.ViewModel
{
    class BeeStarViewModel
    {
        private readonly ObservableCollection<UIElement> _sprites = new ObservableCollection<UIElement>();
        public INotifyCollectionChanged Sprites { get { return _sprites; } }

        private readonly Dictionary<Star, StarControl> _stars = new Dictionary<Star, StarControl>();
        private readonly List<StarControl> _fadedStars = new List<StarControl>();

        private BeeStarModel _model = new BeeStarModel();
        private readonly Dictionary<Bee, AnimatedImage> _bees = new Dictionary<Bee, AnimatedImage>();
        private DispatcherTime _timer = new DispatcherTime();

        public Size PlayAreaSize
        {
            get
            {
                return _model.PlayAreaSize;
            }

            set
            {
                _model.PlayAreaSize = value;
            }
        }

        public BeeStarViewModel()
        {
            _model.BeeMoved += BeeMovedHandler;
            _model.StarChanged += StarChangedHandler;

            _timer.Interval = TimeSpan.FromMilliseconds(200);
            _timer.Tick += timer_Tick;
            _timer.Start();
        }

        private void timer_Tick(object sender, object e)
        {
            foreach (StarControl starControl in _fadedStars)
                _sprites.Remove(starControl);
            
            _model.Update();
        }

        private void BeeMovedHandler(object sender, BeeMovedEventArgs e)
        {
            if (!_bees.ContainsKey(e.BeeThatMoved))
            {
                AnimatedImage beeControl = BeeStarHelper.BeeFactory(e.BeeThatMoved.Width, e.BeeThatMoved.Height);
                BeeStarHelper.SetCanvasLocation(beeControl, e.X, e.Y);
                _bees[e.BeeThatMoved] = beeControl;
                _sprites.Add(beeControl);
            }
            else
            {
                AnimatedImage beeControl = _bees[e.BeeThatMoved];
                BeeStarHelper.MoveElementOnCanvas(beeControl, e.X, e.Y);
            }
        }

        private void StarChangedHandler(object sender, StarChangedEventArgs e)
        {
            if (e.Removed)
            {
                StarControl starControl = _stars[e.StarThatChanged];
                _stars.Remove(e.StarThatChanged);
                _fadedStars.Add(starControl);
                starControl.FadeOut();
            }
            else
            {
                StarControl newStar;

                if (_stars.ContainsKey(e.StarThatChanged))
                    newStar = _stars[e.StarThatChanged];
                else
                {
                    newStar = new StarControl();
                    _stars[e.StarThatChanged] = newStar;
                    newStar.FadeIn();
                    BeeStarHelper.SendToBack(newStar);
                    _sprites.Add(newStar);
                }

                BeeStarHelper.SetCanvasLocation(newStar, e.StarThatChanged.Location.X, e.StarThatChanged.Location.Y);
            }
        }
    }
}
