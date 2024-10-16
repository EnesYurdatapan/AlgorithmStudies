// See https://aka.ms/new-console-template for more information








List<char> reverseString = new List<char>();
List<char> finalString = new List<char>();

Console.WriteLine(LongestPalindrome("bdbcaz"));
string LongestPalindrome(string s)
{
    for (int i = 0;  i < s.Length;  i++)
    {
        reverseString.Reverse();
        reverseString.Add(s[i]);
        reverseString.Reverse(); 
        for (int j = 0; j < reverseString.Count; j++)
        {
            if (reverseString[j] == s[i])
            {
                finalString.Add(reverseString[j]);
            }

        }
    }
    return "x";
}