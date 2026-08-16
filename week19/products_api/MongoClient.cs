using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
namespace products_api
{

    public class MyMongoClient
    {        const string uri = "mongodb+srv://localhost:27017/root:axample/";
        MongoClient client = new MongoClient(uri);

    }
}
