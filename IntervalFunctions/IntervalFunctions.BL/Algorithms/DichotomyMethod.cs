using IntervalFunctions.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalFunctions.BL.Algorithms
{
    public class DichotomyMethod
    {
        public Func<Interval, Interval> F { get; private set; }
        public Interval X { get; private set; }
        public List<Interval> Solutions { get; private set; }

        private double eps = 1e-6;
        public int Count { get; private set; }

        public DichotomyMethod(Interval x, Func<Interval, Interval> f)
        {
            F = f;
            X = x;
        }

        public List<Interval> Solve()
        {
            Solutions.Clear();
            int k = 0;

            Dychotomy(X, ref k);

            Count = k;

            return Solutions;
        }
        private void Dychotomy(Interval a, ref int k)
        {
            if (!F(a).Contains(0.0)) return;

            ++k;

            if (a.Width <= eps) Solutions.Add(a);
            else
            {
                Dychotomy(new Interval(a.Start, a.Middle), ref k);
                Dychotomy(new Interval(a.Middle, a.End), ref k);
            }
        }
    }
}
