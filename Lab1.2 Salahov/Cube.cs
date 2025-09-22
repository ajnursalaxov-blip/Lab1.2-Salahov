using System;

namespace GeometryApp
{
    public class Cube : GeometricShape
    {
        public double Side { get; set; }

        public Cube(double side) : base("Куб")
        {
            Side = side;
        }

        public override double CalculateVolume()
        {
            return Math.Pow(Side, 3);
        }

        public override double CalculateSurfaceArea()
        {
            return 6 * Math.Pow(Side, 2);
        }


        public string GetInfo(string additionalInfo)
        {
            return $"{GetInfo()}, Длина стороны: {Side}, {additionalInfo}";
        }
    }
}