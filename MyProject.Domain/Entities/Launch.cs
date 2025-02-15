using Newtonsoft.Json;

namespace MyProject.Domain.Entities
{
    public class Launch
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("date_utc")]
        public DateTime Date { get; set; }

    }
}
