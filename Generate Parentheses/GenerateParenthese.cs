using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/generate-parentheses/
class GenerateParenthese
{
    static void Main(string[] args)
    {
        Solution sol = new Solution();
        sol.Solve(3);
        Console.ReadKey();
    }
}

class Solution
{
    public void Solve(int pairAmt)
    {
        List<string> ans = new List<string>();
        solveR(pairAmt, 0, "", ans);
        Console.Write("size: " + ans.Count());
        Console.WriteLine();
        foreach(string a in ans)
            Console.WriteLine(a);
    }

    private void solveR(int open, int close, string curr, List<string> ans)
    {
        if (open == 0 && close == 0)
            ans.Add(curr);

        if(open > 0)
            solveR(open-1, close+1, curr + "(", ans);
        if(close > 0)
            solveR(open, close-1, curr + ")", ans);
    }
}






