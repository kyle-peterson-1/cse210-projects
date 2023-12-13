//Program 3: Inheritance with Event Planning

using System;

class Program
{
    static void Main()
    {
        LectureEvent lectureEvent = new LectureEvent("Lecture Title", "Educational lecture", "2023-12-15", "14:00", "123 Main St", "City1", "State1", "USA", "John Doe", 50);

        ReceptionEvent receptionEvent = new ReceptionEvent("Reception Title", "Networking reception", "2023-12-20", "18:30", "456 Oak St", "City2", "State2", "Canada", "rsvp@example.com");

        OutdoorGatheringEvent outdoorEvent = new OutdoorGatheringEvent("Outdoor Gathering Title", "Community picnic", "2023-12-25", "12:00", "789 Pine St", "City3", "State3", "USA", "Sunny");

        Console.WriteLine("Standard Details:");
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine();

        Console.WriteLine("Full Details:");
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine();

        Console.WriteLine("Short Description:");
        Console.WriteLine(lectureEvent.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Standard Details:");
        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine();

        Console.WriteLine("Full Details:");
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine();

        Console.WriteLine("Short Description:");
        Console.WriteLine(receptionEvent.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Standard Details:");
        Console.WriteLine(outdoorEvent.GetStandardDetails());
        Console.WriteLine();

        Console.WriteLine("Full Details:");
        Console.WriteLine(outdoorEvent.GetFullDetails());
        Console.WriteLine();

        Console.WriteLine("Short Description:");
        Console.WriteLine(outdoorEvent.GetShortDescription());
    }
}

class Event
{
    private readonly string title;
    private readonly string description;
    private readonly string date;
    private readonly string time;
    private readonly Address address;

    public Event(string title, string description, string date, string time, string streetAddress, string city, string stateProvince, string country)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = new Address(streetAddress, city, stateProvince, country);
    }

    public string GetStandardDetails()
    {
        return $"Title: {title}{Environment.NewLine}Description: {description}{Environment.NewLine}Date: {date}{Environment.NewLine}Time: {time}{Environment.NewLine}Address: {address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Type: {GetType().Name}{Environment.NewLine}Title: {title}{Environment.NewLine}Date: {date}";
    }
}

class LectureEvent : Event
{
    private readonly string speaker;
    private readonly int capacity;

    public LectureEvent(string title, string description, string date, string time, string streetAddress, string city, string stateProvince, string country, string speaker, int capacity)
        : base(title, description, date, time, streetAddress, city, stateProvince, country)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}{Environment.NewLine}Speaker: {speaker}{Environment.NewLine}Capacity: {capacity}";
    }
}

class ReceptionEvent : Event
{
    private readonly string rsvpEmail;

    public ReceptionEvent(string title, string description, string date, string time, string streetAddress, string city, string stateProvince, string country, string rsvpEmail)
        : base(title, description, date, time, streetAddress, city, stateProvince, country)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}{Environment.NewLine}RSVP Email: {rsvpEmail}";
    }
}

class OutdoorGatheringEvent : Event
{
    private readonly string weatherForecast;

    public OutdoorGatheringEvent(string title, string description, string date, string time, string streetAddress, string city, string stateProvince, string country, string weatherForecast)
        : base(title, description, date, time, streetAddress, city, stateProvince, country)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}{Environment.NewLine}Weather Forecast: {weatherForecast}";
    }
}

class Address
{
    private readonly string streetAddress;
    private readonly string city;
    private readonly string stateProvince;
    private readonly string country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{streetAddress}, {city}, {stateProvince}, {country}";
    }
}
