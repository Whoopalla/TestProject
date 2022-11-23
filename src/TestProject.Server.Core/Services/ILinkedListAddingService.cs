namespace TestProject.Server.Core.Services {
    public interface ILinkedListAddingService {
        Models.LinkedListNode<int> Add(Models.LinkedListNode<int> firstList, Models.LinkedListNode<int> secondList);
    }
}
