using System;

namespace GeometryApp
{
    public interface IGeometricShape
    {
        double CalculateVolume();
        double CalculateSurfaceArea();
    }
}