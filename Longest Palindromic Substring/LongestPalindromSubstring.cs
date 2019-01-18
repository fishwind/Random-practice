using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/longest-palindromic-substring/
class LongestPalindromSubstring
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
    string input = "babad";

    public void Solve()
    {
        string ans = SolveR(0, input.Length);
        Console.WriteLine(ans);
    }

    private string SolveR(int l, int r)
    {
        if (l >= r)
            return "";

        string currentString = input.Substring(l, r - l);
        if (isPalindrom(currentString))
            return currentString;

        string a = SolveR(l + 1, r);
        string b = SolveR(l, r - 1);
        return (a.Length > b.Length) ? a : b;
    }

    private bool isPalindrom(string toCheck)
    {
        int l = 0;
        int r = toCheck.Length - 1;
        while(l < r)
        {
            if(toCheck[l] != toCheck[r])
                return false;

            l++;
            r--;
        }
        return true;
    }
}