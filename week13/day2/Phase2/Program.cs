using static System.Net.Mime.MediaTypeNames;

namespace ImageMetadataManager2;

class Repository<T>
{
    private readonly List<T> _items = new List<T>();
    public void Add(T item)
    {
        _items.Add(item);
    }
    public T Get(int i)
    {
        return _items[i];
    }
    public int Count()
    {
        return _items.Count();
    }
    public List<T> GetAll()
    {
        return _items;
    }
}
interface IScoreable { public int CalculateScore(); }
interface IRetaskable { void Retask(); }
interface ICalibaratedable { void CalibrateThermal(); }
class SatelliteImage : IScoreable
{
    public int Id { get; }
    public double CloudCover { get; }
    public string? Sensor { get; }
    public int Score { get; }
    public SatelliteImage(int id, double cloudCover, string sensor)
    {
        if (cloudCover < 0 || cloudCover > 100)
        {
            throw new ArgumentException("Invalid cloud cover");
        }

        Id = id;
        CloudCover = cloudCover;
        Sensor = sensor;
        Score = CalculateScore();
    }
    public virtual int CalculateScore()
    {
        return 0 - (int)CloudCover;
    }
}

class SarImage : SatelliteImage
{
    public SarImage(int id, double cloudCover) : base(id, cloudCover, "SAR")
    {
    }
    public override int CalculateScore()
    {
        return 100 - (int)CloudCover;
    }
}
class EoImage : SatelliteImage
{
    public EoImage(int id, double cloudCover) : base(id, cloudCover, "EO")
    {
    }
    public override int CalculateScore()
    {
        return 60 - (int)CloudCover;
    }
}
class IrImage : SatelliteImage
{
    public IrImage(int id, double cloudCover) : base(id, cloudCover, "IR")
    {
    }
    public override int CalculateScore()
    {
        return 40 - (int)CloudCover;
    }
}
class QuickLookImage : SatelliteImage
{
    public QuickLookImage(int id, double cloudCover) : base(id, cloudCover, "QuickLookImage")
    {
    }
}
class ImageFormatter
{
    public string ToImageFormat(SatelliteImage image)
    {
        return $"Image {image.Id}: {image.CloudCover}% cloud {image.Sensor}";
    }
}
class ImageStore
{
    public void StorToFile(string path, ImageFormatter formatter, SatelliteImage image)
    {
        System.IO.File.WriteAllText(path, formatter.ToImageFormat(image));
    }
}
class Program
{
    static void Main()
    {
        Repository<SatelliteImage> images = new Repository<SatelliteImage>();
        try
        {
            images.Add(new SarImage(1, 55));
            images.Add(new EoImage(2, 10));
            images.Add(new IrImage(3, 105));
            images.Add(new QuickLookImage(4, 20));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {

            int scorsTotal = 0;
            foreach (SatelliteImage image in images.GetAll())
            {
                scorsTotal += image.Score;
                Console.WriteLine(image.Score);
            }
            Console.WriteLine($"{scorsTotal}");
        }

    }
}