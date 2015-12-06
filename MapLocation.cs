namespace TreehouseDefense
{
    class MapLocation : Point
    {        
        protected MapLocation(uint x, uint y) : base((int) x, (int) y)
        {}
        
        public MapLocation(uint x, uint y, Map map) : this(x, y)
        {
            if (!map.OnMap(this))
            {
                throw new System.ArgumentOutOfRangeException();
            }
        }
        
        public bool InRangeOf(MapLocation location, uint range)
        {
            // Members can access private members of a different object.
            return DistanceTo(location) <= range;
        }
    }
}