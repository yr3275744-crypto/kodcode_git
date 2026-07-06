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
interface IScoreable { public int Score(); }
interface IImageOps 
{
    int Score();
    void Retask();
    void CalibrateThermal();
}
class SatelliteImage : IScoreable
{
    public int Id { get; }
    public double CloudCover { get; }
    public string? Sensor { get; }
    public SatelliteImage(int id, double cloudCover, string sensor)
    {
        if (cloudCover < 0 || cloudCover > 100)
        {
            throw new ArgumentException("Invalid cloud cover");
        }

        Id = id;
        CloudCover = cloudCover;
        Sensor = sensor;

    }
    public virtual int Score()
    {
        return 0 - (int)CloudCover;
    }
}

class SarImage : SatelliteImage, IImageOps
{
    public SarImage(int id, double cloudCover) : base(id, cloudCover, "SAR")
    {
    }
    public override int Score()
    {
        return 100 - (int)CloudCover;
    }
    public void CalibrateThermal()
    {
        throw new NotImplementedException();
    }
    public void Retask()
    {
        throw new NotImplementedException();
    }
}
class EoImage : SatelliteImage
{
    public EoImage(int id, double cloudCover) : base(id, cloudCover, "EO")
    {
    }
    public override int Score()
    {
        return 60 - (int)CloudCover;
    }
}
class IrImage : SatelliteImage
{
    public IrImage(int id, double cloudCover) : base(id, cloudCover, "IR")
    {
    }
    public override int Score()
    {
        return 40 - (int)CloudCover;
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
class QuickLookImage : SatelliteImage
{
    public QuickLookImage(int id, double cloudCover) : base(id, cloudCover, "QuickLookImage")
    {

    }
    public override int Score()
    {
        throw new InvalidOperationException("quick-look images are not scored");
    }
}
class Program
{
    static void Main()
    {
        try
        {
            Repository<SatelliteImage> images = new Repository<SatelliteImage>();
            images.Add(new SarImage(1, 55));
            images.Add(new EoImage(2, 10));
            images.Add(new IrImage(3, 700));
            images.Add(new QuickLookImage(4, 20));

            int scorsTotal = 0;
            foreach (SatelliteImage image in images.GetAll())
            {
                scorsTotal += image.Score();
                Console.WriteLine(image.Score());
            }
            Console.WriteLine($"{scorsTotal}");
        }
        catch
        {

        }

    }
}