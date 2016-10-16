using System.Linq;

namespace IntervalFunctions.BL.Models
{
    public static class MathExtension
    {
        public static double Min(params double[] x) => x.Min();
        public static double Max(params double[] x) => x.Max();
    }
}
