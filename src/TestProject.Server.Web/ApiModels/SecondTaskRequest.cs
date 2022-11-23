using System.Text.Json.Serialization;

namespace TestProject.Server.Web.ApiModels {
    public class SecondTaskRequest {
        [JsonPropertyName("firstNumberNode")]
        public Core.Models.LinkedListNode<int> FirstNumberNode { get; set; }
        [JsonPropertyName("secondNumberNode")]
        public Core.Models.LinkedListNode<int> SecondNumberNode { get; set; }
    }
}
