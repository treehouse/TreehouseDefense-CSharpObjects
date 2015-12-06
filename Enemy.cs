using System;

namespace TreehouseDefense
{
    abstract class Enemy
    {
        protected abstract int Health { get; set; }
        protected abstract int StepSize { get; } 
        public bool IsActive { get { return Health > 0 && Location != null; } }
        public MapLocation Location { get; private set; }
        private Path _path;
        private int PathStep = 0;
        
        public Enemy(Path path)
        {
            _path = path;
            Location = _path.GetLocationAt(PathStep);
        }
        
        public void DecreaseHealth(int factor)
        {
            Health -= factor;
        }
        
        public bool Move()
        {
            PathStep += StepSize;
            Location = _path.GetLocationAt(PathStep);
            
            return Location == null;
        }
    }
    
    class StandardEnemy: Enemy
    {
        public StandardEnemy(Path path) : base(path)
        {}
    
        protected override int Health { get { return _Health; } set { _Health = value; } }
        protected int _Health = 1;
        protected override int StepSize { get { return 1; } }   
    }
    
    class StrongEnemy: Enemy
    {
        public StrongEnemy(Path path) : base(path)
        {}
    
        protected override int Health { get { return _Health; } set { _Health = value; } }
        protected int _Health = 10;
        protected override int StepSize { get { return 1; } }
        
    }
    
    class FastEnemy: Enemy
    {
        public FastEnemy(Path path) : base(path)
        {}
        
        protected override int Health { get { return _Health; } set { _Health = value; } }
        protected int _Health = 1;
        protected override int StepSize { get { return 2; } }
    }
}
