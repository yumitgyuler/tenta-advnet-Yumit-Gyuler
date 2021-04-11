using Business;
using Business.Service;
using DataAccess;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new advYumitGyulerContext();
            dbContext.Database.EnsureCreated();

            Console.Write("How many days do you want the simulation to take?: ");
            int days = int.Parse(Console.ReadLine());

            Console.Write("How fast do you want the simulation to progress?(Tics per second): ");
            int ticksPerSecond = int.Parse(Console.ReadLine());

            Tick tick = new Tick(ticksPerSecond, days);
        }
    }
}
