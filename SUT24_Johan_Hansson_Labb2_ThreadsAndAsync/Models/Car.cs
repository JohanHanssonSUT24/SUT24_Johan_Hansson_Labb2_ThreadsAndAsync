using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT24_Johan_Hansson_Labb2_ThreadsAndAsync.Models
{
    public class Car
    {
        public string Name { get; }
        public double Distance { get; set; } = 0;
        public double Speed { get; set; } = 120;
        public bool Finished { get; set; } = false;


        private readonly object lockObject = new object(); //Object to lock access to distance-data
        private static readonly HashSet<int> distancePassed = new HashSet<int>();//Static list to keep check on every 1000 meters passed.
        private static readonly object distancePassedObject = new object();//Lock access to distancePassed-data

        private readonly Happenings happenings; //Generating happenings during races

        public Car(string name)
        {
            Name = name;
            happenings = new Happenings();
        }

        public async Task StartRace()//Async method for race-logic
        {
            DateTime raceTime = DateTime.Now;//DateTime to keep track on time between happenings
            while (Distance < 5000)//Lenght of race
            {
                lock (lockObject)
                {
                    Distance += (Speed * 1000 / 3600); //Convert speed to meters per second
                }

                int kilometer = (int)(Distance / 1000) * 1000;

                if (kilometer >= 1000 && kilometer <= 4000 && kilometer % 1000 == 0)//Function for checkpoints
                {
                    lock (distancePassedObject)
                    {
                        if (!distancePassed.Contains(kilometer))
                        {
                            Console.WriteLine($"{Name} är först att passera {kilometer}m!");
                            distancePassed.Add(kilometer);
                        }
                    }
                }

                if ((DateTime.Now - raceTime).TotalSeconds >= 10)//Keep track on 10 sec intervall
                {
                    string happening = await happenings.RaceHappening(this);//Get happenings
                    if (!string.IsNullOrWhiteSpace(happening))
                    {
                        Console.WriteLine($"Oj oj oj! Nu fick {Name} {happening}");
                    }
                    
                    raceTime = DateTime.Now;
                }

                await Task.Delay(1000);
            }
            Finished = true;
            Console.WriteLine($"{Name} har gått i mål!!");//Create "finish line"
        }
        public object GetLockObject()//Create method for returning lockObject
        {
            return lockObject;
        }
        public string Status()//Show exact status for each car
        {
            lock (GetLockObject())
            {
                return $"{Name}: {Distance} m, {Speed} km/h.";
            }
        }
    }
}