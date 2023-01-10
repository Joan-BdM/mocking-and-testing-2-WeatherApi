namespace WeatherApi.Models
{
    public sealed class City : IEquatable<City>
    {
        /// <summary>
        /// City Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// City Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Geolocation Latitude
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Geolocation Longitude
        /// </summary>
        public float Longitude { get; set; }

        public bool Equals(City? other)
        {
            return other is not null
                && Id == other.Id
                && Name == other.Name
                && Latitude == other.Latitude
                && Longitude == other.Longitude;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as City);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Latitude, Longitude);
        }
    }
}