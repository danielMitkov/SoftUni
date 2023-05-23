char[][] matrix = new char[int.Parse(Console.ReadLine())][];
string racingNum = Console.ReadLine();
int km = 0;
int carRow = 0;
int carCol = 0;
for(int row = 0;row < matrix.Length;++row)
{
    matrix[row] = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
}
bool hasFinished = false;
string input = string.Empty;
while((input = Console.ReadLine()) != "End")
{
    if(input == "left") carCol--;
    if(input == "right") carCol++;
    if(input == "up") carRow--;
    if(input == "down") carRow++;
    if(matrix[carRow][carCol] == '.') km += 10;
    if(matrix[carRow][carCol] == 'T')
    {
        matrix[carRow][carCol] = '.';
        int tRow = 0;
        int tCol = 0;
        for(int row = 0;row < matrix.Length;++row)
        {
            int col = matrix[row].ToList().IndexOf('T');
            if(col > -1)
            {
                tRow = row;
                tCol = col;
                break;
            }
        }
        carRow = tRow;
        carCol = tCol;
        matrix[carRow][carCol] = '.';
        km += 30;
    }
    if(matrix[carRow][carCol] == 'F')
    {
        hasFinished = true;
        km += 10;
        Console.WriteLine($"Racing car {racingNum} finished the stage!");
        break;
    }
}
if(!hasFinished) Console.WriteLine($"Racing car {racingNum} DNF.");
Console.WriteLine($"Distance covered {km} km.");
matrix[carRow][carCol] = 'C';
foreach(char[] row in matrix) Console.WriteLine(string.Join("",row));
