using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUT24_Johan_Hansson_Labb2_ThreadsAndAsync.Models
{
    internal class Menu
    {   //Menu to choose how many cars and give them names
        public List<Car> CreateCars()
        {
            var cars = new List<Car>();
            int numberOfCars = 0;

            Console.WriteLine("Nu kör vi!!");
            while (numberOfCars < 2)
            {
                Console.WriteLine("Hur många bilar vill du ska tävla mot varandra? Ange minst 2: ");
                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out numberOfCars) && numberOfCars >= 2)
                    break;
                Console.WriteLine("Du måste ange minst två bilar");
            }
            Console.WriteLine("Antal bilar valda: " + numberOfCars);
            for (int i = 1; i <= numberOfCars; i++)
            {
                Console.WriteLine($"Ange namn på bil nr {i}: ");
                string carName = Console.ReadLine();

                Console.WriteLine($"Skapar bil: {carName}");

                cars.Add(new Car(carName));
            }
            return cars;
        }
        public async Task StartRace() //Method to be able to start race from menu-class
        {
            var cars = CreateCars();
            var race = new Race(cars);
            await race.StartRace(); //Start async race
        }
    }
}