using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogue
{
    public class VehicleCatalogue
    {
        public static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string input = Console.ReadLine();
            double truckHP = 0;
            double carHP = 0;

            while (input != "End")
            {
                List<string> commands = input.Split(' ').ToList();
                vehicles.Add(new Vehicle(commands[0].ToLower(), commands[1], commands[2], commands[3]));
                if (commands[0] == "truck")
                {
                    truckHP += double.Parse(commands[3]);
                }
                else
                {
                    carHP += double.Parse(commands[3]);
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            input = char.ToUpper(input[0]) + input.Substring(1).ToLower();

            while (input != "Close the catalogue")
            {
                vehicles.Find(x => x.model == input).Informator();
                input = Console.ReadLine();
                input = char.ToUpper(input[0]) + input.Substring(1).ToLower();
            }

            var trucks = vehicles.Where(x => x.type == "Truck");
            var trucksAvgHP = truckHP / trucks.Count();
            var cars = vehicles.Where(x => x.type == "Car");
            var carsAvgHP = carHP / cars.Count();

            Console.WriteLine($"Cars have average horsepower of: {(!Double.IsNaN(carsAvgHP) ? carsAvgHP : 0):F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {(!Double.IsNaN(trucksAvgHP) ? trucksAvgHP : 0):F2}.");
        }
    }

    public class Vehicle
    {
        public string type;
        public string model;
        public string color;
        public int horsePower;

        public Vehicle(string type, string model, string color, string horsePower)
        {
            this.type = char.ToUpper(type[0]) + type.Substring(1).ToLower();
            this.model = char.ToUpper(model[0]) + model.Substring(1).ToLower();
            this.color = color;
            this.horsePower = int.Parse(horsePower);
        }

        public void Informator()
        {
            Console.WriteLine($"Type: {type}");
            Console.WriteLine($"Model: {model}");
            Console.WriteLine($"Color: {color}");
            Console.WriteLine($"Horsepower: {horsePower}");
        }
    }

}
