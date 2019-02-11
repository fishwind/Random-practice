public class Solution {
    List<string> ans = new List<string>();
    Dictionary<int, string> phone = new Dictionary<int, string>();
    public IList<string> LetterCombinations(string digits) {
            phone[2] = "abc";   phone[3] = "def";
            phone[4] = "ghi";  phone[5] = "jkl";   phone[6] = "mno";
            phone[7] = "pqrs";  phone[8] = "tuv";   phone[9] = "wxyz";
        CombineLetter(digits, 0, "");
        return ans;
    }
    
    private void CombineLetter(string inputDigit, int index, string currString) {
        if(inputDigit.Length == 0)
            return;
        if(index >= inputDigit.Length) {
            ans.Add(currString);
            return;   
        }
        string lettersFromDigit = phone[inputDigit[index]-'0'];
        for(int i = 0; i < lettersFromDigit.Length; i++) {
            char addon = lettersFromDigit[i];
            CombineLetter(inputDigit, index+1, currString + addon.ToString());
        }
    }
}