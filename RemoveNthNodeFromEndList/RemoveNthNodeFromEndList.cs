using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/remove-nth-node-from-end-of-list/
class RemoveNthNodeFromEndList
{
    static void Main(string[] args)
    {
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(4);
        head.next.next.next.next = new ListNode(5);

        Solution sol = new Solution();
        sol.Solve(head, 2); 
        Console.ReadKey();
    }
}

 public class ListNode
 {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
 }
class Solution
{
    public ListNode Solve(ListNode head, int n) {
        // have 3 pointers - prev, curr, further
        // shift further n times
        // iterate n until further is null, then prev.next = curr.next
        if(n == 0) return head;
        
        ListNode prev = null;
        ListNode curr = head;
        ListNode further = head;
        for(int i = 0; i < n; ++i) {
            further = further.next;
            if(further == null && i+1 < n)
                return head;    // n-th node is out of bound!
        }
        
        while(further != null) {
            prev = curr;
            curr = curr.next;
            further = further.next;
        }
        
        if(prev == null) return curr.next;
        prev.next = curr.next;
        curr = null;
        printNodes(head);
        return head;
    }

    private void printNodes(ListNode head)
    {
        ListNode h = head;
        while(h!=null)
        {
            Console.Write(h.val + "-->");
            h = h.next;
        }
    }
}