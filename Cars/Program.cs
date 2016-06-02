using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = LoadCarsFromFile("fuel.csv");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Name}:{car.City}");
            }
        }

        private static List<Car> LoadCarsFromFile(string path)
        {
            return
                File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(line =>
                {
                    var columns = line.Split(',');
                    var car = new Car
                    {
                        Year = int.Parse(columns[0]),
                        Manufacturer = columns[1],
                        Name = columns[2],
                        Displacement = double.Parse(columns[3]),
                        Cylinders = int.Parse(columns[4]),
                        City = int.Parse(columns[5]),
                        Highway = int.Parse(columns[6]),
                        Combined = int.Parse(columns[7])
                    };
                    return car;
                }).ToList();
        }
    }
}
