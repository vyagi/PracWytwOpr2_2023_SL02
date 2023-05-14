using FluentAssertions;

namespace Geometry.Tests
{
    public class PointTests
    {
        [Fact]
        public void A_default_point_can_be_created()
        {
            var p = new Point();

            p.X.Should().Be(0);
            p.Y.Should().Be(0);
        }

        [Fact]
        public void A_point_can_be_created_with_one_parameter()
        {
            var p = new Point(5);

            p.X.Should().Be(5);
            p.Y.Should().Be(5);
        }

        [Fact]
        public void A_point_can_be_created_with_two_parameter()
        {
            var p = new Point(5, 6);

            p.X.Should().Be(5);
            p.Y.Should().Be(6);
        }

        [Fact]
        public void A_point_is_moveable()
        {
            var p = new Point(5, 6);

            p.Should().BeAssignableTo<IMoveable>();
        }

        [Fact]
        public void A_point_is_moved_correctly()
        {
            var p = new Point(5, 6);

            p.Move(2, 3);

            p.X.Should().Be(7);
            p.Y.Should().Be(9);
        }
    }
}