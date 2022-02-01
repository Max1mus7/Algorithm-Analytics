using AlgorithmSite.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace AlgorithmSite.Services
{
    public class AnalysesService
    {
        private readonly IMongoCollection<AnalysisObjDBModel> _sortsCollection;

        public AnalysesService(IOptions<AlgorithmDatabaseSettings> algoDatabaseSettings)
        {
            var mongoClient = new MongoClient(algoDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(algoDatabaseSettings.Value.DatabaseName);
            _sortsCollection = mongoDatabase.GetCollection<AnalysisObjDBModel>(algoDatabaseSettings.Value.SortsCollectionName);
        }

        public async Task<List<AnalysisObjDBModel>> GetAsync() =>
            await _sortsCollection.Find(_ => true).ToListAsync();

        public async Task<AnalysisObjDBModel?> GetAsync(string id) =>
            await _sortsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(AnalysisObjDBModel analysis) =>
            await _sortsCollection.InsertOneAsync(analysis);

        public async Task UpdateAsync(string id, AnalysisObjDBModel updatedAnalysis) =>
            await _sortsCollection.ReplaceOneAsync(x => x.Id == id, updatedAnalysis);

        public async Task RemoveAsync(string id) =>
            await _sortsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
