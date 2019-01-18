using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/house-robber/
class HouseRobber
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
    int[] input = { 2, 7, 9, 3, 1 };
    int[] memo = new int[5];


    public void Solve()
    {
        for (int i = 0; i < 5; i++)
            memo[i] = -1;

        int ans = SolveR(0, 0);
        Console.WriteLine(ans);
    }

    private int SolveR(int currIndex, int currTotal)
    {
        if (currIndex >= input.Length)
            return currTotal;

        if (memo[currIndex] != -1)
            return memo[currIndex];

        int take = SolveR(currIndex + 2, currTotal + input[currIndex]);
        int noTake = SolveR(currIndex + 1, currTotal);
        int maxTake = Math.Max(take, noTake);
        memo[currIndex] = maxTake;
        return maxTake;
    }
}