using DotNetBasic.Tasks;

namespace DotNetBasic;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the number of task which you want to start: " +
                          "\n 1. Palindrome" +
                          "\n 2. Swapping " +
                          "\n 3. Matrix" +
                          "\n 4. Game of life");

        switch (Console.ReadLine())
        {
            case "1":
                Palindrome palindrome = new Palindrome();
                palindrome.IsPhrasePalindrome();
                break;
            case "2":
                Swapping arrayForSwapping = new Swapping();
                arrayForSwapping.SwapElements();
                break;
            case "3":
                Matrix matrix = new Matrix();
                matrix.ModifyMatrix();
                break;
            case "4":
                GameOfLife game = new GameOfLife();
                game.runGame();
                break;
            default:
                Console.WriteLine("I don't know such task:(" +
                                  "\nTry again!");
                break;
        }
    }
}