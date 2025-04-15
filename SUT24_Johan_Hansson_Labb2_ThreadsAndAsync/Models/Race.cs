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
        private List<Thread> threads = new List<Thread>();
        private bool raceCompleted = false;

        public Race(List<Car> cars)
        {
            this.cars = cars;
        }

        public void StartRace()
        {

        }
    }
}
