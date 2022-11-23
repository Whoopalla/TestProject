using Newtonsoft.Json;

namespace TestProject.Server.Web.ApiModels {
    public sealed class FirstTaskRequest {
        [JsonProperty("numbers")]
        public List<long> Numbers { get; set; }
    }
}
