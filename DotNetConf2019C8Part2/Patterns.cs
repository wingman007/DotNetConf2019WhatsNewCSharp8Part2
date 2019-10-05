using CommercialRegistration;
using ConsumerVechicleregistration;
using Liveryregistration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumerVechicleregistration
{
    public class Car
    {
        public int Passengers { get; set; }
    }
}

namespace CommercialRegistration
{
    public class DeliveryTruck
    {
        public int GrossWeightClass { get; set; }
    }
}

namespace Liveryregistration
{
    public class Taxi
    {
        public int Fares { get; set; }
    }

    public class Buss
    {
        public int Capacity { get; set; }
        public int Riders { get; set; }
    }
}

namespace DotNetConf2019C8Part2
{
    class Patterns
    {
        public static void Demo()
        {
            var soloDriver = new Car(); // you have to add using statement
            var twoRideShare = new Car() { Passengers = 1 };
            var threeRideShare = new Car { Passengers = 2 };
            var fullVan = new Car { Passengers = 5 };
            var emtyTaxi = new Taxi(); // add using statement
            var singleFare = new Taxi() { Fares = 1 };
            var doubleFare = new Taxi() { Fares = 2 };
            var fullVanPoolFare = new Taxi { Fares = 5 };
            var lowOccupantBus = new Buss() { Capacity = 90, Riders = 15 };
            var normalBus = new Buss() { Capacity = 90, Riders = 75 };
            var fullBus = new Buss() { Capacity = 90, Riders = 85 };

            var heavyTruck = new DeliveryTruck() { GrossWeightClass = 7500 };
            var truck = new DeliveryTruck() { GrossWeightClass = 4000 };
            var lightTruck = new DeliveryTruck() { GrossWeightClass = 2500 };

            Console.WriteLine($"The toll for single driver is {CalculateToll(soloDriver)}");


        }

        // Pattern magic
        private static decimal CalculateToll(object vechicle) =>
            vechicle switch
            { // we are lookiung not  only the type but some properties of the type
                Car { Passengers: 3 } => 1.00m,
                Car { Passengers: 2} => 1.50m, // if the car has 2 passengers
                Car _ => 2.00m, // if it is car default any car
                Taxi _ => 3.5m,
                Buss _ => 5.00m,
                DeliveryTruck _ => 10.00m,
                { } => throw new ArgumentException(message: "Not a known vechicle type", paramName: "sfsdf"), // totaly different type
                null => throw new ArgumentNullException(nameof(vechicle))
            };

        // Cars with 2 passengers get 0.5 discount
        // cars with 3 or more get 1.0 discount

        #region Advanced
        private static bool IsWeekDay(DateTime timeOfToll) =>
            timeOfToll.DayOfWeek switch // simplify
            {
                DayOfWeek.Monday => true,
                DayOfWeek.Tuesday => true,
                DayOfWeek.Wednesday => true,
                DayOfWeek.Thursday => true,
                DayOfWeek.Friday => true,
                DayOfWeek.Saturday => false,
                DayOfWeek.Sunday => false,
                _ => throw new Exception("Never here")
            };

        // we can do the same even better
        //private static bool IsWeekDay(DateTime timeOfToll) =>
        //    timeOfToll.DayOfWeek switch // simplify
        //    {
        //        DayOfWeek.Saturday => false,
        //        DayOfWeek.Sunday => false,
        //        _ => true // general rule
        //    };

        private enum TimeBand
        {
            MorningRush,
            Daytime,
            EveningRush,
            Overnight
        }

        private static TimeBand GetTimeBand(DateTime timeOfToll)
        {
            int hour = timeOfToll.Hour;
            if (hour < 6) return TimeBand.Overnight;
            else if (hour < 10) return TimeBand.MorningRush;
            else if (hour < 16) return TimeBand.Daytime;
            else if (hour < 20) return TimeBand.EveningRush;
            else return TimeBand.Overnight;
        }

        public decimal PeakTimePremium(DateTime timeOfToll, bool inbound) =>
            (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
            {
                (true, TimeBand.Overnight, _) => 0.75m, // tuple of 3 variables
                (true, TimeBand.Daytime, _) => 1.5m,
                (true, TimeBand.MorningRush, true) => 2.0m,
                (true, TimeBand.EveningRush, false) => 2.0m,
                (_, _, _) => 1.0m,
            };
        #endregion
    }
}
