using System;
using System.Xml.Linq;

namespace DynamicXml
{
    class Program
    {
        static void Main()
        {
            dynamic planets = DynamicXElement.Create(XElement.Load("Planets.xml"));
            var mercury = planets.Planet;
            var venus = planets["Planet", 1];
            var ourMoon = planets["Planet", 2].Moons.Moon;
            var marsMoon = planets["Planet", 3]["Moons", 0].Moon;

            Console.WriteLine(mercury);
            Console.WriteLine(venus);
            Console.WriteLine(ourMoon);
            Console.WriteLine(marsMoon);
        }
    }
}
