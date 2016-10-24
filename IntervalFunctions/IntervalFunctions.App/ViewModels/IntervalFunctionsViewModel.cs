using IntervalFunctions.App.Models;
using IntervalFunctions.BL.Models;
using System.Collections.ObjectModel;

namespace IntervalFunctions.App.ViewModels
{
    public class IntervalFunctionsViewModel : ObservableObject
    {
        private ObservableCollection<MenuItem> _menuItems;
        private ObservableCollection<Interval> _solutions;
        private Interval _interval;

        public IntervalFunctionsViewModel()
        {
            MenuItems = new ObservableCollection<MenuItem>();
            Solutions = new ObservableCollection<Interval>();
        }

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        public Interval Interval
        {
            get { return _interval; }
            set { SetProperty(ref _interval, value); }
        }

        public ObservableCollection<Interval> Solutions
        {
            get { return _solutions; }
            set { SetProperty(ref _solutions, value); }
        }
    }
}
