using Microsoft.Extensions.Options;
using MongoDB.Driver;
using products_api.Models;

namespace products_api.Services
{
    public class ProducteService
    {
        private readonly IMongoCollection<Producte> _productsCollection;
        public ProducteService(IOptions<StoreDb> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);

            _productsCollection = mongoDatabase.GetCollection<Producte>(
                options.Value.ProductsCollectionName);
        }
        public async Task<List<Producte>> GetAsync() =>
        await _productsCollection.Find(_ => true).ToListAsync();

        public async Task<Producte?> GetAsync(string id) =>
        await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Producte newProducte) =>
            await _productsCollection.InsertOneAsync(newProducte);
    }
}
