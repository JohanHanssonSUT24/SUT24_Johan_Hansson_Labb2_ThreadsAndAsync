using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT24_Johan_Hansson_Labb2_ThreadsAndAsync.Models
{
    public class Race
    {
        private List<Car> cars;
        private bool raceCompleted = false;

        public Race(List<Car> cars)//List of cars in race
        {
            this.cars = cars;
        }

        public async Task StartRace()//Start async race
        {
            Console.WriteLine("Bilarna är iväg!!!");
            List<Task> tasks = new List<Task>();//List of tasks for each car's race
            foreach (var car in cars)
            {
                var task = Task.Run(async () =>
                {
                    await car.StartRace();

                    lock (cars)
                    {
                        if (!raceCompleted)
                        {
                            raceCompleted = true;//Race done, and the winner is
                            Console.WriteLine($"Vilken sanslös insats av {car.Name} som vinner detta otroligt spännande lopp!");
                        }
                    }
                });
                tasks.Add(task);
            }
            _ = Task.Run(() =>
            {
                while (!raceCompleted)//If user presses Enter or types status, show details of the car's status
                {
                    var input = Console.ReadLine();
                    if (input == "" || input.ToLower() == "status")
                    {
                        foreach (var car in cars)
                        {
                            Console.WriteLine(car.Status());
                        }
                    }
                }
            });
            await Task.WhenAll(tasks);//Wait until all car's have finished
        }
    }
}