using IntervalFunctions.BL.Models;
using System;
using static IntervalFunctions.BL.Models.MathExtension;

namespace IntervalFunctions.BL.Algorithms
{
    public class EquationSystem
    {
        public Func<Interval, Interval, Interval> F1 = (x, y) => new Interval(2, 11) * x * x + 3 * new Interval(2, 8) * y;
        public Func<Interval, Interval, Interval> F2 = (x, y) => new Interval(8, 16) * x + new Interval(3, 7) * y;


    }
}
