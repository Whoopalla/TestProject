using System.Text.Json.Serialization;

namespace TestProject.Server.Web.ApiModels {
    public class ThirdTaskRequest {
        [JsonPropertyName("input")]
        public string Input { get; set; }
    }
}
