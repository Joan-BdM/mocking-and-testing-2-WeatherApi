namespace WeatherApi.Contracts.DTO
{
    public sealed class CurrentWeather : IEquatable<CurrentWeather>
    {
        /// <summary>
        /// Current temperature in Celsius
        /// </summary>
        public float Temperature { get; set; }

        /// <summary>
        /// Current wind in km/h
        /// </summary>
        public float Windspeed { get; set; }

        /// <summary>
        /// Wind direction
        /// </summary>
        public float Winddirection { get; set; }

        /// <summary>
        /// Weather WMO Weather interpretation codes (WW)
        /// </summary>
        public float Weathercode { get; set; }

        /// <summary>
        /// Timestamp of the weather
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Friendly description for the Weather Code
        /// </summary>
        public string Description
        {
            get
            {
                return Weathercode switch
                {
                    0 => WeatherConstants.Clear,
                    1 or 2 or 3 => WeatherConstants.Mainly_Clear,
                    45 or 48 => WeatherConstants.Foggy,
                    51 or 53 or 55 => WeatherConstants.Drizzle,
                    56 or 57 => WeatherConstants.Freezing,
                    61 or 63 or 65 => WeatherConstants.Rain,
                    66 or 67 => WeatherConstants.Freezing_Rain,
                    71 or 73 or 75 => WeatherConstants.Snow,
                    77 => WeatherConstants.Snow_Grains,
                    80 or 81 or 82 => WeatherConstants.Rain_Shower,
                    85 or 86 => WeatherConstants.Snow_Shower,
                    95 => WeatherConstants.Thunderstorm,
                    96 or 99 => WeatherConstants.Hail,
                    _ => WeatherConstants.Unknown,
                };
            }
        }

        public bool Equals(CurrentWeather? other)
        {
            return other is not null
                && Temperature == other.Temperature
                && Windspeed == other.Windspeed
                && Winddirection == other.Winddirection
                && Weathercode == other.Weathercode
                && Time == other.Time
                && Description == other.Description;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CurrentWeather);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Temperature, Windspeed, Winddirection, Weathercode, Time, Description);
        }
    }
}
