using MongoDB.Bson;

namespace Data.Base.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public string City { get; set; }
        public string Sign { get; set; }
    }
}
