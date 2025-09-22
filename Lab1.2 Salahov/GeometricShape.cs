using GeometryApp;
using System.Windows;

public abstract class GeometricShape : DependencyObject, IGeometricShape
{
    public string Name { get; set; }

    protected GeometricShape(string name)
    {
        Name = name;
    }

    public abstract double CalculateVolume();
    public abstract double CalculateSurfaceArea();

    public virtual string GetInfo()
    {
        return $"Фигура: {Name}";
    }
}