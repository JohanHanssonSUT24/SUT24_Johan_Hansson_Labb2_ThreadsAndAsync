using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT24_Johan_Hansson_Labb2_ThreadsAndAsync.Models
{
    public class Car
    {
        public string Name { get;}
        public double Distance { get; set; } = 0;
        public double Speed { get; set; } = 120;
        public bool Finished { get; set; } = false;

        private static readonly Random random = new Random();
        private readonly object lockObject = new object();

        private readonly Happenings happenings;

        public Car(string name)
        {
            Name = name;
            happenings = new Happenings();
        }

        public void StartRace()
        {
            Console.WriteLine($"Bilarna är iväg! Väldigt jämt mellan {Name}");

            DateTime raceTime = DateTime.Now;
            while(Distance < 5000)//***
            {
                lock (lockObject)
                {
                    Distance += (Speed * 1000 / 3600);
                }

                if((DateTime.Now - raceTime).TotalSeconds >= 10)
                {
                    int happening = happenings.RaceHappening();
                    Console.WriteLine($"Oj oj oj! Nu fick {Name} för {happening}");
                    raceTime = DateTime.Now;
                }

                Thread.Sleep(1000);
            }
            Finished = true;
            Console.WriteLine($"{Name} har gått i mål!!");
        }
        public object GetLockObject()
        {
            return lockObject;
        }
    }
}
    
