using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/generate-parentheses/
class ValidateBST
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
    int[] bst = new int[] { 4, 2, 10, 1, 3, 9, 11 };

    public void Solve()
    {
        bool correct = isBST(0);
        if (correct)
            Console.WriteLine("true");
        else
            Console.WriteLine("false");
    }

    public bool isBST(int i)
    {
        if (!isValidChild(i)) return true;

        if (isValidChild(leftChildIndex(i)) && getVal(leftChildIndex(i)) > getVal(i))
            return false;
        if (isValidChild(rightChildIndex(i)) && getVal(rightChildIndex(i)) < getVal(i))
            return false;

        return isBST(leftChildIndex(i)) && isBST(rightChildIndex(i));
    }

    public int getVal(int index)
    {
        return bst[index];
    }

    public int leftChildIndex(int i)
    {
        return i * 2 + 1;
    }

    public int rightChildIndex(int i)
    {
        return i * 2 + 2;
    }

    public bool isValidChild(int i)
    {
        return i >= 0 && i <= bst.Length - 1;
    }
}