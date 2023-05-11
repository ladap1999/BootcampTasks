namespace DotNetBasic.Tasks;

public class Swapping
{
    private int[] arrayOfNumber;

    public void SwapElements()
    {
        Random random = new Random();

        Console.WriteLine("Enter array size: ");
        arrayOfNumber = new int [Convert.ToInt32(Console.ReadLine())];

        for (int i = 0; i < arrayOfNumber.Length; i++)
        {
            arrayOfNumber[i] = random.Next(0, 10);
        }

        PrintArray(arrayOfNumber);

        for (int i = 0, j = arrayOfNumber.Length - 1; i < arrayOfNumber.Length / 2; i++, j--)
        {
            int swappedElement;
            swappedElement = arrayOfNumber[i];
            arrayOfNumber[i] = arrayOfNumber[j];
            arrayOfNumber[j] = swappedElement;
        }

        Console.WriteLine("\nYour swapped array is: ");
        PrintArray(arrayOfNumber);
    }

    public void PrintArray(int[] array)
    {
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
    }
}