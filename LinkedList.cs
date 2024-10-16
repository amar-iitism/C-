// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class ListNode
{
    public int val;
    public ListNode next;
    
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution 
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;
        ListNode next = null;
        
        while(curr != null)
        {
            next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        return prev;
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

public class Program {
    public static void Main(string[] args) {
        Solution solution = new Solution();
        int[] values = {1,2,3,4,5};
        ListNode head = solution.CreateLinkedList(values);
        
        Console.WriteLine("original Linked List");
        solution.PrintList(head);
        
        ListNode reverseHead = solution.ReverseList(head);
        Console.WriteLine("Reverse Linked List ");
        solution.PrintList(reverseHead);
    }
}
