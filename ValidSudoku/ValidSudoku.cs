using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/valid-sudoku/
class ValidSudoku
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
    // true input
    string[,] input = {
        { "5","3",".",".","7",".",".",".","." },
        { "6",".",".","1","9","5",".",".","." },
        { ".","9","8",".",".",".",".","6","." },
        { "8",".",".",".","6",".",".",".","3" },
        { "4",".",".","8",".","3",".",".","1" },
        { "7",".",".",".","2",".",".",".","6" },
        { ".","6",".",".",".",".","2","8","." },
        { ".",".",".","4","1","9",".",".","5" },
        { ".",".",".",".","8",".",".","7","9" },
    };

    // false input
    //string[,] input = {
    //    { "8","3",".",".","7",".",".",".","." },
    //    { "6",".",".","1","9","5",".",".","." },
    //    { ".","9","8",".",".",".",".","6","." },
    //    { "8",".",".",".","6",".",".",".","3" },
    //    { "4",".",".","8",".","3",".",".","1" },
    //    { "7",".",".",".","2",".",".",".","6" },
    //    { ".","6",".",".",".",".","2","8","." },
    //    { ".",".",".","4","1","9",".",".","5" },
    //    { ".",".",".",".","8",".",".","7","9" },
    //};

    public void Solve()
    {
        printMap();

        bool rowPass = checkAllRows();
        bool colPass = checkAllCol();
        bool boxPass = checkAllBoxes();
        bool valid = rowPass && colPass && boxPass;
        Console.WriteLine(valid);
    }

    private bool checkAllRows()
    {
        for (int i = 0; i < 9; ++i)
        {
            if (!checkRow(i))
                return false;
        }
        return true;
    }

    private bool checkAllCol()
    {
        for (int i = 0; i < 9; ++i)
        {
            if (!checkCol(i))
                return false;
        }
        return true;
    }

    private bool checkAllBoxes()
    {
        for(int i = 0; i < 9; ++i)
        {
            int row = (i % 3) * 3;
            int col = i * 3;
            if (!checkBox(row, col))
                return false;
        }
        return true;
    }

    private bool checkRow(int whichRow)
    {
        HashSet<int> set = new HashSet<int>();
        for(int i = 0; i < 9; ++i)
        {
            string stringVal = input[whichRow, i];
            if(stringVal == "." ) 
                continue;

            int numVal = int.Parse(stringVal);
            if (!isWithinRange(numVal) || set.Contains(numVal))
                return false;

            set.Add(numVal);
        }
        return true;
    }

    private bool checkCol(int whichCol)
    {
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < 9; ++i)
        {
            string stringVal = input[i, whichCol];
            if (stringVal == ".")
                continue;

            int numVal = int.Parse(stringVal);
            if (!isWithinRange(numVal) || set.Contains(numVal))
                return false;

            set.Add(numVal);
        }
        return true;
    }

    private bool checkBox(int whichR, int whichC) // input topleft index of 3x3 box.
    {
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < 9; ++i)
        {
            int row = whichR + i / 3;
            int col = (whichC + i) % 3;
            string stringVal = input[row, col];
            if (stringVal == ".")
                continue;

            int numVal = int.Parse(stringVal);
            if (!isWithinRange(numVal) || set.Contains(numVal))
                return false;

            set.Add(numVal);
        }
        return true;
    }

    private bool isWithinRange(int val)
    {
        return val >= 1 && val <= 9;
    }

    private void printMap()
    {
        for (int i = 0; i < 9; ++i)
        {
            for (int j = 0; j < 9; ++j)
                Console.Write(input[i, j] + " ");
            Console.WriteLine();
        }
    }

}