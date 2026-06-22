using System;
namespace FilterManagementConsole;

class FleetManagment
{
    static bool AddTrack(List<int> tracks,List<double> speeds, List<double> headings, int id, double speed,double heading)
    {
        tracks.Add(id);
        speeds.Add(speed);
        headings.Add(heading);
        return true;
    }

    static bool RemoveTrack(List<int> tracks, List<double> speeds, List<double> headings, int id)
    {
        bool IsRemoved = false;
        for(int i = 0; i < tracks.Count; i ++)
        {
            if (tracks[i] == id)
            {
                tracks.Remove(id);
                speeds.Remove(speeds[i]);
                headings.Remove(headings[i]);
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
        for(int i = 0; i < tracks.Count; i ++)
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
        for (int i = 0; i < tracks.Count; i ++)
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
        for(int i = 0; i < tracks.Count; i ++)
        {
            if (speeds[i] >= speed)
            {
                filteredList.Add(tracks[i]);
            }
        }
        return filteredList;
    }

    //static void FilterTracks(List<int> FilteredTracks)
    //{ }

    //static string SummarizeTrack()
    //{ }

    //static void SummarizeTrack(string summary)
    //{ }

    //static void PrintMenu()
    //{ }

    //static void PlayAction(int choice)
    //{ }

    static void Main()
    {
        List<int> tracks = new List<int>();

        List<double> speeds = new List<double>();

        List<double> headings = new List<double>();
        
        AddTrack(tracks, speeds, headings, 1, 100, 90);
        Console.WriteLine("success");
        AddTrack(tracks, speeds, headings, 2, 200, 90);
        Console.WriteLine("success");
        
        string success = FindTrack(tracks, speeds, headings, 1);
        FindTrack(success);

        ListAllTracks(tracks, speeds, headings);

        List<int> filtered = FilterTracks(tracks, speeds, 105);
        foreach(int val in filtered)
        {
            Console.WriteLine(val);
        }
    }

}
