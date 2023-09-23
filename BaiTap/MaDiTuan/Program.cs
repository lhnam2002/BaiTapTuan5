using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaDiTuan
{
    class Program
    {
        static int N = 8;
        static int[] moveX = { 2, 1, -1, -2, -2, -1, 1, 2 };
        static int[] moveY = { 1, 2, 2, 1, -1, -2, -2, -1 };

        static bool IsSafe(int x, int y, int[,] sol)
        {
            return (x >= 1 && y >= 1 && x <= N && y <= N && sol[x, y] == -1);
        }

        static int CountMoves(int x, int y, int[,] sol)
        {
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                int nextX = x + moveX[i];
                int nextY = y + moveY[i];

                if (IsSafe(nextX, nextY, sol))
                    count++;
            }
            return count;
        }

        static bool SolveKnightTour(int x, int y, int moveCount, int[,] sol)
        {
            if (moveCount == N * N)
                return true;

            int minMove = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < 8; i++)
            {
                int nextX = x + moveX[i];
                int nextY = y + moveY[i];

                if (IsSafe(nextX, nextY, sol))
                {
                    int numMoves = CountMoves(nextX, nextY, sol);
                    if (numMoves < minMove)
                    {
                        minMove = numMoves;
                        minIndex = i;
                    }
                }
            }

            if (minIndex != -1)
            {
                int nextX = x + moveX[minIndex];
                int nextY = y + moveY[minIndex];
                sol[nextX, nextY] = moveCount;
                if (SolveKnightTour(nextX, nextY, moveCount + 1, sol))
                    return true;
                else
                    sol[nextX, nextY] = -1;
            }

            return false;
        }

        static void PrintSolution(int[,] sol)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                    Console.Write(sol[i, j].ToString().PadLeft(2) + " ");
                Console.WriteLine();
            }
        }

        static void Main()
        {
            int[,] sol = new int[N + 1, N + 1];
            for (int i = 1; i <= N; i++)
                for (int j = 1; j <= N; j++)
                    sol[i, j] = -1;

            int start_x = 3, start_y = 2;
            sol[start_x, start_y] = 0;

            if (SolveKnightTour(start_x, start_y, 1, sol))
                PrintSolution(sol);
            else
                Console.WriteLine("Không có giải pháp");
            Console.ReadLine();
        }
    }
}
