namespace TreehouseDefense
{
    // Subclassing
    class MapLocation : Point
    {        
        // protected constructor
        protected MapLocation(int x, int y) : base(x, y)
        {}
        
        // Calling local constructor
        // Input validation / contract verification
        public MapLocation(int x, int y, Map map) : this(x, y)
        {
            if (!map.OnMap(this))
            {
                throw new OutOfBoundsException(x + "," + y + " is out of bounds of the map.");
            }
        }
        
        public bool InRangeOf(MapLocation location, int range)
        {
            // Members can access private members of a different object.
            // implicit parameter type conversions
            return DistanceTo(location) <= range;
        }
    }
}