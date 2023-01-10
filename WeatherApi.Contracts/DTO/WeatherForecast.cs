namespace WeatherApi.Contracts.DTO
{
    public sealed class WeatherForecast : IEquatable<WeatherForecast>
    {
        /// <summary>
        /// Geographical WGS84 coordinate of the location
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Geographical WGS84 coordinate of the location
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// Generation time of the weather forecast in milliseconds. This is mainly used for performance monitoring and improvements.
        /// </summary>
        public float Generationtime_ms { get; set; }

        /// <summary>
        /// Applied timezone offset from the &timezone= parameter.
        /// </summary>
        public int Utc_offset_seconds { get; set; }

        /// <summary>
        /// Timezone identifier (e.g. Europe/Berlin) and abbreviation (e.g. CEST)
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// Timezone identifier (e.g. Europe/Berlin) and abbreviation (e.g. CEST)
        /// </summary>
        public string Timezone_abbreviation { get; set; }

        /// <summary>
        /// The elevation in meters of the selected weather grid-cell. In mountain terrain it might differ from the location you would expect.
        /// </summary>
        public float Elevation { get; set; }

        /// <summary>
        /// Selected City data
        /// </summary>
        public CityDto City { get; set; }

        /// <summary>
        /// Current weather conditions
        /// </summary>
        public CurrentWeather Current_weather { get; set; }

        public bool Equals(WeatherForecast? other)
        {
            return other is not null
                && Latitude == other.Latitude
                && Longitude == other.Longitude
                && Generationtime_ms == other.Generationtime_ms
                && Utc_offset_seconds == other.Utc_offset_seconds
                && Timezone == other.Timezone
                && Timezone_abbreviation == other.Timezone_abbreviation
                && Elevation == other.Elevation
                && ((City is null && other.City is null) || City!.Equals(other.City));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as WeatherForecast);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                Latitude,
                Longitude,
                Generationtime_ms,
                Utc_offset_seconds,
                Timezone,
                Timezone_abbreviation,
                Elevation,
                City);
        }
    }
}