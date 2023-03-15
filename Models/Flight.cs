public class Flight
{
    public string Name { get; set; }
    public string Departure { get; set; }
    public string Arrival { get; set; }
    public int Capacity { get; set; }
    public int Day { get; set; }
    public List<string> Boxes { get; set; }

    public Flight(string name, string departure, string arrival, int capacity, int day)
    {
        Name = name;
        Departure = departure;
        Arrival = arrival;
        Capacity = capacity;
        Boxes = new List<string>();
        Day = day;
    }

    public override string ToString()
    {
        string output = Name + " (" + Departure + " to " + Arrival + "): ";
        if (Boxes.Count > 0)
        {
            foreach (var box in Boxes)
            {
                output += box.ToString() + ", ";
            }
            output = output.TrimEnd(',', ' ');
        }
        else
        {
            output += "No boxes loaded";
        }
        return output;
    }
}