namespace TreehouseDefense
{    
    // Concrete base class
    class Tower
    {
        private MapLocation _location;
        
        public Tower(MapLocation location, Path path)
        {
            _location = location;
            
            if(path.OnPath(_location))
            {
                throw new TowerOnPathException(_location);
            }
        }

        protected virtual uint Range { get { return 1; } }
        protected virtual uint Power { get { return 1; } }
        protected virtual double Accuracy { get { return 2; } }
        
        // Random, property behaves like a method with no parameters
        private bool HitEnemy { get { return Random.NextDouble() < Accuracy; } }

        // foreach, &&, default Object.ToString() implementation       
        public void FireOnEnemies(Enemy[] enemies)
        {
            foreach(var enemy in enemies)
            {
                if(enemy.IsActive && _location.InRangeOf(enemy.Location, Range))
                {
                    if(HitEnemy)
                    {
                        enemy.DecreaseHealth(Power);
                        
                        // In a real game these would be callbacks but we're not covering that
                        System.Console.WriteLine(this + " shot and hit.");
                    }
                    else
                    {
                        System.Console.WriteLine(this + " shot and missed.");
                    }
                    
                    if(!enemy.IsActive)
                    {
                        System.Console.WriteLine(enemy + " is destroyed.");
                    }
                }
            }
        }
    }
    
    // These are all an exercise for the student. 
    // Does it make more sense for Tower to be the abstract base class instead of Enemy?
    
    class LongRangeTower : Tower
    {
        public LongRangeTower(MapLocation location, Path path) : base(location, path)
        {}

        protected override uint Range { get { return 3; } }
        protected override uint Power { get { return 1; } }
        protected override double Accuracy { get { return .33; } }
    }
    
    class PowerfulTower : Tower
    {
        public PowerfulTower(MapLocation location, Path path) : base(location, path)
        {}

        protected override uint Range { get { return 1; } }
        protected override uint Power { get { return 3; } }
        protected override double Accuracy { get { return .5; } }
    }
    
    class SniperTower : Tower
    {
        public SniperTower(MapLocation location, Path path) : base(location, path)
        {}

        protected override uint Range { get { return 2; } }
        protected override uint Power { get { return 1; } }
        protected override double Accuracy { get { return 1.0; } }
    }
    
    class CustomTower : Tower
    {
        public CustomTower(MapLocation location, Path path, 
            uint range = 1, uint strength = 1, double accuracy = .5) : base(location, path)
        {
            _Range = range;
            _Power = strength;
            _Accuracy = accuracy;
        }

        protected override uint Range { get { return _Range; } }
        private readonly uint _Range;
        protected override uint Power { get { return _Power; } }
        private readonly uint _Power;
        protected override double Accuracy { get { return _Accuracy; } }
        private readonly double _Accuracy;
    }
}
