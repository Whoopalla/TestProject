using Newtonsoft.Json;
using System.Net;
using System.Text;
using TestProject.Server.Web;
using TestProject.Server.Web.ApiModels;
using Xunit;

namespace TestProject.Server.FunctionalTests.ControllerApis;
[Collection("Sequential")]
public class TaskControllerTests : IClassFixture<CustomWebApplicationFactory<WebMarker>> {
    private readonly HttpClient _client;

    public TaskControllerTests(CustomWebApplicationFactory<WebMarker> factory) {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task FirstTask_CorrectInput() {
        var request = new FirstTaskRequest() { Numbers = new List<long> { 1, 3, 1, 3 } };
        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var result = await _client.PostAsync("/FirstTask", data);
        var expectedStatusCode = HttpStatusCode.OK;

        Assert.Equal(expectedStatusCode, result.StatusCode);
    }

    [Fact]
    public async Task FirstTask_OverflowInput() {
        var request = new FirstTaskRequest() { Numbers = new List<long> { 1, 9223372036854775807, 1, 1 } };
        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var result = await _client.PostAsync("/FirstTask", data);
        var expectedStatusCode = HttpStatusCode.BadRequest;

        Assert.Equal(expectedStatusCode, result.StatusCode);
    }

    [Fact]
    public async Task FirstTask_EmptyInput() {
        var request = new FirstTaskRequest() { Numbers = new List<long> { } };
        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var result = await _client.PostAsync("/FirstTask", data);
        var expectedStatusCode = HttpStatusCode.BadRequest;

        Assert.Equal(expectedStatusCode, result.StatusCode);
    }

    private Core.Models.LinkedListNode<int> GetLinkedListFromList(IList<int> numbers) {
        var head = new Core.Models.LinkedListNode<int>(numbers[0]);
        var currentNode = head;
        var currentIndex = 1;

        while (currentNode != null && currentIndex < numbers.Count) {
            var newNode = new Core.Models.LinkedListNode<int>(numbers[currentIndex]);
            currentIndex++;
            currentNode.Next = newNode;
            currentNode = newNode;
        }
        return head;
    }

    [Fact]
    public async Task SecondTask_CorrectInput() {
        var request = new SecondTaskRequest() {
            FirstNumberNode = GetLinkedListFromList(new List<int> { 1, 2, 3 }),
            SecondNumberNode = GetLinkedListFromList(new List<int> { 1, 2, 3 })
        };
        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var result = await _client.PostAsync("/SecondTask", data);
        var expectedStatusCode = HttpStatusCode.OK;

        Assert.Equal(expectedStatusCode, result.StatusCode);
    }

    [Fact]
    public async Task SecondTask_Incorrect() {
        var request = new SecondTaskRequest() {
            FirstNumberNode = GetLinkedListFromList(new List<int> { 1, 2, 2147483647 }),
            SecondNumberNode = GetLinkedListFromList(new List<int> { 1, 2, 3 })
        };
        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var result = await _client.PostAsync("/SecondTask", data);
        var expectedStatusCode = HttpStatusCode.BadRequest;

        Assert.Equal(expectedStatusCode, result.StatusCode);
    }

    [Fact]
    public async Task SecondTask_EmptyInput() {
        var request = new SecondTaskRequest() {
            FirstNumberNode = null,
            SecondNumberNode = null
        };
        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var result = await _client.PostAsync("/SecondTask", data);
        var expectedStatusCode = HttpStatusCode.BadRequest;

        Assert.Equal(expectedStatusCode, result.StatusCode);
    }

    [Fact]
    public async Task ThirdTask_CorrectInput() {
        var request = new ThirdTaskRequest() {
            Input = "GooTooG"
        };
        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var result = await _client.PostAsync("/ThirdTask", data);
        var expectedStatusCode = HttpStatusCode.OK;

        Assert.Equal(expectedStatusCode, result.StatusCode);
    }

    [Fact]
    public async Task ThirdTask_TooBigString() {
        var request = new ThirdTaskRequest() {
            Input = "IT was noon of a bright winter's day. " +
            "The air was crisp with frost, and Nadia, " +
            "who was walking beside me, " +
            "found her curls and the delicate down on her upper lip silvered with her own breath." +
            " We stood at the summit of a high hill." +
            " The ground fell away at our feet in a steep incline which reflected the sun s rays like a mirror. " +
            "Near us lay a little sled brightly upholstered with red.\r\n\r\n\"Let us coast down, Nadia!\" " +
            "I begged. \"Just once! I promise you nothing will happen.\"\r\n\r\nBut Nadia was timid." +
            " The long slope, from where her little overshoes were planted to the foot of the ice-clad hill, " +
            "looked to her like the wall of a terrible, yawning chasm. Her heart stopped beating, " +
            "and she held her breath as she gazed into that abyss while I urged her to take her seat on the sled. " +
            "What might not happen were she to risk a flight over that precipice! She would die, she would go mad!"
        };
        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var result = await _client.PostAsync("/ThirdTask", data);
        var expectedStatusCode = HttpStatusCode.BadRequest;

        Assert.Equal(expectedStatusCode, result.StatusCode);
    }
}