namespace DotNetBasic.Tasks;

public class Matrix
{
    private int[,] initialArrayMatrix;
    private int[,] modifiedArrayMatrix;
    private int rows;
    private int columns;

    public void ModifyMatrix()
    {
        FillMatrix();
        Console.WriteLine("Your initial matrix is:");
        printMatrix(initialArrayMatrix);
        
        Console.WriteLine("Your modified matrix is:");
        modifiedArrayMatrix = initialArrayMatrix;
        
        ChangeNumbersBelowDiagonal();
        ChangeNumbersAboveDiagonal();
        printMatrix(modifiedArrayMatrix);
    }

    public void FillMatrix()
    {
        Random random = new Random();

        Console.WriteLine("Enter matrix size. Amount of rows is: ");
        rows = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Amount of columns is: ");
        columns = Convert.ToInt32(Console.ReadLine());

        initialArrayMatrix = new int [rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                initialArrayMatrix[i, j] = random.Next(0, 10);
            }
        }
    }

    public void printMatrix(int[,] matrix)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(initialArrayMatrix[i, j] + "     ");
            }
            Console.WriteLine();
        }
    }

    public void ChangeNumbersBelowDiagonal()
    {
        for (int i = 1; i < rows; i++)
        {
            for (int j = 0; j < i; j++)
            {
                modifiedArrayMatrix[i, j] = 0;
            }
        }
    }

    public void ChangeNumbersAboveDiagonal()
    {
        for (int i = 1; i < columns; i++)
        {
            for (int j = 0; j < i; j++)
            {
                modifiedArrayMatrix[j, i] = 1;
            }
        }
    }
}