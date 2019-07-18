namespace FSEDemo.Inheritance
{
    public abstract class Shape
    {
        private string name;

        public Shape(string s)
        {
            // calling the set accessor of the Id property.
            Id = s;
        }
        public int MyProperty { get; set; }

        public string Id { get; set; }

        // Area is a read-only property - only a get accessor is needed:
        public abstract double Area { get; }

        public override string ToString()
        {
            return $"{Id} Area = {Area:F2}";
        }
    }

    /// <summary>
    /// interface IPaintCost 
    /// </summary>
    public interface IPaintCost
    {
        double GetCost(double area);
    }

    /// <summary>
    ///  Derived class inheritated Shape class and interface IPaintCost 
    /// </summary>
    class Rectangle : Shape, IPaintCost
    {
        private int width;
        private int height;

        public Rectangle(int width, int height, string id)
            : base(id)
        {
            this.width = width;
            this.height = height;
        }

        public override double Area
        {
            get { return width * height; }
        }

        public double GetCost(double area)
        {
            return area * 700;
        }
    }

    public class Circle : Shape
    {
        private int radius;

        public Circle(int radius, string id)
            : base(id)
        {
            this.radius = radius;
        }

        public override double Area
        {
            get
            {
                // Given the radius, return the area of a circle:
                return radius * radius * System.Math.PI;
            }
        }
    }
}
