using AlgorithmSite.APISorting.SortAnalytics;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AlgorithmSite.Models
{
    public class AnalysisObjDBModel
    {
        //Unique ID to keep track of information in the database
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        //int used to keep track of how many iterations a specific sort or set of sorts has taken to sort given data
        [BsonElement("iterations")]
        public int Iterations { get; set; }

        //the amount of sorts that occurred
        [BsonElement("attempts")]
        public int Attempts { get; set; }

        //the type of sort that was done
        [BsonElement("name")]
        public string SortName { get; set; } = null!;

        //the average iterations per sort attempt
        [BsonElement("iterations_per_attempt")]
        public double AvgIterations { get; set; }

        //a list of sorted data containing string representations of sorted data
        [BsonElement("sorted_data")]
        public List<List<string>> JsonList { get; set; } = null!;   

        public AnalysisObjDBModel(AnalysisObj obj)
        {
            this.Attempts = obj.Attempts;
            this.SortName = obj.SortName;
            this.AvgIterations = obj.AvgIterations;
            this.JsonList = obj.JsonList;
            this.Iterations = obj.Iterations;
        }
    }
}
