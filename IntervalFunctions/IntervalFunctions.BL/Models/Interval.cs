using System;
using static System.Math;
using static IntervalFunctions.BL.Models.MathExtension;

namespace IntervalFunctions.BL.Models
{
    public class Interval : ObservableObject
    {
        private bool _hasStart;
        private bool _hasEnd;
        private double _start;
        private double _end;

        public Interval()
        {
            _start = -1d / 0d;
            _end = 1d / 0d;
            _hasStart = true;
            _hasEnd = true;
        }

        public Interval(double start = 0.0, double end = 0.0, bool hasStart = true, bool hasEnd = true)
        {
            if (start > end)
            {
                var t = start;
                start = end;
                end = t;
            }

            _start = start;
            _end = end;
            _hasStart = hasStart;
            _hasEnd = hasEnd;
        }

        public bool HasStart
        {
            get { return _hasStart; }
            set { SetProperty(ref _hasStart, value); }
        }

        public bool HasEnd
        {
            get { return _hasEnd; }
            set { SetProperty(ref _hasEnd, value); }
        }

        public double Start
        {
            get { return _start; }
            set
            {
                if (value < Start) throw new ArgumentException("The value of Start ppoperty have to be less then End");
                SetProperty(ref _start, value);
            }
        }

        public double End
        {
            get { return _end; }
            set
            {
                if (value < Start) throw new ArgumentException("The value of End ppoperty have to be greater then Start");
                SetProperty(ref _end, value);
            }
        }

        public bool IsPoint => (HasStart && HasEnd && Start == End);
        public bool Contains(double v) => (HasStart && v >= Start && HasEnd && v <= End) || (v > Start && v < End);

        public static Interval IFunc(Func<double> f, Interval value)
        {
            return new Interval();
        }

        public static Interval Addition(Interval left, Interval right)
        {
            return new Interval(left.Start + right.Start, left.End + right.End, left.HasStart && right.HasStart, left.HasEnd && right.HasEnd);
        }
        public static Interval Subtraction(Interval left, Interval right)
        {
            return Addition(left, -right);
        }
        public static Interval Multiplication(Interval left, Interval right)
        {
            return new Interval(
                Min(left.Start * right.Start, left.Start * right.End, left.End * right.Start, left.End * right.End),
                Max(left.Start * right.Start, left.Start * right.End, left.End * right.Start, left.End * right.End)
                );
        }
        public static Interval Division(Interval left, Interval right)
        {
            if (right.Contains(0.0)) throw new ArgumentException("Divisor interval cannot contain zero.");
            var divisor = new Interval(1.0 / right.End, 1.0 / right.Start);
            return Multiplication(left, divisor);
        }

        public static Interval operator +(Interval left, Interval right)
        {
            return Addition(left, right);
        }
        public static Interval operator -(Interval left, Interval right)
        {
            return Subtraction(left, right);
        }
        public static Interval operator *(Interval left, Interval right)
        {
            return Multiplication(left, right);
        }
        public static Interval operator /(Interval left, Interval right)
        {
            return Division(left, right);
        }
        public static Interval operator -(Interval value)
        {
            return new Interval(-value.End, -value.Start, value.HasStart, value.HasEnd);
        }
    }
}
