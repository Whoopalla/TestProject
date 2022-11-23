using System.Text.Json.Serialization;

namespace TestProject.Server.Core.Models {
    public class LinkedListNode<T> {
        [JsonPropertyName("data")]
        public T Data { get; set; }
        [JsonPropertyName("next")]
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data) {
            this.Data = data;
        }
    }
}
