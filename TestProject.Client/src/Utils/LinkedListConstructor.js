function ListNode(data, next) {
    this.data = (data === undefined ? 0 : data)
    this.next = (next === undefined ? null : next)
}

export default function GetLinkedListFromArray(array) {
    let head = array.reverse().reduce((acc, curr) => {
        if (acc == null) {
          acc = new ListNode(curr);
      
        } else {
          acc = new ListNode(curr, acc);
        }
        return acc;
      }, null);
    return head;
}