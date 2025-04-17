using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT24_Johan_Hansson_Labb2_ThreadsAndAsync.Models
{
    public class Happenings
    {
        private static readonly Random random = new Random();//Create a random number for happenings
        public async Task<string> RaceHappening(Car car)//Method for happenings for each car.
        {
            int happening = random.Next(1, 51);
            string description = "";

            if (happening == 1)//Add different happenings
            {
                description = "slut på bensin. Depåstoppet kommer kosta 15 sekunder";
                await Task.Delay(15000);
            }
            else if (happening <= 3)
            {
                description = "problem! Ett däck exploderade! Men teamet är snabba och löser detta på 10 sekunder.";
                await Task.Delay(10000);
            }
            else if (happening <= 8)
            {
                description = "en fågel i rutan! Hoppas den inte skadade sig men det blir 5 dyra sekunders tillägg.";
                await Task.Delay(5000);
            }
            else if (happening <= 18)
            {
                car.Speed = Math.Max(car.Speed - 1, 1);
                description = $"motorproblem så hastigheten har gått ner till {car.Speed} km/h.";
            }
            
                return description;//Return what happening affected the car
        }

    }
}