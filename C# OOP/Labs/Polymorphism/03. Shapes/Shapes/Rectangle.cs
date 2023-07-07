namespace Shapes.Shapes;
public class Rectangle:Shape
{
    private double height, width;
    public double Height { get => height; private set => height = value; }
    public double Width { get => width; private set => width = value; }
    public Rectangle(double height,double width)
    {
        Height = height;
        Width = width;
    }
    public override double CalculateArea() => Height * Width;
    public override double CalculatePerimeter() => (Width + Height) * 2;
    public override string Draw() => $"Drawing Rectangle";
}