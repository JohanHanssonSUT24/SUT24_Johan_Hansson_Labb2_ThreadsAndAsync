using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT24_Johan_Hansson_Labb2_ThreadsAndAsync.Models
{
    public class Happenings
    {
        private static readonly Random random = new Random();
        public async Task<string> RaceHappening(Car car)
        {
            int happening = random.Next(1, 51);
            string description = "";

            if (happening == 1)
            {
                description = "slut på bensin. Depåstoppet kommer kosta 15 sekunder";
                //Console.WriteLine($"Nu fick {car.Name} {description}");
                await Task.Delay(15000);
            }
            else if (happening <= 3)
            {
                description = "Ett däck exploderade! Men teamet är snabbt och löser detta på 10 sekunder.";
                //Console.WriteLine($"{car.Name} har lite problem. {description}");
                await Task.Delay(10000);
            }
            else if (happening <= 8)
            {
                description = "En fågel har flugit in i rutan! Hoppas den inte skadade sig men det blir 5 dyra sekunders tillägg.";
                //Console.WriteLine($"Vad händer med {car.Name}? {description}");
                await Task.Delay(5000);
            }
            else if (happening <= 18)
            {
                car.Speed = Math.Max(car.Speed - 1, 1);
                description = $"Motorn krånglar så hastigheten har gått ner till {car.Speed} km/h.";
                //Console.WriteLine($"{car.Name} har problem där ute. {description}");
            }
           
                return description;
        }

    }
}