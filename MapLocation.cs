namespace TreehouseDefense
{
    // Subclassing
    class MapLocation : Point
    {        
        // protected constructor
        protected MapLocation(uint x, uint y) : base((int) x, (int) y)
        {}
        
        // Calling local constructor
        // Input validation / contract verification
        public MapLocation(uint x, uint y, Map map) : this(x, y)
        {
            if (!map.OnMap(this))
            {
                throw new OutOfBoundsException();
            }
        }
        
        public bool InRangeOf(MapLocation location, uint range)
        {
            // Members can access private members of a different object.
            return DistanceTo(location) <= range;
        }
    }
}