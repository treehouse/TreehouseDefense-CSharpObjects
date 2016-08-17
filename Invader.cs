namespace TreehouseDefense
{
    // Abstract base class
    abstract class Invader
    {
        // private readonly field
        private readonly Path _path;
        // private mutable field 
        private int _pathStep = 0;
        
        public Invader(Path path)
        {
            _path = path;
        }
        
        // auto property with access modifier on accessor
        public MapLocation Location => _path.GetLocationAt(_pathStep);
        
        // complex accessor property
        public bool IsActive => Health > 0 && !HasScored;
        
        public bool HasScored => _pathStep >= _path.Length;
        // abstract property
        protected abstract int Health { get ; set; }
        
        // abstract property with restrictions
        protected abstract int StepSize { get; }
        
        public virtual void DecreaseHealth(int factor)
        {
            Health -= factor;
        }
        
        public void Move()
        {
            _pathStep += StepSize;
        }
    }
    
    // Sealed
    sealed class SheildedInvader: Invader
    {
        public SheildedInvader(Path path) : base(path)
        {}
    
        // abstract and virtual members must remain virtual
        protected override int Health { get; set; } = 10;
        
        // Alternative implementation of readonly property
        protected override int StepSize { get { return 1; } }
        
        // Override virtual method for polymophism
        // Calling base version
        public override void DecreaseHealth(int factor)
        {
            if (Random.NextDouble() < .5)
            {
                base.DecreaseHealth(factor); // You don't have to do this
            }
        }
    }
    
    // concrete implementation of abstract base class
    class StandardInvader: Invader
    {
        
        public StandardInvader(Path path) : base(path)
        {}
    
        // implement abstract Property
        // auto property with initializer
        protected override int Health { get; set; } = 1;
        
        // Readonly property with backing field
        protected override int StepSize { get { return _StepSize;} }
        // const field
        private const int _StepSize = 1;
    }
    
    // The rest of these are exercises for the student
    
    // This one we'll do together
    class CustomInvader: Invader
    {
        public CustomInvader(Path path, int health, int stepSize) : base(path)
        {
            Health = health;
            _StepSize = stepSize;
        }
        
        protected override int Health { get; set; }
        
        protected override int StepSize { get; private set; }
        private readonly int _StepSize;
    }
    
    class StrongInvader: Invader
    {
        public StrongInvader(Path path) : base(path)
        {}

        protected override int Health { get; set; } = 10;
        
        protected override int StepSize { get { return 1; } }
    }
    
    class FastInvader: Invader
    {
        public FastInvader(Path path) : base(path)
        {}
        
        protected override int Health { get; set; } = 1;
        
        protected override int StepSize { get { return _StepSize;} }
        private const int _StepSize = 2;
    }
}
