using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_09
{
    public class Position : IEquatable<Position>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Up()
        {
            X++;
        }
        public void Down()
        {
            X--;
        }

        public void Left()
        {
            Y--;
        }

        public void Right()
        {
            Y++;
        }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Position GetCopy() => new Position(X, Y);

        public override bool Equals(object? obj) => this.Equals(obj as Position);

        public bool Equals(Position p)
        {
            if (p is null)
                return false;

            if (this.GetType() != p.GetType())
                return false;

            if (this.X != p.X || this.Y != p.Y)
                return false;

            return true;
        }
        public static bool operator ==(Position a, Position b)
        {
            if (a is null && b is null)
                return true;
            if (a is null || b is null)
                return false;
            // Equals handles case of null on right side.
            return a.Equals(b);
        }

        public static bool operator !=(Position a, Position b) => !(a == b);
        public override int GetHashCode() => (X, Y).GetHashCode();
    }
}
