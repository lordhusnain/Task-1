using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model
{
    public class HotelInfoModel
    {
        public HotelInfoModel()
        {
            RoomCategories = new List<string>();
            AlternativeHotels = new List<string>();
        }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("reviewPoints")]
        public string ReviewPoints { get; set; }
        [JsonProperty("numberOfReviews")]
        public string NumberOfReviews { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("roomCategories")]
        public List<string> RoomCategories { get; set; }
        [JsonProperty("alternativeHotels")]
        public List<string> AlternativeHotels { get; set; }
    }
}
