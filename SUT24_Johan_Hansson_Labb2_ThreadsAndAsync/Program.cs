using SUT24_Johan_Hansson_Labb2_ThreadsAndAsync.Models;

namespace SUT24_Johan_Hansson_Labb2_ThreadsAndAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var menu = new Menu();
            var cars = menu.CreateCars();

            var race = new Race(cars);
            await race.StartRace();
        }
    }
}