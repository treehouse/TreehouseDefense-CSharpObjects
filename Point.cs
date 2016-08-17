using System;
using static System.Math;

namespace TreehouseDefense
{
    class Point // : Object
    {
        // public readonly field (excusable practice in this case)
        public readonly int X;
        public readonly int Y;
        
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        // Math methods, using domain specific resources
        public int DistanceTo(int x, int y)
        {
            // Alternate formula that treats diagonal points as being the same distance as those on the axes.
            //return Math.Max(Math.Abs(X-x), Math.Abs(Y-y));
            
            // Cartesian Distance Formula
            return (int)Sqrt(Pow(X - x, 2) + Pow(Y - y, 2)); 
        }
        
        // Overloaded methods
        public int DistanceTo(Point point)
        {
            return DistanceTo(point.X, point.Y);
        }
        
        // overriding Object.Equals
        public override bool Equals(Object obj)
        {
            // casting using as
            // Compare with (Point)obj;
            var point = obj as Point;
            
            if(point == null)
            {
                return false;
            }
            
            return this.X == point.X && this.Y == point.Y;
        }
        
        // overriding Object.GetHashCode() to avoid warning
        public override int GetHashCode()
        {
            throw new NotImplementedException();
            //return X.GetHashCode() ^ Y.GetHashCode();
        }
        
        // overriding Object.ToString()
        // Single line method
        public override string ToString() => X + "," + Y;
    }
}
