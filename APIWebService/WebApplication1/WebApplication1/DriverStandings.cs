using System.Text.Json.Serialization;

namespace WebApplication1
{
    public class DriverStanding
    {
        [JsonPropertyName("driver_uuid")] // Specify the exact JSON name
        public string DriverUuid { get; set; }

        [JsonPropertyName("first_name")] // Specify the exact JSON name
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")] // Specify the exact JSON name
        public string LastName { get; set; }

        [JsonPropertyName("driver_country_code")]
        public string DriverCountryCode { get; set; }

        [JsonPropertyName("driver_image")]
        public string? DriverImage { get; set; }

        [JsonPropertyName("team_uuid")]
        public string TeamUuid { get; set; }

        [JsonPropertyName("season_team_name")]
        public string SeasonTeamName { get; set; }

        [JsonPropertyName("season_points")]
        public int SeasonPoints { get; set; }
    }

}
