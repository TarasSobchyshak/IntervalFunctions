using IntervalFunctions.BL.Models;
using System;
using System.Collections.Generic;

namespace IntervalFunctions.BL.Algorithms
{
    public class MooreMethod
    {
        public Func<double, double> F { get; private set; }
        public Func<Interval, Interval> dFdx { get; private set; }

        public Interval X { get; private set; }
        public List<Interval> Solutions { get; private set; }

        private double eps = 0.000001;
        public int Count { get; private set; }

        public MooreMethod(Interval x, Func<double, double> f, Func<Interval, Interval> dFdx)
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

            Moore(X, ref k);

            Count = k;

            return Solutions;
        }

        private void Moore(Interval a, ref int k)
        {
            ++k;

            if (a.Width <= eps)
            {
                Solutions.Add(a);
                return;
            }

            if (dFdx(a).Contains(0.0))
            {

                Interval A1 = new Interval(a.Start, a.Middle - eps);
                Interval A2 = new Interval(a.Middle + eps, a.End);

                if (dFdx(A1).Contains(0.0))
                {
                    Moore(A1, ref k);
                }
                else
                {
                    var c = A1.Middle;
                    Interval U1 = A1.Middle - F(A1.Middle) / dFdx(A1);
                    Interval X1 = Interval.Intersection(U1, A1);
                    if (X1.Width > eps) Moore(X1, ref k);
                }

                if (dFdx(A2).Contains(0.0))
                {
                    Moore(A2, ref k);
                }
                else
                {
                    var c = A1.Middle;
                    Interval U1 = A2.Middle - F(A2.Middle) / dFdx(A2);
                    Interval X1 = Interval.Intersection(U1, A2);
                    if (X1.Width > eps) Moore(X1, ref k);
                }
            }
            else
            {
                double c = a.Middle;
                Interval U = c - F(c) / dFdx(a);
                Interval X = Interval.Intersection(U, a);
                if (X.Width > eps) Moore(X, ref k);
                else Solutions.Add(X);
            }
        }
    }
}
