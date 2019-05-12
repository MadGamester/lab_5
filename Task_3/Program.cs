using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Plane
    {
        private String type;
        private int count;

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public void showInfo()
        {
            Console.WriteLine("    Type: "+ type + " | Count: " + count);  
        }
    }

    class Rocket
    {
        private String type;
        private int power;
        private int distance;
        private int count;

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public void showInfo()
        {
            Console.WriteLine("    Type: " + type + " | Power: " + power + " | Distance: " + distance + " | Count: " + count);
        }
    }

    class Ship
    {
        protected String name;
        protected String appointment;
        protected int waterSupply;
        protected int enginePower;
        protected String fuelType;



        public Ship()
        {
            this.name = "none";
            this.appointment = "none";
            this.waterSupply = 0;
            this.enginePower = 0;
            this.fuelType = "none";
        }

        public Ship(String name, String appointment, int waterSupply, int enginePower, String fuelType)
        {
            this.name = name;
            this.appointment = appointment;
            this.waterSupply = waterSupply;
            this.enginePower = enginePower;
            this.fuelType = fuelType;
        }

        protected void shipInfo()
        {
            Console.WriteLine(" Ship name: " + name);
            Console.WriteLine("  Appointment: " + appointment);
            Console.WriteLine("  Water Supply: " + waterSupply);
            Console.WriteLine("  Engine power: " + enginePower);
            Console.WriteLine("  Fuel type: " + fuelType);
        }
    }

    class AviaShip: Ship
    {
        public List<Plane> aviation;

        public AviaShip()
        {
            aviation = new List<Plane>();
        }

        public AviaShip(String name, String appointment, int waterSupply, int enginePower, String fuelType) : base(name, appointment, waterSupply, enginePower, fuelType)
        {
            aviation = new List<Plane>();
        }

        public void showShipInfo()
        {
            Console.WriteLine("< Avia ship >");

            shipInfo();

            Console.WriteLine("  Planes:");

           foreach(Plane plane in aviation)
            {
                plane.showInfo();
            }

            Console.WriteLine();
        }
    }

    class RocketShip: Ship
    {
        public List<Rocket> rockets;
        public bool atomBomb;

        public RocketShip()
        {
            rockets = new List<Rocket>();
        }

        public RocketShip(String name, String appointment, int waterSupply, int enginePower, String fuelType, bool atomBomb) : base(name, appointment, waterSupply, enginePower, fuelType)
        {
            rockets = new List<Rocket>();
            this.atomBomb = atomBomb;
        }

        public void showShipInfo()
        {
            Console.WriteLine("< Rocket ship >");
            shipInfo();

            Console.WriteLine("  Rockets:");

            foreach (Rocket rocket in rockets)
            {
                rocket.showInfo();
            }

            Console.WriteLine();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AviaShip avShip1 = new AviaShip();
            AviaShip avShip2 = new AviaShip("Tomak", "shot", 100000, 2000, "disel");

            Plane plane1 = new Plane();
            Plane plane2 = new Plane();

            plane1.Type = "React";
            plane1.Count = 150;

            plane2.Type = "Bombarder";
            plane2.Count = 20;

            avShip2.aviation.Add(plane1);
            avShip2.aviation.Add(plane2);


            RocketShip rkShip1 = new RocketShip();
            RocketShip rkShip2 = new RocketShip("Gasl", "space", 800000, 52000, "atom", true);

            Rocket rocket1 = new Rocket();
            Rocket rocket2 = new Rocket();

            rocket1.Type = "Hidrogen";
            rocket1.Distance = 1000;
            rocket1.Power = 100000;
            rocket1.Count = 200;

            rocket2.Type = "Atom";
            rocket2.Distance = 40000;
            rocket2.Power = 900000;
            rocket2.Count = 50;

            rkShip2.rockets.Add(rocket1);
            rkShip2.rockets.Add(rocket2);

            avShip2.showShipInfo();

            rkShip2.showShipInfo();


            Console.ReadKey();
        }
    }
}
