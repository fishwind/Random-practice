using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/add-two-numbers/
class AddTwoNumberLL
{
    static void Main(string[] args)
    {
        Solution sol = new Solution();
        sol.Solve(); 
        Console.ReadKey();
    }
}

class Solution
{
    public void Solve()
    {
        // 1st linkedlist (in reverse)
        LinkedList L1 = new LinkedList(9);
        L1.next = (new LinkedList(9));
        L1.next.next = (new LinkedList(9));
        L1.next.next.next = null;

        // 2nd linkedlist (in reverse)
        LinkedList L2 = new LinkedList(9);
        L2.next = (new LinkedList(9));
        L2.next.next = (new LinkedList(9));
        L2.next.next.next = null;

        // ans is the output linkedlist (in reverse)
        LinkedList ans = null;
        LinkedList ansPointer = null;
        LinkedList pointer1 = L1;
        LinkedList pointer2 = L2;

        int bringOver = 0;
        while(pointer1 != null && pointer2 != null)
        {
            int sum = pointer1.value + pointer2.value + bringOver;
            bringOver = sum/ 10;
            if (ansPointer == null)
            {   // if is 1st linkedlist node
                ansPointer = new LinkedList(sum % 10);
                ans = ansPointer;
            }
            else
            {
                ansPointer.next = new LinkedList(sum % 10);
                ansPointer = ansPointer.next;
            }
            pointer1 = pointer1.next;
            pointer2 = pointer2.next;
        }

        if (bringOver == 1)
        {
            ansPointer.next = new LinkedList(bringOver);
            ansPointer = ansPointer.next;
        }

        LinkedList remaining = (pointer1 == null) ? pointer2 : pointer1;

        while(remaining != null)
        {
            ansPointer = new LinkedList(remaining.value + bringOver);
            bringOver = 0;
            ansPointer = ansPointer.next; remaining = remaining.next;
        }
        ansPointer.next = null;
        LinkedList newLinkedList = ReverseLinkedListIterative(ans);
        PrintLinkedList(newLinkedList);
    }

    // reverse linkedlist recursively
    private LinkedList ReverseLinkedListRecursive(LinkedList node)
    {
        //bc 
        if (node.next == null)
            return node;

        LinkedList head = ReverseLinkedListRecursive(node.next);
        node.next.next = node;
        node.next = null;

        return head;
    }

    // reverse linkedlist iteratively
    private LinkedList ReverseLinkedListIterative(LinkedList list)
    {
        LinkedList head = list;
        LinkedList curr = list;
        LinkedList prev = null;
        while(curr != null)
        {
            if (curr.next == null)
                head = curr;

            LinkedList temp = curr;
            curr = curr.next;
            temp.next = prev;
            prev = temp;
        }
        return head;
    }


    private void PrintLinkedList(LinkedList list)
    {
        LinkedList pointer = list;
        while(pointer != null)
        {
            Console.Write(pointer.value);
            pointer = pointer.next;
        }
        Console.WriteLine();
    }
}

class LinkedList
{
    public LinkedList(int v) { this.value = v; }
    public int value;
    public LinkedList next;
}