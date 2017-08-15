using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimatedProg.View;

namespace AnimatedProg.ViewModel
{
    class BeeViewModel
    {
        private readonly ObservableCollection<Windows.UI.Xaml.UIElement> _sprites = new ObservableCollection<Windows.UI.Xaml.UIElement>();
        public INotifyCollectionChanged Sprites { get { return _sprites; } }
        
        public BeeViewModel()
        {
            AnimatedImage firstBat = BeeHelper.BeeFactory(50, 50, TimeSpan.FromMilliseconds(50));
            _sprites.Add(firstBat);

            AnimatedImage secondBat = BeeHelper.BeeFactory(200, 200, TimeSpan.FromMilliseconds(10));
            _sprites.Add(secondBat);

            AnimatedImage thirdBat = BeeHelper.BeeFactory(300, 125, TimeSpan.FromMilliseconds(100));
            _sprites.Add(thirdBat);

            BeeHelper.MakeBeeMove(firstBat, 50, 450, 40);
            BeeHelper.SetBeeLovcation(secondBat, 80, 260);
            BeeHelper.SetBeeLovcation(thirdBat, 230, 100);
        }
    }
}
