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

        public Race(List<Car> cars)
        {
            this.cars = cars;
        }

        public async Task StartRace()
        {
            List<Task> tasks = new List<Task>();
            foreach (var car in cars)
            {
                var task = Task.Run(async () =>
                {
                    await car.StartRace();

                    lock (cars)
                    {
                        if (!raceCompleted)
                        {
                            raceCompleted = true;
                            Console.WriteLine($"Vilken sanslös insats av {car.Name} som vinner detta otroligt spännande lopp!");
                        }
                    }
                });
                tasks.Add(task);
            }
            _ = Task.Run(() =>
            {
                while (!raceCompleted)
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
            await Task.WhenAll(tasks);
        }
    }
}