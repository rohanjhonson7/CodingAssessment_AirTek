using CodingAssessmentConsoleApp.Services;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace SpeedyAir
{
    class Program
    {
        static void Main(string[] args)
        {

            CommonDataAccess commonDataAccess = new CommonDataAccess();

            // Created flight schedule for for 2 days - static values as given in document.
            List<Flight> flights = new List<Flight>
            {
                new Flight("Flight 1", "YUL", "YYZ", 20,1),
                new Flight("Flight 2", "YUL", "YYC", 20,1),
                new Flight("Flight 3", "YUL", "YVR", 20,1),
                new Flight("Flight 4", "YUL", "YYZ", 20,2),
                new Flight("Flight 5", "YUL", "YYC", 20,2),
                new Flight("Flight 6", "YUL", "YVR", 20,2)
            };

            //Read JSON data from given coding-assigment-orders.json
            JObject orders;
            orders = ReadJSON();


            // Create lists of orders for each destination
            var yyzOrders = new List<string>();
            var yycOrders = new List<string>();
            var yvrOrders = new List<string>();
            // Create list of combined orders
            var allOrders = new List<string>();

            // Sort orders by destination
            foreach (var order in orders)
            {
                string destination = (string)order.Value["destination"];
                allOrders.Add(order.Key);
                switch (destination)
                {
                    case "YYZ":
                        yyzOrders.Add(order.Key);
                        break;
                    case "YYC":
                        yycOrders.Add(order.Key);
                        break;
                    case "YVR":
                        yvrOrders.Add(order.Key);
                        break;
                    default:
                        Console.WriteLine("Invalid destination and order: " + destination + " " + order.Key);
                        break;
                }
            }

            // Load boxes onto flights
            commonDataAccess.LoadBoxes(flights[0], yyzOrders);
            commonDataAccess.LoadBoxes(flights[3], yyzOrders);
            commonDataAccess.LoadBoxes(flights[1], yycOrders);
            commonDataAccess.LoadBoxes(flights[4], yycOrders);
            commonDataAccess.LoadBoxes(flights[2], yvrOrders);
            commonDataAccess.LoadBoxes(flights[5], yvrOrders);

            // Print flight schedules with orders
            commonDataAccess.PrintFlightDetailsWithOrders(flights);

            Console.Write("----------------------------------------------------------------------------------------------------------------------------\n");

            //Can schedule the flight through input
            List<Flight> flightsList = commonDataAccess.LoadTheFlightsThroughInput();

            // output loaded flight schedule
            int flightScheduled = flightsList.Count;
            Console.WriteLine("-----------------------User story 1 output:-----------------------\n\n");
            foreach (Flight flightlist in flightsList)
            {
                commonDataAccess.PrintScheduledFlights(flightlist.Name, flightlist.Departure, flightlist.Arrival, flightlist.Day);
            }
            Console.WriteLine("-----------------------User story 2 output:-----------------------\n\n");
            foreach (Flight flightlist in flightsList)
            {
                commonDataAccess.LoadBoxesOnScheduledFlightBasedOnPriority(flightlist, allOrders, flightScheduled);
                flightScheduled--;
            }

            Console.Write("----------------------------------------------------------------------------------------------------------------------------\n");

            Console.Write("Press any key to exit");

        }


         public static JObject ReadJSON()
        {
            JObject orders = null;
            try
            {
                using (StreamReader r = new StreamReader("C:\\Users\\Marvin\\Downloads\\coding-assigment-orders.json"))
                {
                    string json = r.ReadToEnd();
                    orders = JObject.Parse(json);
                }
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
            return orders;
        }

    }
    
}
