using IntervalFunctions.BL.Models;
using System;
using System.Collections.Generic;

namespace IntervalFunctions.BL.Algorithms
{
    public class HansenMethod
    {
        public Func<double, double> F { get; private set; }
        public Func<Interval, Interval> dFdx { get; private set; }

        public Interval X { get; private set; }
        public List<Interval> Solutions { get; private set; }

        private double eps = 0.000001;
        public int Count { get; private set; }

        public HansenMethod(Interval x, Func<double, double> f, Func<Interval, Interval> dFdx)
        {
            F = f;
            X = x;
            this.dFdx = dFdx;
            Solutions = new List<Interval>();
        }

        public List<Interval> Solve()
        {
            Solutions.Clear();
            int k = 0;

            Hansen(X, ref k);

            Count = k;

            return Solutions;
        }

        private void Hansen(Interval a, ref int k)
        {
            ++k;

            if (a.Width <= eps)
            {
                Solutions.Add(a);
                return;
            }

            if (dFdx(a).Contains(0.0))
            {

                Interval[] D = Interval.Division(F(a.Middle), a);

                Interval A1 = D[0];
                Interval A2 = D[1];

                Interval U1 = A1.Middle - F(A1.Middle) / dFdx(A1);
                Interval X1 = Interval.Intersection(U1, A1);
                if (X1.Width > 2 * eps) Hansen(X1, ref k);

                Interval U2 = A2.Middle - F(A2.Middle) / dFdx(A2);
                Interval X2 = Interval.Intersection(U2, A2);
                if (X2.Width > 2 * eps) Hansen(X2, ref k);
            }
            else
            {
                Interval U = a.Middle - F(a.Middle) / dFdx(a);
                Interval X = Interval.Intersection(U, a);
                if (X.Width > 2 * eps) Hansen(X, ref k);
                else Solutions.Add(X);
            }
        }
    }
}
