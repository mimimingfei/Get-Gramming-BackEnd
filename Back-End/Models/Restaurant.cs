﻿namespace Back_End.Models
{
    public class Restaurant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cuisines { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhotosUrl { get; set; }
    }

}
