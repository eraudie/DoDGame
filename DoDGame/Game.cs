using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDGame
{
    class Game
    {
        const int WorldWidth = 20;
        const int WorldHeight = 10;
        const int MaxBackpackWeight = 30;

        Player player;
        Room[,] world;

        #region Methods
        public void Start()
        {
            CreateWorld();
            CreatePlayer();
            do
            {
                Console.Clear();
                DisplayStats();
                DisplayWorld();
                AskForMovement();
                SearchRoom();
                FightMonster();
                player.Health--;

            } while (player.Health > 0);
            GameOver();
            Console.ReadKey();
        }

        private void FightMonster()
        {
            if (world[player.X, player.Y].MonsterInRoom != null)
            {
                Console.Clear();
                DisplayStats();
                DisplayWorld();
                Console.WriteLine("There is a monster in the room!");
                Console.WriteLine($"Name: {world[player.X, player.Y].MonsterInRoom.Name}");
                Console.WriteLine($"Health: {world[player.X, player.Y].MonsterInRoom.Health}");
                Console.WriteLine($"Attack Strength: {world[player.X, player.Y].MonsterInRoom.AttackStrength}");
                Console.WriteLine();
                Console.WriteLine("Do you want to fight it? [Y]/[N]");
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Y :
                        do
                        {
                            player.Fight(world[player.X, player.Y].MonsterInRoom);
                            if (world[player.X, player.Y].MonsterInRoom.Health > 0)
                            {
                                world[player.X, player.Y].MonsterInRoom.Fight(player);
                            }
                            Console.ReadKey();
                        } while (player.Health > 0 && world[player.X, player.Y].MonsterInRoom.Health > 0);

                        world[player.X, player.Y].MonsterInRoom = null;
                        break;

                    case ConsoleKey.N:
                        player.Health -=5;
                        Console.WriteLine("You lose 5 HP, but get away safely.");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            }
        }
        private void SearchRoom()
        {
            if (world[player.X, player.Y].ItemInRoom != null)
            {
                var backpackWeight = player.BackPack.Sum(z => z.Weight);
                if ((backpackWeight + world[player.X, player.Y].ItemInRoom.Weight) < MaxBackpackWeight)
                {
                    player.BackPack.Add(world[player.X, player.Y].ItemInRoom);
                    if (world[player.X, player.Y].ItemInRoom.Name == "Knife")
                        player.AttackStrength += 10;
                    else if (world[player.X, player.Y].ItemInRoom.Name == "Sword")
                        player.AttackStrength += 25;
                    else if (world[player.X, player.Y].ItemInRoom.Name == "Potion")
                        player.Health += 15;

                    world[player.X, player.Y].ItemInRoom = null;
                }
                else
                {
                    Console.Clear();
                    DisplayStats();
                    DisplayWorld();
                    Console.WriteLine("Your backpack is too heavy to carry this item.");
                    Console.ReadKey();
                }
            }
        }
        
        private void DisplayStats()
        {
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Attack Strength: {player.AttackStrength}");
            Console.WriteLine($"Pos: {player.X}:{player.Y}");
            Console.Write($"Backpack: ");
            foreach (Item i in player.BackPack)
            {
                Console.Write(i.Name + " ");
            }
            Console.WriteLine();
        }

        private void AskForMovement()
        {
            Console.WriteLine("Move!");
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            int x = player.X;
            int y = player.Y;

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: x++; break;
                case ConsoleKey.LeftArrow: x--; break;
                case ConsoleKey.UpArrow: y--; break;
                case ConsoleKey.DownArrow: y++; break;
            }

            //Check: Within gameboard?
            if (x >= 0 && x < WorldWidth && y >= 0 && y < WorldHeight)
            {
                player.X = x;
                player.Y = y;
            }
        }
       
        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over :CCCCC");
        }

        private void CreateWorld()
        {
            Console.WriteLine("Creating world");

            world = new Room[WorldWidth, WorldHeight];
            for (int y = 0; y < WorldHeight; y++)
            {
                for (int x = 0; x < WorldWidth; x++)
                {
                    Room room = new Room();
                    world[x, y] = room;
                }
            }
            PlaceItemsAndMonsters();
        }
        
        private void PlaceItemsAndMonsters()
        {
            Random random = new Random();
            Random randomHealth = new Random();
            Random randomAttackStrength = new Random();
            world[random.Next(0, WorldWidth), random.Next(0, WorldHeight)].MonsterInRoom = new Monster("Monster", randomHealth.Next(10, 70), randomAttackStrength.Next(30, 80), "Ogre");
            world[random.Next(0, WorldWidth), random.Next(0, WorldHeight)].MonsterInRoom = new Monster("Monster", randomHealth.Next(10, 70), randomAttackStrength.Next(30, 80), "Ogre");
            world[random.Next(0, WorldWidth), random.Next(0, WorldHeight)].MonsterInRoom = new Monster("Monster", randomHealth.Next(10, 70), randomAttackStrength.Next(30, 80), "Gremlin");
            world[random.Next(0, WorldWidth), random.Next(0, WorldHeight)].MonsterInRoom = new Monster("Monster", randomHealth.Next(10, 70), randomAttackStrength.Next(30, 80), "Gremlin");
            world[random.Next(0, WorldWidth), random.Next(0, WorldHeight)].ItemInRoom = new Item("Sword", 25);
            world[random.Next(0, WorldWidth), random.Next(0, WorldHeight)].ItemInRoom = new Item("Potion", 3);
            world[random.Next(0, WorldWidth), random.Next(0, WorldHeight)].ItemInRoom = new Item("Knife", 8);
        }

        private void CreatePlayer()
        {
            player = new Player("Player", 100, 20);
        }

        private void DisplayWorld()
        {
            for (int y = 0; y < WorldHeight; y++)
            {
                for (int x = 0; x < WorldWidth; x++)
                {
                    Room room = world[x, y];
                    if (player.X == x && player.Y == y)
                        Console.Write("*P*");
                    else if (room.MonsterInRoom != null)
                    {
                        Console.Write(" M ");
                    }
                    else if (room.ItemInRoom != null)
                    {
                        Console.Write(room.ItemInRoom.Name.Substring(0, 2) + ' ');
                    }
                    else
                        Console.Write(" . ");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
