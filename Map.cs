using System;

namespace TreehouseDefense
{
    class Map
    {
        public readonly uint Width;
        public readonly uint Height;

        public Map(uint width, uint height)
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
