using System.IO;
namespace ImageMetadataManager;

class ImageMetadataManager
{
    public int Id { get; set; }
    public double CloudCover { get; set; }
    public string? Sensor { get; set; }
    public ImageMetadataManager(int id, double cloudCover, string sensor)
    {
        Id = id;
        CloudCover = cloudCover;
        Sensor = sensor;
    }
    public bool IsValid()
    {
        if (0 <= CloudCover && CloudCover <= 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public string Format()
    {
        return $"Image {Id}: {CloudCover}% cloud {Sensor}.";
    }
    public void SaveToFile(string path)
    {
        System.IO.File.WriteAllText(path, Format());
    }
    public int Score()
    {
        switch(Sensor)
        {
            case ("SAR"):
                return 100 - (int)CloudCover;
            case ("EO"):
                return 60 - (int)CloudCover;
            case ("IR"):
                return 40 - (int)CloudCover;
            default:
                return 0 - (int)CloudCover;
        }
    }
}
class Program()
{
    static void Main()
    {
        ImageMetadataManager imageMetadataManager1 = new ImageMetadataManager(1, 10, "IR");
        ImageMetadataManager imageMetadataManager2 = new ImageMetadataManager(2, 150, "EO");
        ImageMetadataManager imageMetadataManager3 = new ImageMetadataManager(3, 25, "ioioio");

        Console.WriteLine(imageMetadataManager1.Format());
        Console.WriteLine(imageMetadataManager2.Format());
        Console.WriteLine(imageMetadataManager3.Format());
        //Console.WriteLine(imageMetadataManager3.IsValid());
        Console.WriteLine(imageMetadataManager1.Score());
        Console.WriteLine(imageMetadataManager2.Score());
        Console.WriteLine(imageMetadataManager3.Score());
        Console.WriteLine(imageMetadataManager1.Score()+
            imageMetadataManager2.Score() +
            imageMetadataManager3.Score());
    }
}