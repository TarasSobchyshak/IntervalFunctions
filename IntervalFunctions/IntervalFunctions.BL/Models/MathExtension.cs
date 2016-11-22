using System.Linq;

namespace IntervalFunctions.BL.Models
{
    public static class MathExtension
    {
        public static double Min(params double[] x) => x.Min();
        public static double Max(params double[] x) => x.Max();
        public static Matrix Invert2x2(Matrix a)
        {
            Matrix result = new Matrix(2);
            double det = a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0];

            result[0, 0] = a[1, 1];
            result[1, 0] = -a[1, 0];
            result[0, 1] = -a[0, 1];
            result[1, 1] = a[0, 0];

            return result / det;
        }
    }
}
