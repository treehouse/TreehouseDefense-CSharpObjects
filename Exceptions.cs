namespace TreehouseDefense
{
    class TreehouseDefenseException : System.Exception
    {
        // Implemented default constructor
        public TreehouseDefenseException()
        {}
        
        // Overloaded constructor
        public TreehouseDefenseException(string message) : base(message)
        {}
    }
    
    // Custom exceptions
    class OutOfBoundsException : TreehouseDefenseException
    {
        // Implemented default constructor
        public OutOfBoundsException()
        {}
        
        // Overloaded constructor
        public OutOfBoundsException(string message) : base(message)
        {}
    }
    
    class TowerOnPathException : TreehouseDefenseException
    {
        public TowerOnPathException(Point location) : base(location.ToString())
        {}
    }
    
    class PathInvalidException : TreehouseDefenseException
    {
        public PathInvalidException(string message) : base(message)
        {}
    }
}
