namespace TreehouseDefense
{
    // Custom exceptions
    class OutOfBoundsException : System.Exception
    {
        // Implemented default constructor
        public OutOfBoundsException()
        {}
        
        // Overloaded constructor
        public OutOfBoundsException(string message) : base(message)
        {}
    }
    
    class TowerOnPathException : System.Exception
    {
        public TowerOnPathException(Point location) : base(location.ToString())
        {}
    }
    
    class PathInvalidException : System.Exception
    {
        public PathInvalidException(string message) : base(message)
        {}
    }
}
