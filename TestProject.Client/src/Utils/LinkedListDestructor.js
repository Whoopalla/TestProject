function LengthOfLinkedList(head) {
    let current = head;
    let count = 0;
    while (current !== null && current !== undefined) {
        count++;
        current = current.next;
    }
    return count;
}

export default function GetArrayFromLinkedList(head) {
    const result = new Array(LengthOfLinkedList(head));
  
    let index = 0;
    let current = head;
  
    while (current !== null && current !== undefined) {
        result[index++] = current.data;
        current = current.next;
    }

    return result;
}