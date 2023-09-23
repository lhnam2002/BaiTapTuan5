using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Hau
{
    class Program
    {
        static int N = 8;

        static bool IsSafe(int[,] board, int row, int col)
        {
            int i, j;

            for (i = 1; i <= col; i++)
                if (board[row, i] == 1)
                    return false;

            for (i = row, j = col; i > 0 && j > 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            for (i = row, j = col; j <= N && i > 0; i--, j++)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        static bool SolveNQUtil(int[,] board, int col)
        {
            if (col > N)
                return true;

            for (int i = 1; i <= N; i++)
            {
                if (IsSafe(board, i, col))
                {
                    board[i, col] = 1;

                    if (SolveNQUtil(board, col + 1))
                        return true;

                    board[i, col] = 0; // Backtrack
                }
            }

            return false;
        }

        static void PrintSolution(int[,] board)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                    Console.Write(board[i, j] + " ");
                Console.WriteLine();
            }
        }

        static bool SolveNQ(int startRow, int startCol)
        {
            int[,] board = new int[N + 1, N + 1];
            board[startRow, startCol] = 1;

            if (SolveNQUtil(board, startCol + 1) == false)
            {
                Console.WriteLine("Không có giải pháp");
                return false;
            }

            PrintSolution(board);
            return true;
        }

        static void Main()
        {
            int startRow = 1; // Hàng muốn đặt con hậu đầu tiên (từ 1 đến 8)
            int startCol = 1; // Cột muốn đặt con hậu đầu tiên (từ 1 đến 8)

            if (SolveNQ(startRow, startCol))
                Console.WriteLine("Có giải pháp!");
            else
                Console.WriteLine("Không có giải pháp");
            Console.Read();
        }
    }
}
