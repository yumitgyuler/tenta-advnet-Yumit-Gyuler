using Business;
using Business.Service;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.Write("How many days do you want the simulation to take?: ");
            //int days = int.Parse(Console.ReadLine());
            //Console.Write("How fast do you want the simulation to progress?(Tics per second): ");
            //int ticksPerSecond = int.Parse(Console.ReadLine());
            Tick tick = new Tick(1, 3);
            //Simulator simulator = new Simulator();

            //simulator.DailyReport();
        }
    }
}
