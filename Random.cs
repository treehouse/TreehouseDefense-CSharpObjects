namespace TreehouseDefense
{
    // Static class, wrapper class concept
    static class Random
    {
        private static readonly System.Random _random = new System.Random();
        
        // Single line method
        public static double NextDouble() => _random.NextDouble(); 
    }
}
