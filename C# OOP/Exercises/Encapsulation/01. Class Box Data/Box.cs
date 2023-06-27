namespace ClassBoxData;
public class Box
{
    private double length;
    private double width;
    private double height;
    public double SurfaceArea() => 2 * length * width + 2 * length * height + 2 * width * height;
    public double LateralSurfaceArea() => 2 * length * height + 2 * width * height;
    public double Volume() => length * width * height;
    private double Validate(double value,string propertyName)
    {
        if(value <= 0)
        {
            throw new ArgumentException($"{propertyName} cannot be zero or negative.");
        }
        return value;
    }
    public double Length { get => length; private set => length = Validate(value,"Length"); }
    public double Width { get => width; private set => width = Validate(value,"Width"); }
    public double Height { get => height; private set => height = Validate(value,"Height"); }
    public Box(double length,double width,double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }
}