using System;

namespace SpheroLib
{
    public class Calculator
    {
        public static double ConcaveRadius(double measure, double ring, double ball)
        {
            double term_1 = ring * ring / (2 * measure);
            double term_2 = measure / 2;
            double result = term_1 + term_2 + ball;
            return Math.Round(result, 1);
        }
        public static double ConvexRadius(double measure, double ring, double ball)
        {
            double term_1 = ring * ring / (2 * measure);
            double term_2 = measure / 2;
            double result = term_1 + term_2 - ball;
            return Math.Round(result, 1);
        }

        public static double ConcaveHeight(double measure, double ring, double ball)
        {
            double tmpDif = measure - ball;
            double rootExp = tmpDif * tmpDif - ring * ring;
            double result = tmpDif - Math.Sqrt(rootExp);
            return Math.Round(result, 3);
        }
        public static double ConvexHeight(double measure, double ring, double ball)
        {
            double tmpSum = measure + ball;
            double rootExp = tmpSum * tmpSum - ring * ring;
            double result = tmpSum - Math.Sqrt(rootExp);
            return Math.Round(result, 3);
        }
    }
}
