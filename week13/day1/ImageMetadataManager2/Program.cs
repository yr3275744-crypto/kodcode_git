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
class Image : IScoreable
{
    public int Id { get; }
    public double CloudCover { get; }
    public string? Sensor { get; }
    public Image(int id, double cloudCover, string sensor)
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

class SarImage : Image
{
    public SarImage(int id, double cloudCover) : base(id, cloudCover, "SAR")
    {
    }
    public override int Score()
    {
        return 100 - (int)CloudCover;
    }
}
class EoImage : Image
{
    public EoImage(int id, double cloudCover) : base(id, cloudCover, "EO")
    {
    }
    public override int Score()
    {
        return 60 - (int)CloudCover;
    }
}
class IrImage : Image
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
    public string ToImageFormat(Image image)
    {
        return $"Image {image.Id}: {image.CloudCover}% cloud {image.Sensor}";
    }
}
class ImageStore
{
    public void StorToFile(string path, ImageFormatter formatter, Image image)
    {
        System.IO.File.WriteAllText(path, formatter.ToImageFormat(image));
    }
}

class Program
{
    static void Main()
    {
        Repository<Image> images = new Repository<Image>();
        images.Add(new SarImage(1, 55));
        images.Add(new EoImage(2, 10));
        images.Add(new IrImage(3, 7));

        int scorsTotal = 0;
        foreach (Image image in images.GetAll())
        {
            scorsTotal += image.Score();
            Console.WriteLine(image.Score());
        }
        Console.WriteLine($"{scorsTotal}");
    }
}