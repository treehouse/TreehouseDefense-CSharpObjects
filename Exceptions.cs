namespace TreehouseDefense
{
    class OutOfBoundsException : System.Exception
    {}
    
    class PathInvalidException : System.Exception
    {
        public PathInvalidException(string message) : base(message)
        {}
    }
}
