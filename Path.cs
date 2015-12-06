using System;

namespace TreehouseDefense
{
    class Path
    {
        private readonly MapLocation[] _path;
        
        public int Length { get { return _path.Length; } }
        
        public Path(MapLocation[] path)
        {            
            _path = path;
            ValidatePath();
        }
        
        private void ValidatePath()
        {
            for(int i = 0; i < _path.Length-2; ++i)
            {
                var curPos = _path[i];
                var nextPos = _path[i+1];
                var nextNextPos = _path[i+2];
                
                if (curPos.Equals(nextPos) || curPos.Equals(nextNextPos) ||
                  !(Math.Abs(curPos.X - nextPos.X) == 1 ^ Math.Abs(curPos.Y - nextPos.Y) == 1))
                {
                    throw new PathInvalidException(curPos + " -> " + nextPos + " -> " + nextNextPos);
                }
            }
        }
        
        public MapLocation GetLocationAt(int index)
        {            
            return (index < _path.Length)? _path[index] : null; 
        }
        
        public bool OnPath(MapLocation location)
        {
            return System.Array.IndexOf(_path, location) != -1;
        }
    }
}
