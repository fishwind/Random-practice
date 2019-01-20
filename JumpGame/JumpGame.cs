using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/jump-game/
class JumpGame
{
    static void Main(string[] args)
    {
        // can use either recursive or dfs to solve
        //SolutionRecursive sol = new SolutionRecursive();
        SolutionDFS sol = new SolutionDFS();

        sol.Solve(); 
        Console.ReadKey();
    }
}

// use recursion to solve
class SolutionRecursive
{
    //int[] input = { 3, 2, 1, 0, 4 };    // false
    int[] input = { 2, 3, 1, 1, 4 };    // true

    int[] memo; // -1 means unknown. 0 means false. 1 means true
    int[] backtrack;
    public void Solve()
    {
        memo = new int[input.Length];
        backtrack = new int[input.Length];
        for (int i = 0; i < memo.Length; i++)
            memo[i] = -1;
        bool canJump = SolveR(0);
        Console.WriteLine(canJump);
        if (canJump)
        {
            int path = input.Length - 1;
            while (path != 0)
            {
                Console.Write(path + "<--");
                path = backtrack[path];
            }
            Console.Write(0);
        }
    }

    // return if able to jump from certain index
    private bool SolveR(int fromIndex)
    {
        if (memo[fromIndex] != -1)
            return (memo[fromIndex] == 1) ? true: false;

        int currVal = input[fromIndex];

        if (fromIndex == input.Length - 1) // alr reach 
        { 
            memo[fromIndex] = 1;
            return true;
        }

        if (currVal == 0)
        {
            memo[fromIndex] = 0;
            return false;
        }

        bool canJump = false;
        for(int i = 1; i <= currVal; ++i)
        {
            if (SolveR(fromIndex + i))
            {
                canJump = true;
                backtrack[fromIndex + i] = fromIndex;
            }
        }
        memo[fromIndex] = (canJump) ? 1 : 0;
        return canJump;
    }
}

// using dfs to solve
class SolutionDFS
{
    //int[] input = { 3, 2, 1, 0, 4 };    // false
    int[] input = { 2, 3, 1, 1, 4 };    // true
    Stack<int> s = new Stack<int>();
    int[] backtrack;

    public void Solve()
    {
        backtrack = new int[input.Length];
        bool canJump = SolveS();
        Console.WriteLine(canJump);
        if(canJump)
        {
            //print backtrack
            int path = input.Length - 1;
            while(path != 0)
            { 
                Console.Write(path + "<--");
                path = backtrack[path];
            }
            Console.Write(0);
        }
    }

    private bool SolveS()
    {
        if (input == null || input.Length == 0)
            return false;

        s.Push(0);
        while (s.Count > 0)
        {
            int popped = s.Pop();
            int jumpCount = input[popped];
            if (jumpCount == 0)
                continue;
            for(int i = 1; i <= jumpCount; ++i)
            {
                int desinationIndex = popped + i;
                backtrack[desinationIndex] = popped;
                if (desinationIndex == input.Length - 1)    // if can reach endpoint
                    return true;
                s.Push(desinationIndex);
            }
        }
        return false;
    }
}