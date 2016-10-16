using IntervalFunctions.App.Models;
using IntervalFunctions.BL.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace IntervalFunctions.App.ViewModels
{
    public class IntervalFunctionsViewModel : ObservableObject
    {
        private ObservableCollection<MenuItem> _menuItems;
        private Interval _intervalA;
        private Interval _intervalB;
        private string teststring;

        public IntervalFunctionsViewModel()
        {
            MenuItems = new ObservableCollection<MenuItem>();
            Teststring = "";

            IntervalA = new Interval();
            IntervalB = new Interval(double.NegativeInfinity, double.PositiveInfinity);
            Teststring += $"{IntervalA} i {IntervalB} = {Interval.Intersection(IntervalA, IntervalB)}\n";

            IntervalA = new Interval(double.PositiveInfinity, 3);
            IntervalB = new Interval(-2, 8);
            Teststring += $"{IntervalA} i {IntervalB} = {Interval.Intersection(IntervalA, IntervalB)}\n";
            IntervalA = new Interval(double.NegativeInfinity);
            IntervalB = new Interval(-6, 3);

            Teststring += $"{IntervalA} i {IntervalB} = {Interval.Intersection(IntervalA, IntervalB)}\n";
            IntervalA = new Interval(double.PositiveInfinity, 3);
            IntervalB = new Interval(-2, 8, false, false);
            Teststring += $"{IntervalA} i {IntervalB} = {Interval.Intersection(IntervalA, IntervalB)}\n";

            IntervalA = new Interval(double.NegativeInfinity);
            IntervalB = new Interval(-6, 3, false, false);
            Teststring += $"{IntervalA} i {IntervalB} = {Interval.Intersection(IntervalA, IntervalB)}\n";


            Teststring += $"{(Interval)5}\n";
            Teststring += $"{(Interval)double.PositiveInfinity}\n";
            Teststring += $"{(Interval)double.NegativeInfinity}\n";
            Teststring += $"{(Interval)0}\n";
        }

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        public Interval IntervalA
        {
            get { return _intervalA; }
            set { SetProperty(ref _intervalA, value); }
        }

        public Interval IntervalB
        {
            get { return _intervalB; }
            set { SetProperty(ref _intervalB, value); }
        }

        public string Teststring
        {
            get { return teststring; }
            set { SetProperty(ref teststring, value); }
        }
    }
}
