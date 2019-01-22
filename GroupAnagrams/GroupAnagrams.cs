using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/group-anagrams/solution/
class GroupAnagrams
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
    string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };
    public void Solve()
    {
        List<List<string>> ans = new List<List<string>>();
        Dictionary<string, List<string>> ansStorage = new Dictionary<string, List<string>>();
        // iterate, count their char. key as string. aaabcz = "3 1 1 0 0 0 0 .... 0 1"
        for (int i = 0; i < strs.Length; i++)
        {
            string turnedString = turnString(strs[i]);
            if (!ansStorage.ContainsKey(turnedString))
            {
                ansStorage[turnedString] = new List<string>();
            }
            ansStorage[turnedString].Add(strs[i]);
        }

        //iterate thru storage, output ans
        foreach (string key in ansStorage.Keys)
        {
            List<string> val = ansStorage[key];
            ans.Add(val);
        }

        printResult(ans);
    }

    private string turnString(string word)
    {
        char[] c = word.ToCharArray();
        int[] charCounter = new int[26];

        // initialise count
        for (int i = 0; i < charCounter.Length; i++)
            charCounter[i] = 0;

        // count char
        for (int i = 0; i < c.Length; i++)
            charCounter[c[i] - 'a'] += 1;

        string returnString = "";
        for (int i = 0; i < charCounter.Length; i++)
            returnString += charCounter[i].ToString() + " ";

        return returnString;
    }

    private void printResult(List<List<string>> ans)
    {
        foreach(List<string> lst in ans)
        {
            string toPrint = "[ ";
            foreach (string s in lst)
                toPrint += s + " ";
            toPrint += "]";
            Console.WriteLine(toPrint);
        }
    }
}