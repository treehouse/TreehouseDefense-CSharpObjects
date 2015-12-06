namespace TreehouseDefense
{
    class Tower
    {
        protected const int Range = 1;
        protected const int Strength = 2;
        protected MapLocation _location;
        
        public Tower(MapLocation location, Path path)
        {
            _location = location;
            
            if(path.OnPath(_location))
            {
                throw new OutOfBoundsException();
            }
        }
        
        public void FireOnEnemies(Enemy[] enemies)
        {            
            foreach(var enemy in enemies)
            {
                if(enemy.IsActive && _location.InRangeOf(enemy.Location, Range))
                {
                    enemy.DecreaseHealth(Strength);
                    return; // Return after hitting one enemy
                }
            }
        }
    }
}
