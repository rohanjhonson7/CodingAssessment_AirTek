using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssessmentConsoleApp.Services
{
    public class CommonDataAccess : ICommon
    {
        public void LoadBoxes(Flight flight, List<string> orders)
        {
            int boxesLoaded = 0;
            int initialOrderCount = orders.Count;
            for (int i = 0; i < initialOrderCount; i++)
            {
                if (boxesLoaded < flight.Capacity)
                {
                    flight.Boxes.Add(orders[0].ToString());
                    boxesLoaded++;
                    orders.Remove(orders[0].ToString());
                }
                else
                {
                    break;
                }
            }
        }

        public void LoadBoxesOnScheduledFlightBasedOnPriority(Flight flight, List<String> orders, int flightCount)
        {
            int boxesLoaded = 0;
            int initialOrderCount = orders.Count;
            for (int i = 0; i < initialOrderCount; i++)
            {
                if (boxesLoaded < flight.Capacity)
                {
                    flight.Boxes.Add(orders[0]);
                    boxesLoaded++;
                    // Print flight schedules with orders for given input of flights 
                    PrintFlightOrders(flight, orders[0], true);
                    //Remove order which is already scheduled
                    orders.Remove(orders[0]);
                }
                else if(flightCount==1) // to track the non-scheduled flights and orders. 
                {
                    PrintFlightOrders(flight, orders[0], false);
                    orders.Remove(orders[0]);
                }
                else
                { 
                    break; 
                }
            }
        }

        public List<Flight> LoadTheFlightsThroughInput()
        {
            List<Flight> flightsList = new List<Flight>();
            try
            {
                Console.Write("Please Enter the number of flights you want to schedule: ");

                int flightCount = int.Parse(Console.ReadLine());


                // get input for flight schedule
                for (int i = 1; i <= flightCount; i++)
                {
                    Console.WriteLine("Enter details for Flight " + i + ":");
                    Console.Write("Departure city: ");
                    string departure = Console.ReadLine();
                    Console.Write("Arrival city: ");
                    string arrival = Console.ReadLine();
                    Console.Write("Day: ");
                    int day = int.Parse(Console.ReadLine());

                    flightsList.Add(new Flight(i.ToString(), departure, arrival, 20, day));
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return flightsList;
        }

        public void PrintFlightDetailsWithOrders(List<Flight> flights)
        {
            Console.Write("-----------------------------------Scheduled flight details with Orders-----------------------------------------------------\n");
            foreach (Flight flight in flights)
            {
                Console.WriteLine(flight.ToString());
            }
        }

        public void PrintFlightOrders(Flight flight, string order, bool isScheduled)
        {
            Console.Write("----------------------------------------------------------------------------------------------------------------------------\n");
            if (isScheduled)
            {
                Console.WriteLine($"order: {order}, flightNumber: {flight.Name}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
            }
            else
            {
                Console.WriteLine($"order: {order}, flightNumber: not scheduled");
            }

        }

        public void PrintScheduledFlights(string name, string Departure, string Arrival, int day)
        {
            Console.WriteLine("Flight: " + name + ", departure: " + Departure + ", arrival: " + Arrival + ", day: " + day + "\n\n");
        }
    }
}
