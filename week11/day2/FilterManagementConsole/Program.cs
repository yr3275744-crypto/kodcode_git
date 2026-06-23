using System;
namespace FilterManagementConsole;

class FleetManagment
{
    static bool AddTrack(List<int> tracks, List<double> speeds, List<double> headings, int id, double speed, double heading)
    {
        tracks.Add(id);
        speeds.Add(speed);
        headings.Add(heading);
        return true;
    }

    static bool RemoveTrack(List<int> tracks, List<double> speeds, List<double> headings, int id)
    {
        bool IsRemoved = false;
        for (int i = 0; i < tracks.Count; i++)
        {
            if (tracks[i] == id)
            {
                tracks.RemoveAt(i);
                speeds.RemoveAt(i);
                headings.RemoveAt(i);
                IsRemoved = true;
            }
        }
        return IsRemoved;
    }

    static string FindTrack(List<int> tracks, List<double> speeds, List<double> headings, int id)
    {
        //bool isFound = false;
        //double speed;
        //double heading;
        for (int i = 0; i < tracks.Count; i++)
        {
            if (tracks[i] == id)
            {
                double speed = speeds[i];
                double heading = headings[i];
                return $"id: {id}\nspeed: {speed}\nheading: {heading}";
            }
        }
        return "Track did not found";
    }

    static void FindTrack(string Track)
    {
        Console.WriteLine(Track);
    }

    static void ListAllTracks(List<int> tracks, List<double> speeds, List<double> headings)
    {
        Console.WriteLine("===");
        for (int i = 0; i < tracks.Count; i++)
        {
            int id = tracks[i];
            double speed = speeds[i];
            double heading = headings[i];
            Console.WriteLine($"id: {id}\nspeed: {speed}\nheading: {heading}\n");
        }
    }

    static List<int> FilterTracks(List<int> tracks, List<double> speeds, double speed)
    {
        List<int> filteredList = new List<int>();
        for (int i = 0; i < tracks.Count; i++)
        {
            if (speeds[i] >= speed)
            {
                filteredList.Add(tracks[i]);
            }
        }
        return filteredList;
    }

    static void FilterTracks(List<int> filteredTracks)
    {
        Console.WriteLine("Tracks with speed above the requested speed: ");
        foreach (int val in filteredTracks)
        {
            Console.WriteLine(val);
        }
    }

    static string SummarizeTrack(List<int> tracks, List<double> speeds)
    {
        int count = 0;
        double averageSpeed = 0;
        double fastedSpeed = 0;
        int fastedSpeedIndex = 0;
        double sum = 0;

        if (tracks.Count == 0)
        {
            return "No tracks.";
        }

        for (int i = 0; i < tracks.Count; i++)
        {
            count = count + 1;
            sum = sum + speeds[i];
            if (speeds[i] > fastedSpeed)
            {
                fastedSpeedIndex = i;
            }
        }
        averageSpeed = sum / count;
        return $"Tracks: {count}\naverage speed: {averageSpeed}\nThe fastest track: {tracks[fastedSpeedIndex]}";
    }

    static void SummarizeTrack(string summary)
    {
        Console.WriteLine($"Summary:\n{summary}");
    }

    static void PrintMenu()
    {
        Console.WriteLine("=== Filter Management Console ===\n" +
            "1.Add a track\n" +
            "2.Remove a track\n" +
            "3.Find track by id\n" +
            "4.Get all tracks\n" +
            "5.Filter the tracks by minimum speed\n" +
            "6.Get Summary\n" +
            "7.Exit: ");
    }


    static int GetActionNumber()
    {
        string? choice = Console.ReadLine();
        if (int.TryParse(choice, out int intChoice))
        {
            if (intChoice >= 1 && intChoice <= 7)
            {
                return intChoice;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    static int? GetId()
    {
        Console.WriteLine("Enter id: ");
        string? stringId = Console.ReadLine();
        if (int.TryParse(stringId, out int id))
        {
            int? nullableId = id;
            return nullableId;
        }    
        else
        {
            return null;
        }
    }

    static double GetSpeed()
    {
        Console.WriteLine("Enter speed: ");
        string? stringId = Console.ReadLine();
        if (double.TryParse(stringId, out double speed))
        {
            double? nullableSpeed = speed;
            return nullableSpeed;
        }
        else
        {
            return null;
        }
    }


    static double? GetHeading()
    {
        Console.WriteLine("Enter heading: ");
        string? stringId = Console.ReadLine();
        if (double.TryParse(stringId, out double heading))
        {
            double? nullableHeading = heading;
            return nullableHeading;
        }
        else
        {
            return null;
        }
    }

    static string AddTrackHandle(List<int> tracks, List<double> speeds, List<double> headings)
    {
        int id = GetId();
        if (id is null)
        { return "ID must br an integer."; }

        double speed = GetSpeed();
        if (speed is null)
        { return "Speed must be a number."; }

        double heading = GetHeading();
        if (heading is null)
        { return "Heading must be a number."; }

        int intId = id;
        double doubleSpeed = speed;
        double doubleHeading = heading;

        bool isAdded = AddTrack(tracks, speeds, headings, intId, doubleSpeed, doubleHeading);
        if (isAdded)
        { return "The track is added successfully!"; }
    }


    static string PlayAction(int choice, List<int> tracks, List<double> speeds, List<double> headings)
    {
        switch (choice)
        { 
            case 1:
                return AddTrackHandle(tracks, speeds, headings);
            case 2:
                int? id = GetId();
                if (id is null)
                { return "ID must be a number"; }
                int intId = id;
                isDeleted = RemoveTrack(tracks, speeds, headings, intId);
                return RemoveTrack(isDeleted);
            
            case 3:
                int? id = GetId();
                if (id is null)
                { return "ID must be a number"; }
                int intId = id;
                return FindTrack(tracks, speeds, headings, intId);
            
            case 4:
                ListAllTracks();
                return null;
            
            case 5:
                double? speed = GetSpeed();
                if (speed is null)
                { return "speed must be a number"; }

                double doubleSpeed = speed;
                list<int> filterd = FilterTracks(tracks, speeds, headings, doubleSpeed);
                FilterTracks(filterd);
                return null;
            
            case 6:
                return SummarizeTrack(tracks, speeds);
            
            case 7:
                return "exit";


        }
    }

    static void Main()
    {
        List<int> tracks = new List<int>();

        List<double> speeds = new List<double>();

        List<double> headings = new List<double>();
        
        AddTrack(tracks, speeds, headings, 1, 100, 90);
        Console.WriteLine("success");
        AddTrack(tracks, speeds, headings, 2, 200, 90);
        Console.WriteLine("success");
        
        AddTrack(tracks, speeds, headings, 3, 250, 180);
        Console.WriteLine("success");

        string success = FindTrack(tracks, speeds, headings, 2);
        FindTrack(success);

        ListAllTracks(tracks, speeds, headings);

        List<int> filtered = FilterTracks(tracks, speeds, 105);
        
        FilterTracks(filtered);

        string summary = SummarizeTrack(tracks, speeds);
        SummarizeTrack(summary);

        bool isRemoved = RemoveTrack(tracks, speeds, headings, 2);
        
        string uu = FindTrack(tracks, speeds, headings, 2);
        FindTrack(uu);

        PrintMenu();

        int? action = GetActionNumber();
        if (action is null)
        {
            Console.WriteLine("Invalid choice");
        }
        else
        {
            string? message = PlayAction(action);
        }


    }

}
