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
using System.Windows.Controls;
using MathNet.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace IntervalFunctions.App.Views
{
    public partial class IntervalFunctionView : System.Windows.Window
    {
        public IntervalFunctionView()
        {
            InitializeComponent();
        }

        private DichotomyMethod dm;
        private MooreMethod mm;
        private HansenMethod hm;
        private Func<double, double> f;
        private Func<double, double> f2 = x => SpecialFunctions.Gamma(Sqrt(x * x + 1)) - 2 * x * x;
        private Func<Interval, Interval> dFdx;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dychotomy();
        }


        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var x = (sender as ComboBox);

            switch (x.SelectedIndex)
            {
                case 0:
                    MooreMethod();
                    break;
                case 1:
                    HansenMethod();
                    break;
                case 2:
                    KravchykMethod();
                    break;
                default:
                    break;
            }
        }

        private void Dychotomy()
        {
            try
            {
                var vm = DataContext as IntervalFunctionsViewModel;
                vm.Solutions.Clear();


                double a = double.Parse(textBoxA.Text);
                double b = double.Parse(textBoxB.Text);
                double c = double.Parse(textBoxC.Text);

                vm.Interval = new Interval(double.Parse(textBoxL.Text), double.Parse(textBoxR.Text));


                f = x => (x - a) * (x - b) * (x - c);

                vm.PlotModel.Series.Clear();
                vm.PlotModel.Series.Add(
                    new FunctionSeries(
                        f,
                        vm.Interval.Start,
                        vm.Interval.End,
                        0.1,
                        $"f = (x - {a})(x - {b})(x - {c})")
                    );

                vm.PlotModel.InvalidatePlot(true);

                dm = new DichotomyMethod(vm.Interval, x => (x - a) * (x - b) * (x - c));

                vm.Solutions = new ObservableCollection<Interval>(dm.Solve());

                string str = "";
                if (dm.Count <= 1 && vm.Solutions.Count == 0)
                    str += "Коренів на вказаному проміжку немає. ";
                textBlockCount.Text = str + $"К-ість ітерацій {dm.Count}";
            }
            catch (Exception)
            { }
        }


        public Interval DGammaInterval(Interval A)
        {
            List<double> FuncDerivateResult = new List<double>();
            double h = (A.Middle) / 100;

            for (double i = A.Start; i <= A.End; i += h)
            {
                FuncDerivateResult.Add(DGamma(i));
            }
            return new Interval(FuncDerivateResult.Min(), FuncDerivateResult.Max());
        }

        private double DGamma(double x)
        {
            return SpecialFunctions.DiGamma(Sqrt(x * x + 1))
                * SpecialFunctions.Gamma(Sqrt(x * x + 1))
                * ((2 * x) / Sqrt(x * x + 1) / 2.0)
                - 4 * x;
        }


        private void MooreMethod()
        {
            try
            {
                var vm = DataContext as IntervalFunctionsViewModel;
                vm.Solutions.Clear();

                vm.Interval = new Interval(double.Parse(textBoxL.Text), double.Parse(textBoxR.Text));

                f = x => SpecialFunctions.Gamma(Sqrt(x * x + 1)) - 2 * x * x;

                dFdx = x => DGammaInterval(x);

                mm = new MooreMethod(vm.Interval, f, dFdx);

                vm.Solutions = new ObservableCollection<Interval>(mm.Solve());

                vm.PlotModel.Series.Clear();
                vm.PlotModel.Series.Add(
                    new FunctionSeries(
                        f,
                        vm.Interval.Start,
                        vm.Interval.End,
                        0.1,
                        $"f = (x")
                    );

                vm.PlotModel.InvalidatePlot(true);

                string str = "";
                if (dm.Count <= 1 && vm.Solutions.Count == 0)
                    str += "Коренів на вказаному проміжку немає. ";
                textBlockCount.Text = str + $"К-ість ітерацій {mm.Count}";
            }
            catch (Exception) { }
        }


        private void HansenMethod()
        {
            try
            {
                var vm = DataContext as IntervalFunctionsViewModel;
                vm.Solutions.Clear();

                vm.Interval = new Interval(double.Parse(textBoxL.Text), double.Parse(textBoxR.Text));

                f = x => SpecialFunctions.Gamma(Sqrt(x * x + 1)) - 2 * x * x;

                dFdx = x => DGammaInterval(x);

                hm = new HansenMethod(vm.Interval, f, dFdx);

                vm.Solutions = new ObservableCollection<Interval>(hm.Solve());

                vm.PlotModel.Series.Clear();
                vm.PlotModel.Series.Add(
                    new FunctionSeries(
                        f,
                        vm.Interval.Start,
                        vm.Interval.End,
                        0.1,
                        $"f = (x")
                    );

                vm.PlotModel.InvalidatePlot(true);


                string str = "";
                if (dm.Count <= 1 && vm.Solutions.Count == 0)
                    str += "Коренів на вказаному проміжку немає. ";
                textBlockCount.Text = str + $"К-ість ітерацій {hm.Count}";
            }
            catch (Exception ex) { }
        }

        private void KravchykMethod()
        {
        }
    }
}
