﻿namespace JewellNS
{
    public class JewelCollector
    {
        public static void Main(string[] args)
        {

            initialStartUp();
            Console.WriteLine("Para sair do programa digite 'quit' ");
            bool running = true;
            do
            {
                Console.WriteLine("Enter the command: ");
                string command = Console.ReadLine()!;

                if (command.Equals("quit"))
                {
                    running = false;
                }
                else if (command.Equals("w"))
                {
                    Console.WriteLine("w");
                }
                else if (command.Equals("a"))
                {
                    Console.WriteLine("a");
                }
                else if (command.Equals("s"))
                {
                    Console.WriteLine("s");
                }
                else if (command.Equals("d"))
                {
                    Console.WriteLine("d");
                }
                else if (command.Equals("g"))
                {
                    Console.WriteLine("g");
                }
            } while (running);
        }

        public static void initialStartUp()
        {
            Map map = new Map(10, 10);
            Jewell jr = new Jewell { Color = "red", Name = " JR ", Point = 100 };
            Jewell jg = new Jewell { Color = "green", Name = " JG ", Point = 50 };
            Jewell jb = new Jewell { Color = "blue", Name = " JB ", Point = 10 };
            Obstacle water = new Obstacle { obstacle = " ## " };
            Obstacle tree = new Obstacle { obstacle = " $$ " };
            Player player = new Player { Name = " ME " };
            map.setCell(0, 0, player);
            map.setCell(1, 9, jr);
            map.setCell(8, 8, jr);
            map.setCell(9, 1, jg);
            map.setCell(7, 6, jg);
            map.setCell(3, 4, jb);
            map.setCell(2, 1, jb);
            map.setCell(5, 0, water);
            map.setCell(5, 1, water);
            map.setCell(5, 2, water);
            map.setCell(5, 3, water);
            map.setCell(5, 4, water);
            map.setCell(5, 5, water);
            map.setCell(5, 6, water);
            map.setCell(5, 9, tree);
            map.setCell(3, 9, tree);
            map.setCell(8, 3, tree);
            map.setCell(2, 5, tree);
            map.setCell(1, 4, tree);
            map.PrintMap();
        }
    }
}