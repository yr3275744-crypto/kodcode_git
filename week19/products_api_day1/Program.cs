using MongoDB.Bson;
using MongoDB.Driver;
using products_api;
using products_api.Models;
using products_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//const string uri = "mongodb://localhost:27017/";
//var client = new MongoClient(uri);
//var myDb = client.GetDatabase("store");
//IMongoCollection<producte> myColl = myDb.GetCollection<producte>("products");

builder.Services.Configure<StoreDb>(
    builder.Configuration.GetSection("storeDb"));
builder.Services.AddSingleton<ProducteService>();
//var ob = new obA
//{
//    name = "Wireless Mouse",
//    category = "Electronics",
//    price = 1936.21,
//    stock = 0,
//    rating = 4.0,
//    isActive = true,
//    createdAt = DateTime.Now
//};
//myColl.InsertOne(ob);

//var filter = Builders<ObA>
//var result = await myColl.Find(_ => true).ToListAsync();
//foreach (producte obA in result)
//{
//    Console.WriteLine(obA.Id);
//}
//Console.WriteLine(await client.ListDatabaseNamesAsync());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//using MongoDB.Bson;
//using MongoDB.Bson.IO;
//using MongoDB.Driver;
//var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
//if (connectionString == null)
//{
//    Console.WriteLine("You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/get-started/create-connection-string");
//    Environment.Exit(0);
//}
//var client = new MongoClient(connectionString);
//var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");
//var filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");
//var document = collection.Find(filter).First();
//Console.WriteLine(document.ToJson(new JsonWriterSettings { Indent = true }));

