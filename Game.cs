using System;

namespace TreehouseDefense
{
    class Game
    {
        private readonly Map _map;
        private readonly Path _path;
        private readonly Tower[] _towers;
        private readonly Enemy[] _enemies;
        
        public Game()
        {
            _map = new Map(10, 5);
            
            var _path = new Path(
                new MapLocation[]
                {
                    new MapLocation(0, 2, _map), 
                    new MapLocation(1, 2, _map),
                    new MapLocation(2, 2, _map),
                    new MapLocation(3, 2, _map),
                    new MapLocation(4, 2, _map),
                    new MapLocation(5, 2, _map),
                    new MapLocation(6, 2, _map),
                    new MapLocation(7, 2, _map),
                    new MapLocation(8, 2, _map),
                    new MapLocation(8, 2, _map)                    
                }
            );
            
            // Set up the initial towers.
            _towers = new [] 
            { 
                new Tower(new MapLocation(2, 3, _map), _path),
                new Tower(new MapLocation(4, 3, _map), _path),
                new Tower(new MapLocation(6, 3, _map), _path)
            };
            
            _enemies = new Enemy[]
            {
                new StandardEnemy(_path),
                //new StrongEnemy(_path),
                //new StrongEnemy(_path),
                //new FastEnemy(_path),
                //new FastEnemy(_path)
            };
        }        
        
        public void Play()
        {
            int remainingEnemies = _enemies.Length;
            bool playerLost = false;
            
            while(remainingEnemies > 0)
            {
                foreach(var tower in _towers)
                {
                    tower.FireOnEnemies(_enemies);
                }
                
                remainingEnemies = 0;
                
                foreach(var enemy in _enemies)
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
            
            Console.WriteLine("Player " + (playerLost? "lost" : "won"));
        }
        
        static void Main()
        {
            var game = new Game();
            game.Play();
        }
    }
} 
