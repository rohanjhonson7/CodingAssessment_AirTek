using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssessmentConsoleApp.Services
{
    public interface ICommon
    {
        public void LoadBoxes(Flight flight, List<string> orders);
        public void PrintFlightDetailsWithOrders(List<Flight> flights);
        public void PrintFlightOrders(Flight flight, string order, bool isScheduled);

        public void PrintScheduledFlights(string name, string Departure, string Arrival, int day );

        public void LoadBoxesOnScheduledFlightBasedOnPriority(Flight flight, List<String> orders, int flightCount);
        public List<Flight> LoadTheFlightsThroughInput();
    }
}
