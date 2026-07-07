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
interface ISave { public void Save(SatelliteImage img); int Count(); }
interface IFormater { public string ToImageFormat(SatelliteImage image); }
class SatelliteImage : IScoreable
{
    public int Id { get; }
    public double CloudCover { get; }
    public string? Sensor { get; }
    public int Score { get; set; }
    public SatelliteImage(int id, double cloudCover, string sensor)
    {
        if (cloudCover < 0 || cloudCover > 100)
        {
            throw new ArgumentException("Invalid cloud cover");
        }

        Id = id;
        CloudCover = cloudCover;
        Sensor = sensor;
        //Score = CalculateScore();
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
class ImageFormatter : IFormater
{
    public string ToImageFormat(SatelliteImage image)
    {
        return $"Image {image.Id}: {image.CloudCover}% cloud {image.Sensor}";
    }
}
class DiskStore : ISave
{
    private IFormater _formater;
    private int _count = 0;
    public int Count() { return _count; }
    public DiskStore(IFormater formater)
    {
        _formater = formater;
    }
    public void Save(SatelliteImage img)
    {
        System.IO.File.AppendAllText(@"output.txt", _formater.ToImageFormat(img));
        _count++;
    }
}
class MemoryStore : ISave
{
    Repository<string> images = new Repository<string>();
    private IFormater _formater;
    public MemoryStore(IFormater formater)
    {
        _formater = formater;
    }
    public void Save(SatelliteImage img)
    {
        images.Add(_formater.ToImageFormat(img));
    }
    public int Count()
    {
        return images.Count();
    }
}
class ImagePipeline
{
    ISave _store;
    public ISave Store { get => _store; }
    public ImagePipeline(ISave store)
    {
        _store = store;
    }
    public void ScorAndSave(List<SatelliteImage> images)
    {
        foreach (SatelliteImage image in images)
        {
            image.Score = image.CalculateScore();
            Store.Save(image);
        }
    }
}

class Program
{
    static void Main()
    {
        List<SatelliteImage> images = new List<SatelliteImage>();
        IFormater formater = new ImageFormatter();
        ISave stor = new MemoryStore(formater);
        ImagePipeline imagePipeline = new ImagePipeline(stor);
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
            imagePipeline.ScorAndSave(images);
            Console.WriteLine($"{imagePipeline.Store.Count()}");
        }

    }
}