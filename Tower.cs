namespace TreehouseDefense
{    
    // Concrete base class
    abstract class Tower
    {
        private readonly MapLocation _location;
        
        public Tower(MapLocation location, Path path)
        {
            _location = location;
            
            if(path.OnPath(_location))
            {
                throw new TowerOnPathException(_location);
            }
        }

        protected virtual int Range { get; }
        protected virtual int Power { get; }
        protected virtual double Accuracy { get; }

        // Random, property behaves like a method with no parameters
        private bool EnemyHit { get { return Random.NextDouble() < Accuracy; } }

        // &&, default Object.ToString() implementation
        public void FireOnEnemy(Invader enemy)
        {
            if(enemy.IsActive && _location.InRangeOf(enemy.Location, Range))
            {
                if(EnemyHit)
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

        // foreach, passing arrays       
        public void FireOnEnemies(Invader[] enemies)
        {
            foreach(var enemy in enemies)
            {
                FireOnEnemy(enemy);
            }
        }
    }
    
    class BasicTower : Tower
    {
        public BasicTower(MapLocation location, Path path) : base(location, path)
        {}
        // virtual property
        protected override int Range { get { return 1; } }

        //protected virtual int Power { get { return 1; } }
        protected override int Power { get; } = 1;
        protected override double Accuracy { get { return .5; } }
    }

    class LongRangeTower : Tower
    {
        public LongRangeTower(MapLocation location, Path path) : base(location, path)
        {}

        // overriding virtual property and polymorphism
        protected override int Range { get { return 3; } }
        protected override int Power { get { return 1; } }
        protected override double Accuracy { get { return .33; } }
    }
    
    class CustomTower : Tower
    {
        // optional parameters
        public CustomTower(MapLocation location, Path path, 
            int range = 1, int power = 1, double accuracy = .5) : base(location, path)
        {
            _Range = range;
            Power = power;
            _Accuracy = accuracy;
        }

        // Three different ways to do a readonly property
        protected override int Range { get { return _Range; } }
        private readonly int _Range;
        
        protected override int Power { get; }
        
        protected override double Accuracy => _Accuracy;
        private readonly double _Accuracy;
    }
    
    // These are all an exercise for the student. 
    // Does it make more sense for Tower to be the abstract base class instead of Enemy?
    
    class PowerfulTower : Tower
    {
        public PowerfulTower(MapLocation location, Path path) : base(location, path)
        {}

        protected override int Range { get { return 1; } }
        protected override int Power { get { return 3; } }
        protected override double Accuracy { get { return .5; } }
    }
    
    class SniperTower : Tower
    {
        public SniperTower(MapLocation location, Path path) : base(location, path)
        {}

        protected override int Range { get { return 2; } }
        protected override int Power { get { return 1; } }
        protected override double Accuracy { get { return 1.0; } }
    }
}
