using IntervalFunctions.BL.Models;
using System;
using System.Collections.Generic;

namespace IntervalFunctions.BL.Algorithms
{
    public class KravchykMethod
    {
        public Func<Interval, Interval> F { get; private set; }
        public Interval X { get; private set; }
        public List<Interval> Solutions { get; private set; }

        private double eps = 0.1;
        public int Count { get; private set; }

        public KravchykMethod(Interval x, Func<Interval, Interval> f)
        {
            F = f;
            X = x;
            Solutions = new List<Interval>();
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
            ++k;

            if (!F(a).Contains(0.0)) return;

            var temp = new Interval(a.Middle, a.Middle);
            if (F(temp).Contains(0.0))
            {
                Solutions.Add(temp);
                Dychotomy(new Interval(a.Start, a.Middle - eps), ref k);
                Dychotomy(new Interval(a.Middle + eps, a.End), ref k);
            }
            else
            {
                if (a.Width <= eps) Solutions.Add(a);
                else
                {
                    Dychotomy(new Interval(a.Start, a.Middle), ref k);
                    Dychotomy(new Interval(a.Middle, a.End), ref k);
                }
            }
        }
    }
}
