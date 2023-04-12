namespace DotNetBasic.Tasks;

public class Palindrome
{
    private string? input;
    private char[] symbolsOfInput;
    
    public void IsPhrasePalindrome()
    {
        Console.WriteLine("Enter your string: ");
        input = Console.ReadLine();
        
        if (input != null && (input.Contains(' ') || input.Contains('-')))
        {
            input = input.Replace(" ", "").Replace("-", "");
        }
        
        symbolsOfInput = input.ToCharArray();
        
        for (int i = 0, j = symbolsOfInput.Length - 1; i <= symbolsOfInput.Length / 2; i++, j--)
        {
            if (!symbolsOfInput[i].Equals(symbolsOfInput[j]))
            {
                Console.WriteLine("It's not a palindrome. Please try again!");
                break;
            }

            if (i == symbolsOfInput.Length / 2)
            {
                Console.WriteLine("Congratulation! It's a palindrome!");
            }
        }
    }
}