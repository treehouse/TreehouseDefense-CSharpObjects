using System;

namespace TreehouseDefense
{
    class Point
    {
        public readonly int X;
        public readonly int Y;
        
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        // Teach the copy constructor
        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }
        
        public double DistanceTo(Point point)
        {
            // Cartesian Distance Formula
            return Math.Sqrt(Math.Pow(this.X - point.X, 2) + Math.Pow(this.Y - point.Y, 2)); 
        }
        
        public override bool Equals(Object obj)
        {
            var point = obj as Point;
            
            // Compare with (Point)obj;
            
            if(point == null)
            {
                return false;
            }
            
            return this.X == point.X && this.Y == point.Y;
        }
        
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
        
        public override string ToString()
        {
            return string.Format(X + "," + Y);
        }
    }
}
