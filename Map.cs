using System;

namespace TreehouseDefense
{
    class Map
    {
        public readonly int Width;
        public readonly int Height;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }
        
        public bool OnMap(Point location)
        {
            return location.X >= 0 && location.X < Width && 
                   location.Y >= 0 && location.Y < Height;
        }
    }    
}
