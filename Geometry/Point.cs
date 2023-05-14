namespace Geometry
{
    public interface IMoveable
    {
        void Move(double x, double y);
    }

    public class Point : IMoveable
    {
        private double _x;
        private double _y;

        public Point()
        {
        }

        public Point(double number) : this(number, number) { }

        public Point(double x, double y) => (_x, _y) = (x, y);

        public double X => _x;
        public double Y => _y;

        public void Move(double x, double y)
        {
            _x += x;
            _y += y;
        }
    }
}
