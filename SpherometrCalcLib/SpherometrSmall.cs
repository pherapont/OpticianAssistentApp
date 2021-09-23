namespace SpherometrCalcLib
{
    public class SpherometrSmall : Spherometr
    {
        double[] rings = { 59.9797, 42.504, 29.964, 21.2656, 15.0073, 0, 7.477 };

        double[] balls = { 4.725, 5.15, 4.345, 3.153, 2.375, 0, 1.17 };

        double ring;
        double ball;

        public SpherometrSmall(int ringNumber)
        {
            ring = rings[ringNumber - 1];
            ball = balls[ringNumber - 1];
        }
        public override double GetRingRadius()
        {
            return ring;
        }

        public override double GetBallRadius()
        {
            return ball;
        }
    }
}
