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
        public async Task<int> RaceHappening(Car car)
        {
            int happening = random.Next(1, 51);

            if (happening == 1)
            {
                Console.WriteLine($"Nu fick {car.Name} slut på bensin. Depåstoppet kommer kosta 15 sekunder");
                await Task.Delay(15000);
            }
            else if (happening <= 3)
            {
                Console.WriteLine($"Ett däck exploderar för {car.Name}. Men teamet är snabba och löser detta på 10 sekunder.");
                await Task.Delay(15000);
            }
            else if (happening <= 8)
            {
                Console.WriteLine($"En fågel har flugit in i {car.Name}. Det kommer ta 5 sekunder att få rutan ren.");
                await Task.Delay(5000);
            }
            else if (happening <= 18)
            {
                car.Speed = Math.Max(car.Speed - 1, 1);
                Console.WriteLine($"{car.Name} har problem där ute. Motorn krånglar så hastigheten har gått ner till {car.Speed} km/h.");
            }
            return happening;
        }

    }
}