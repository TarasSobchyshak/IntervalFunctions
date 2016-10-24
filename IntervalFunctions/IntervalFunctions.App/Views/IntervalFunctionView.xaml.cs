using System.Windows;
using IntervalFunctions.BL.Algorithms;
using IntervalFunctions.BL.Models;
using IntervalFunctions.App.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace IntervalFunctions.App.Views
{
    public partial class IntervalFunctionView : Window
    {
        public IntervalFunctionView()
        {
            InitializeComponent();
        }

        private DichotomyMethod dm;
        private Func<Interval, Interval> f;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as IntervalFunctionsViewModel;
            double a = 1;
            double b = 3;
            double c = -5;

            vm.Interval = new Interval(double.Parse(textBoxA.Text), double.Parse(textBoxB.Text));

            dm = new DichotomyMethod(vm.Interval, x => (x - a) * (x - b) * (x - c));

            vm.Solutions = new ObservableCollection<Interval>(dm.Solve());

            textBlockCount.Text = $"Number of iterations {dm.Count}";
        }
    }
}
