using System;

namespace GeometryApp
{
    public class Cone : GeometricShape
    {
        public double Radius { get; set; }
        public double Height { get; set; }

        public Cone(double radius, double height) : base("Конус")
        {
            Radius = radius;
            Height = height;
        }

        public override double CalculateVolume()
        {
            return (Math.PI * Math.Pow(Radius, 2) * Height) / 3;
        }

        public override double CalculateSurfaceArea()
        {
            double slantHeight = Math.Sqrt(Math.Pow(Radius, 2) + Math.Pow(Height, 2));
            return Math.PI * Radius * (Radius + slantHeight);
        }


        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Радиус: {Radius:F2}, Высота: {Height:F2}";
        }
    }
}