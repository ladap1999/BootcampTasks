namespace DotNetBasic.Tasks;

public class GameOfLife
{
    private char[,] currentArrayMatrix;
    private char[,] previousArrayMatrix = null;
    private int rows;
    private int columns;
    private int members = 0;

    public void runGame()
    {
        FillMatrix();
        PrintMatrix(currentArrayMatrix);
        CalculateAliveMembers();
    }

    public void FillMatrix()
    {
        Random random = new Random();

        Console.WriteLine("Enter matrix size.\nAmount of rows is: ");
        rows = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Amount of columns is: ");
        columns = Convert.ToInt32(Console.ReadLine());

        currentArrayMatrix = new char [rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                currentArrayMatrix[i, j] = random.Next(0, 2) == 0 ? '+' : '-';
            }
        }
    }

    public void CalculateAliveMembers()
    {
        while (!IsArrayNegative())
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    CheckLeftMember(i, j);
                    CheckRightMember(i, j);
                    CheckUpMember(i, j);
                    CheckDownMember(i, j);
                    CheckDownDiagonalMembers(i, j);
                    CheckUpDiagonalMembers(i, j);

                    if (currentArrayMatrix[i, j] == '+')
                    {
                        ChangePositiveCell(i, j);
                    }
                    else
                    {
                        ChangeNegativeCell(i, j);
                    }

                    members = 0;
                }
            }

            Console.ReadKey();
            PrintMatrix(currentArrayMatrix);

            if (CompareCurrentPreviousState())
            {
                Console.WriteLine("Game is over!");
                break;
            }

            previousArrayMatrix = (char[,])currentArrayMatrix.Clone();
        }
    }

    public void CheckLeftMember(int rowPosition, int columnPosition)
    {
        if (columnPosition != 0)
        {
            if (currentArrayMatrix[rowPosition, columnPosition - 1] == '+')
            {
                members++;
            }
        }
    }

    public void CheckRightMember(int rowPosition, int columnPosition)
    {
        if (columnPosition != columns - 1)
        {
            if (currentArrayMatrix[rowPosition, columnPosition + 1] == '+')
            {
                members++;
            }
        }
    }

    public void CheckUpMember(int rowPosition, int columnPosition)
    {
        if (rowPosition != 0)
        {
            if (currentArrayMatrix[rowPosition - 1, columnPosition] == '+')
            {
                members++;
            }
        }
    }

    public void CheckDownMember(int rowPosition, int columnPosition)
    {
        if (rowPosition != rows - 1)
        {
            if (currentArrayMatrix[rowPosition + 1, columnPosition] == '+')
            {
                members++;
            }
        }
    }

    public void CheckUpDiagonalMembers(int rowPosition, int columnPosition)
    {
        if (columnPosition != 0 && columnPosition != columns - 1 && rowPosition != 0)
        {
            if (currentArrayMatrix[rowPosition - 1, columnPosition - 1] == '+')
            {
                members++;
            }

            if (currentArrayMatrix[rowPosition - 1, columnPosition + 1] == '+')
            {
                members++;
            }
        }
    }

    public void CheckDownDiagonalMembers(int rowPosition, int columnPosition)
    {
        if (columnPosition != 0 && columnPosition != columns - 1 && rowPosition != rows - 1)
        {
            if (currentArrayMatrix[rowPosition + 1, columnPosition - 1] == '+')
            {
                members++;
            }

            if (currentArrayMatrix[rowPosition + 1, columnPosition + 1] == '+')
            {
                members++;
            }
        }
    }

    public void ChangePositiveCell(int rowPosition, int columnPosition)
    {
        if (members <= 1)
        {
            currentArrayMatrix[rowPosition, columnPosition] = '-';
        }

        if (members >= 4)
        {
            currentArrayMatrix[rowPosition, columnPosition] = '-';
        }
    }

    public void ChangeNegativeCell(int rowPosition, int columnPosition)
    {
        if (members == 3)
        {
            currentArrayMatrix[rowPosition, columnPosition] = '+';
        }
    }

    public bool IsArrayNegative()
    {
        foreach (var element in currentArrayMatrix)
        {
            if (element == '+')
            {
                return false;
            }
        }

        Console.WriteLine("Game is over!");
        return true;
    }

    public bool CompareCurrentPreviousState()
    {
        if (previousArrayMatrix == null)
        {
            return false;
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (currentArrayMatrix[i, j] != previousArrayMatrix[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void PrintMatrix(char[,] matrix)
    {
        Console.WriteLine("It's your new matrix");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(currentArrayMatrix[i, j] + "     ");
            }

            Console.WriteLine();
        }
    }
}