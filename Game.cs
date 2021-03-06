using System;

namespace TreehouseDefense
{
    class Game
    {
        static void Main()
        {   
            
            try
            {
                // named parameters
                // In a real game level1* would all be read from a file but we haven't learned that yet.
                var level1Map = new Map(width:10, height:5);
                
                var level1Path = new Path(
                    new []
                    {
                        new MapLocation(0, 2, level1Map), 
                        new MapLocation(1, 2, level1Map),
                        new MapLocation(2, 2, level1Map),
                        new MapLocation(3, 2, level1Map),
                        new MapLocation(4, 2, level1Map),
                        new MapLocation(5, 2, level1Map),
                        new MapLocation(6, 2, level1Map),
                        new MapLocation(7, 2, level1Map),
                        new MapLocation(8, 2, level1Map),
                        new MapLocation(9, 2, level1Map)
                    }
                );
                
                // type explicit array initialization
                var level1Enemies = new Invader[]
                {
                    new StandardInvader(level1Path),
                    new StrongInvader(level1Path),
                    //new StrongEnemy(level1Path),
                    //new FastEnemy(level1Path),
                    //new FastEnemy(level1Path)
                };
                
                // Object intialization
                var level1 = new Level(level1Map, level1Path, level1Enemies)
                {
                    // type inferred array initialization
                    Towers = new Tower[]
                    { 
                        new BasicTower(new MapLocation(1, 3, level1Map), level1Path),
                        new SniperTower(new MapLocation(2, 3, level1Map), level1Path),
                        new PowerfulTower(new MapLocation(3, 3, level1Map), level1Path),
                        new PowerfulTower(new MapLocation(4, 3, level1Map), level1Path),
                        new PowerfulTower(new MapLocation(5, 3, level1Map), level1Path),
                        new PowerfulTower(new MapLocation(6, 3, level1Map), level1Path),
                    }
                };
                
                var playerLost = level1.Play();
                Console.WriteLine("Player " + (playerLost? "lost" : "won"));
            }
            catch (OutOfBoundsException ex)
            {
                Console.WriteLine("Attempted to create an invalid map location: " + ex.Message);
            }
            catch (TreehouseDefenseException ex)
            {
                
            }
            catch (Exception)
            {  
                throw;
            }
        }
    }
} 
