using System;

namespace GeometryApp
{
    public class Tetrahedron : GeometricShape
    {
        public double Edge { get; set; }

        public Tetrahedron(double edge) : base("Тетраэдр")
        {
            Edge = edge;
        }

        public override double CalculateVolume()
        {
            return Math.Pow(Edge, 3) / (6 * Math.Sqrt(2));
        }

        public override double CalculateSurfaceArea()
        {
            return Math.Sqrt(3) * Math.Pow(Edge, 2);
        }
    }
}