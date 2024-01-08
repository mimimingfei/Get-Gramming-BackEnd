using System.Numerics;

namespace Back_End.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cuisine { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public List<string> PhotosUrl { get; set; }
        public int UserId { get; set; }
        public int Votes {  get; set; }
        public DateTimeOffset CreateAt { get; set; }
    }
}
