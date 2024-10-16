using System;

public class ListNode {
    public int val;
    public ListNode next;
    
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode dummy = new ListNode(0);
        ListNode curr = dummy;
        while(list1!=null && list2!=null) {
            if(list1.val <= list2.val){
                curr.next = list1;
                list1=list1.next;
                curr = curr.next;
            } else {
                curr.next = list2;
                list2 = list2.next;
                curr = curr.next;
            }
        }
        if(list1!=null){
            curr.next = list1;
        }
        if(list2!=null){
            curr.next = list2;
        }
        return dummy.next;
    }
    
    public void PrintList(ListNode head)
    {
        ListNode curr = head;
        while(curr!= null){
            Console.WriteLine(curr.val + " -> ");
            curr = curr.next;
        }
        Console.WriteLine("null");
    }
    public ListNode CreateLinkedList(int[] values) {
        if(values.Length == 0 )
        return null;
        ListNode head = new ListNode(values[0]);
        ListNode curr = head;
        
        
        for(int i=1; i<values.Length; i++){
            curr.next = new ListNode(values[i]);
            curr = curr.next;
        }
        
        return head;
    }
    
}

public class Program{
    public static void Main(string[] args){
        Solution solution = new Solution();
        int[] values1 = {1,2,3,4,5};
        int[] values2 = {3,5,7};
        
        ListNode list1 = solution.CreateLinkedList(values1);
        ListNode list2 = solution.CreateLinkedList(values2);
        
        
        Console.WriteLine("original Linked List1");
        solution.PrintList(list1);
        
        Console.WriteLine("original Linked List2");
        solution.PrintList(list2);
        
        ListNode mergeList = solution.MergeTwoLists(list1, list2);
        Console.WriteLine("Merged Linked List");
        solution.PrintList(mergeList);
        
        
    }
}
