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


        private static readonly Random random = new Random();
        private readonly object lockObject = new object();
        private static readonly HashSet<int> distancePassed = new HashSet<int>();
        private static readonly object distancePassedObject = new object();

        private readonly Happenings happenings;

        public Car(string name)
        {
            Name = name;
            happenings = new Happenings();
        }

        public async Task StartRace()
        {
            DateTime raceTime = DateTime.Now;
            while (Distance < 5000)//***
            {
                lock (lockObject)
                {
                    Distance += (Speed * 1000 / 3600);
                }

                int kilometer = (int)(Distance / 1000) * 1000;

                if (kilometer >= 1000 && kilometer <= 4000 && kilometer % 1000 == 0)
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

                if ((DateTime.Now - raceTime).TotalSeconds >= 10)
                {
                    string happening = await happenings.RaceHappening(this);
                    if (!string.IsNullOrWhiteSpace(happening))
                    {
                        Console.WriteLine($"Oj oj oj! Nu fick {Name} {happening}");
                    }
                    
                    raceTime = DateTime.Now;
                }

                await Task.Delay(1000);
            }
            Finished = true;
            Console.WriteLine($"{Name} har gått i mål!!");
        }
        public object GetLockObject()
        {
            return lockObject;
        }
        public string Status()
        {
            lock (GetLockObject())
            {
                return $"{Name}: {Distance} m, {Speed} km/h.";
            }
        }
    }
}