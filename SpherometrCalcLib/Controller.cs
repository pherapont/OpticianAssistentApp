using System;

namespace SpherometrCalcLib
{
    public class Controller
    {
        delegate double UniversalSpherometrCalculator(double measure, double ring, double ball);
        public static double GetAndCalculate(UserInputData data)
        {
            Spherometr spherometr;
            if (data.Spherometr == TypeOfSpherometr.Big)
            {
                spherometr = new SpherometrBig(data.RingNumber);
            }
            else
            {
                spherometr = new SpherometrSmall(data.RingNumber);
            }
            double ring = spherometr.GetRingRadius();
            double ball = spherometr.GetBallRadius();
            double measure = data.UserMeasureData;

            UniversalSpherometrCalculator calculator;

            if (data.Calculation == TypeOfCalculation.Height && data.Surface == TypeOfSurface.Concave)
            {
                calculator = Calculator.ConcaveHeight;
            }
            else if (data.Calculation == TypeOfCalculation.Height && data.Surface == TypeOfSurface.Convex)
            {
                calculator = Calculator.ConvexHeight;
            }
            else if (data.Calculation == TypeOfCalculation.Radius && data.Surface == TypeOfSurface.Concave)
            {
                calculator = Calculator.ConcaveRadius;
            }
            else if (data.Calculation == TypeOfCalculation.Radius && data.Surface == TypeOfSurface.Convex)
            {
                calculator = Calculator.ConvexRadius;
            }
            else
            {
                throw new Exception("Нет таких параметров вычислений");
            }
            return calculator(measure, ring, ball);
        }
    }
}
