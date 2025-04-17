using SUT24_Johan_Hansson_Labb2_ThreadsAndAsync.Models;

namespace SUT24_Johan_Hansson_Labb2_ThreadsAndAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var menu = new Menu(); //Create instans of Menu-class
            var cars = menu.CreateCars();//Call CreateCars to create list of cars

            var race = new Race(cars); //Create object of Race.
            await race.StartRace();    //Start race and wait til the whole race is done
        }
    }
}