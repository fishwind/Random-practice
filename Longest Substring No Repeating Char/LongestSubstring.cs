using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/longest-substring-without-repeating-characters/
class Program
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
    int max = 0;
    int curr = 0;

    public void Solve()
    {
        string input = "pwwkew";
        LongestSubstring(input);
        Console.WriteLine(max);
    }

    private void LongestSubstring(string input)
    {
        if (input == null || input.Length == 0)
            return;

        HashSet<char> charSet = new HashSet<char>();
        int l = 0;
        int r = 0;

        while(r < input.Length)
        {
            if(!charSet.Contains(input[r]))
            {
                charSet.Add(input[r]);
                curr++;
                UpdateMax();
                r++;
            }
            else
            {
                charSet.Remove(input[l]);
                curr--;
                l++;
            }
        }
    }

    private void UpdateMax()
    {
        if (curr > max)
            max = curr;
    }
}