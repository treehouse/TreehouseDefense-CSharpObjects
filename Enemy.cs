using System;

namespace TreehouseDefense
{
    // Abstract base class
    abstract class Enemy
    {
        // private readonly field
        private readonly Path _path;
        // private mutable field 
        private int _pathPosition = 0;
        
        public Enemy(Path path)
        {
            _path = path;
            Location = _path.GetLocationAt(_pathPosition);
        }
        
        // complex accessor property
        public bool IsActive { get { return Health > 0 && Location != null; } }
        // auto property with access modifier on accessor
        public MapLocation Location { get; private set; }
        
        // abstract property
        protected abstract int Health { get; set; }
        
        // abstract property with restrictions
        protected abstract int StepSize { get; }
        
        // uint and cast
        public virtual void DecreaseHealth(uint factor)
        {
            Health -= (int)factor;
        }
        
        // comparing with null
        public bool Move()
        {
            _pathPosition += StepSize;
            Location = _path.GetLocationAt(_pathPosition);
            
            return Location == null;
        }
    }
    
    // concrete implementation of abstract base class
    class StandardEnemy: Enemy
    {
        
        public StandardEnemy(Path path) : base(path)
        {}
    
        // implement abstract Property
        // auto property with initializer
        protected override int Health { get; set; } = 1;
        
        // Readonly property with backing field
        protected override int StepSize { get { return _StepSize;} }
        // const field
        private const int _StepSize = 1;
    }
    
    sealed class SheildedEnemy: Enemy
    {
        public SheildedEnemy(Path path) : base(path)
        {}
    
        // abstract and virtual members must remain virtual
        protected override int Health { get; set; } = 10;
        
        // Alternative implementation of readonly property
        protected override int StepSize { get { return 1; } }
        
        // Override virtual method
        public override void DecreaseHealth(uint factor)
        {
            if (Random.NextDouble() < .5)
            {
                base.DecreaseHealth(factor);
            }
        }
    }
    
    // The rest of these are exercises for the student
    
    // This one we'll do together
    class CustomEnemy: Enemy
    {
        public CustomEnemy(Path path, int health, int stepSize) : base(path)
        {
            Health = health;
            _StepSize = stepSize;
        }
        
        protected override int Health { get; set; }
        
        protected override int StepSize { get { return _StepSize; } }
        private readonly int _StepSize;
    }
    
    class StrongEnemy: Enemy
    {
        public StrongEnemy(Path path) : base(path)
        {}
    
        protected override int Health { get; set; } = 10;
        
        protected override int StepSize { get { return 1; } }
    }
    
    class FastEnemy: Enemy
    {
        public FastEnemy(Path path) : base(path)
        {}
        
        protected override int Health { get; set; } = 1;
        
        protected override int StepSize { get { return _StepSize;} }
        private const int _StepSize = 2;
    }
}
