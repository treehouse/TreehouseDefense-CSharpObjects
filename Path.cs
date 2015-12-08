using System;

namespace TreehouseDefense
{
    class Path
    {
        // private readonly field
        private readonly MapLocation[] _path;
        
        public Path(MapLocation[] path)
        {            
            _path = path;
            ValidatePath();
        }
        
        // Example of a virtual property
        public int Length { get { return _path.Length; } }
        
        // A different IndexOf array method, for loops, array indexing, nor conditional operator, 
        // Math.Abs, throwing custom exception with descriptions, input validation habits, complex logic
        private void ValidatePath()
        {
            // Make sure the path doesn't loop back on itself.
            for(int i = 0; i < Length; ++i)
            {
                var loc = _path[i];
                if(Array.IndexOf(_path, loc, 0, i) != -1 || 
                   Array.IndexOf(_path, loc, i+1, Length-i-1) != -1)
                {
                    throw new PathInvalidException(loc + " is on the path twice.");
                }
            }
            
            // Make sure the path is contiguous
            for(int i = 0; i < Length-1; ++i)
            {
                var curPos = _path[i];
                var nextPos = _path[i+1];
                if (!(Math.Abs(curPos.X - nextPos.X) == 1 ^ Math.Abs(curPos.Y - nextPos.Y) == 1))
                {
                    throw new PathInvalidException(curPos + " -> " + nextPos + " is not a valid transition.");
                }
            }
        }
        
        // ternary operator, array index accessor
        public MapLocation GetLocationAt(int pathPosition)
        {            
            return (pathPosition < Length)? _path[pathPosition] : null; 
        }
        
        // IndexOf array method
        public bool OnPath(MapLocation location)
        {
            return System.Array.IndexOf(_path, location) != -1;
        }
    }
}
