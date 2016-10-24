using System.Windows;
using IntervalFunctions.BL.Algorithms;
using IntervalFunctions.BL.Models;
using IntervalFunctions.App.ViewModels;
using System;
using System.Collections.ObjectModel;
using OxyPlot.Axes;
using OxyPlot;
using static IntervalFunctions.BL.Models.MathExtension;
using static System.Math;
using OxyPlot.Series;

namespace IntervalFunctions.App.Views
{
    public partial class IntervalFunctionView : Window
    {
        public IntervalFunctionView()
        {
            InitializeComponent();
        }

        private DichotomyMethod dm;
        private Func<double, double> f;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var vm = DataContext as IntervalFunctionsViewModel;


                double a = double.Parse(textBoxA.Text);
                double b = double.Parse(textBoxB.Text);
                double c = double.Parse(textBoxC.Text);

                vm.Interval = new Interval(double.Parse(textBoxL.Text), double.Parse(textBoxR.Text));


                f = x => (x - a) * (x - b) * (x - c);

                vm.PlotModel.Series.Clear();
                vm.PlotModel.Series.Add(
                    new FunctionSeries(
                        f,
                        vm.Interval.Start - 5,
                        vm.Interval.End + 5,
                        0.1,
                        $"f = (x - {a})(x - {b})(x - {c})")
                    );

                vm.PlotModel.InvalidatePlot(true);

                dm = new DichotomyMethod(vm.Interval, x => (x - a) * (x - b) * (x - c));

                vm.Solutions = new ObservableCollection<Interval>(dm.Solve());

                string str = "";
                if (dm.Count == 0)
                    str += "Коренів на вказаному проміжку немає. ";
                textBlockCount.Text = str + $"К-ість ітерацій {dm.Count}";
            }
            catch (Exception)
            { }
        }
    }
}
