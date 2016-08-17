namespace TreehouseDefense
{
    class Level
    {
        protected Map Map { get; }
        protected Path Path { get; }
        protected Invader[] Enemies { get; }
        public Tower[] Towers { get; set; }
        
        public Level(Map map, Path path, Invader[] enemies)
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
            
            // Loop until all enemies are disabled or an enemy reaches the end of the path.
            while(remainingEnemies > 0)
            {
                // Each tower has opportunity to fire on enemies
                foreach(var tower in Towers)
                {
                    tower.FireOnEnemies(Enemies);
                }
                
                remainingEnemies = 0;
                
                // Count count and move enemies that are still active.
                foreach(var enemy in Enemies)
                {
                    if(enemy.IsActive)
                    {
                        enemy.Move();
                        if(enemy.HasScored)
                        {
                            return true;
                        }
                        
                        ++remainingEnemies;
                    }
                }
            }
            return false;
        }
    }
}
