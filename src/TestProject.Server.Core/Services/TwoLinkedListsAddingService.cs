namespace TestProject.Server.Core.Services {
    public class TwoLinkedListsAddingService : ILinkedListAddingService {

        public Models.LinkedListNode<int> Add(Models.LinkedListNode<int> firstListNode, Models.LinkedListNode<int> secondListNode) {

            Queue<int> stack1 = new Queue<int>();
            Queue<int> stack2 = new Queue<int>();

            while (firstListNode != null) {
                stack1.Enqueue(firstListNode.Data);
                firstListNode = firstListNode.Next;
            }
            while (secondListNode != null) {
                stack2.Enqueue(secondListNode.Data);
                secondListNode = secondListNode.Next;
            }

            int carry = 0;
            Models.LinkedListNode<int> result = null;
            while (stack1.Count != 0 ||
                   stack2.Count != 0) {
                int a = 0, b = 0;

                if (stack1.Count != 0) {
                    a = (int)stack1.Dequeue();
                }

                if (stack2.Count != 0) {
                    b = (int)stack2.Dequeue();
                }

                int total = 0;

                checked {
                    total = a + b + carry;
                }

                Models.LinkedListNode<int> tempNode = new Models.LinkedListNode<int>(total % 10);
                carry = total / 10;

                if (result == null) {
                    result = tempNode;
                }
                else {
                    tempNode.Next = result;
                    result = tempNode;
                }
            }

            if (carry != 0) {
                Models.LinkedListNode<int> temp = new Models.LinkedListNode<int>(carry);
                temp.Next = result;
                result = temp;
            }
            return result;
        }
    }
}