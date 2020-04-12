using System;

namespace PuzzleTester
    {
    class Program
        {
        static byte [,] puzzle1 =
            {
            { 0, 0, 0,   0, 0, 0,   0, 5, 3 },
            { 0, 0, 2,   7, 0, 9,   0, 4, 0 },
            { 0, 0, 7,   8, 0, 0,   0, 0, 0 },

            { 0, 3, 0,   0, 0, 0,   0, 0, 6 },
            { 0, 0, 0,   9, 0, 1,   0, 0, 0 },
            { 0, 8, 9,   0, 0, 2,   0, 0, 7 },

            { 4, 0, 0,   0, 0, 0,   2, 0, 0 },
            { 1, 0, 0,   0, 6, 0,   9, 0, 0 },
            { 8, 0, 0,   0, 4, 0,   0, 0, 0 },
            };
        static void Main(string[] args)
            {
            Sudoku.Puzzle puzzle = new Sudoku.Puzzle(puzzle1);

            puzzle.Solve(10);

            if (puzzle.Solutions.Count > 0)
                {
                Console.WriteLine((puzzle.Solutions.Count > 1) ? "Solutions:" : "Solution:");
                foreach (Sudoku.Puzzle solution in puzzle.Solutions)
                    {
                    for (int row = 0; row < 9; row++)
                        {
                        if ((row % 3) == 0)
                            Console.WriteLine();

                        Console.WriteLine(String.Format("{0} {1} {2}  {3} {4} {5}  {6} {7} {8}",
                            solution.GetValue(row, 0),
                            solution.GetValue(row, 1),
                            solution.GetValue(row, 2),
                            solution.GetValue(row, 3),
                            solution.GetValue(row, 4),
                            solution.GetValue(row, 5),
                            solution.GetValue(row, 6),
                            solution.GetValue(row, 7),
                            solution.GetValue(row, 8)
                            ));

                        }
                    Console.WriteLine("--------------------------------------");
                    }
                }
            else
                {
                Console.WriteLine("No solution found!");
                }
            }
        }
    }
