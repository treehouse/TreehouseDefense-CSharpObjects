using System;

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
        public double DistanceTo(int x, int y)
        {
            // Cartesian Distance Formula
            return Math.Sqrt(Math.Pow(X - x, 2) + Math.Pow(Y - y, 2)); 
        }
        
        // Math methods, using domain specific resources
        public double DistanceTo(Point point)
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
