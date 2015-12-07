namespace TreehouseDefense
{
    class Level
    {
        protected Map Map { get; private set; }
        protected Path Path { get; private set; }
        protected Enemy[] Enemies { get; private set; }
        public Tower[] Towers { get; set; }
        
        public Level(Map map, Path path, Enemy[] enemies)
        {
            Map = map;
            Path = path;
            Enemies = enemies;
        }
        
        // Virtual method open for extension
        // Review of a lot of the C# basics concepts
        public virtual bool Play()
        {
            int remainingEnemies = Enemies.Length;
            bool playerLost = false;
            
            while(remainingEnemies > 0)
            {
                foreach(var tower in Towers)
                {
                    tower.FireOnEnemies(Enemies);
                }
                
                remainingEnemies = 0;
                
                foreach(var enemy in Enemies)
                {
                    if(enemy.IsActive)
                    {
                        if(enemy.Move())
                        {
                            playerLost = true;
                            break; 
                        }
                        
                        ++remainingEnemies;
                    }
                }
            }
            
            return playerLost;
        }
    }
}
