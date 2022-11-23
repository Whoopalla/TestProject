using Newtonsoft.Json;
using TestProject.Server.Core.Services;
using Xunit;

namespace TestProject.Server.UnitTests {
    public class TwoLinkedListSumFinderTests {
        private TwoLinkedListsAddingService GetTwoLinkedListsSumFinder() {
            return new TwoLinkedListsAddingService();
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
        public void Rigthinout() {
            TwoLinkedListsAddingService service = GetTwoLinkedListsSumFinder();
            var firstLinkedList = GetLinkedListFromList(new List<int>() { 1, 2 });
            var secondLinkedList = GetLinkedListFromList(new List<int>() { 1, 2 });

            var result = JsonConvert.SerializeObject(service.Add(firstLinkedList, secondLinkedList));
            var expected = JsonConvert.SerializeObject(GetLinkedListFromList(new List<int>() { 4, 2 }));

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Rigthinout2() {
            TwoLinkedListsAddingService service = GetTwoLinkedListsSumFinder();
            var firstLinkedList = GetLinkedListFromList(new List<int>() { 9, 1, 2 });
            var secondLinkedList = GetLinkedListFromList(new List<int>() { 1, 8, 2 });

            var result = JsonConvert.SerializeObject(service.Add(firstLinkedList, secondLinkedList));
            var expected = JsonConvert.SerializeObject(GetLinkedListFromList(new List<int>() { 5, 0, 0 }));

            Assert.Equal(expected, result);
        }

        [Fact]
        public void OverflowCheck() {
            TwoLinkedListsAddingService service = GetTwoLinkedListsSumFinder();
            var firstLinkedList = GetLinkedListFromList(new List<int>() { 2147483647, 1, 1 });
            var secondLinkedList = GetLinkedListFromList(new List<int>() { 1, 1, 1, 1 });
            Assert.Throws<OverflowException>(() => service.Add(firstLinkedList, secondLinkedList));
        }
    }
}
