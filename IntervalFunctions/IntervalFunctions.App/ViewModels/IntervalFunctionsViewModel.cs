using IntervalFunctions.App.Models;
using IntervalFunctions.BL.Models;
using OxyPlot;
using OxyPlot.Axes;
using System.Collections.ObjectModel;

namespace IntervalFunctions.App.ViewModels
{
    public class IntervalFunctionsViewModel : ObservableObject
    {
        private ObservableCollection<MenuItem> _menuItems;
        private ObservableCollection<Interval> _solutions;
        private Interval _interval;
        private PlotModel _plotModel;

        public IntervalFunctionsViewModel()
        {
            MenuItems = new ObservableCollection<MenuItem>();
            Solutions = new ObservableCollection<Interval>();

            PlotModel = new PlotModel();
            PlotModel.Axes.Clear();
            PlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                MinorGridlineStyle = LineStyle.Dot,
                MajorGridlineStyle = LineStyle.Solid
            });

            PlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                MinorGridlineStyle = LineStyle.Dot,
                MajorGridlineStyle = LineStyle.Solid
            });
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

        public PlotModel PlotModel
        {
            get { return _plotModel; }
            set { SetProperty(ref _plotModel, value); }
        }
    }
}
