using System;
//Andrea Compton 2022
namespace ConsoleRPG
{
    class Program
    {
        private static Player _player = new Player();
        static void Main(string[] args)
        {
            GameEngine.Initialize();
            Console.WriteLine("What is your name?");
            string NAme = Console.ReadLine().Trim();
            Console.WriteLine("Welcome {0}", NAme);
            _player.Name = NAme;

            Console.ReadLine();
        }
    }
}
