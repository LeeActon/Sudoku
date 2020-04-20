using System;
using SparksInTheSoftware.Sudoku;

namespace SparksInTheSoftware.PuzzleTester
    {
    class Program
        {
        static void Main(string[] args)
            {
            Puzzle puzzle = Puzzle.GeneratePuzzle();

            puzzle.Solve(10);

            if (puzzle.Solutions.Count > 0)
                {
                Console.WriteLine((puzzle.Solutions.Count > 1) ? "Solutions:" : "Solution:");
                foreach (Puzzle solution in puzzle.Solutions)
                    {
                    for (int row = 0; row < 9; row++)
                        {
                        if ((row % 3) == 0)
                            Console.WriteLine();

                        Console.WriteLine(String.Format("{0} {1} {2}  {3} {4} {5}  {6} {7} {8}",
                            solution.Cells[row, 0].Value,
                            solution.Cells[row, 1].Value,
                            solution.Cells[row, 2].Value,
                            solution.Cells[row, 3].Value,
                            solution.Cells[row, 4].Value,
                            solution.Cells[row, 5].Value,
                            solution.Cells[row, 6].Value,
                            solution.Cells[row, 7].Value,
                            solution.Cells[row, 8].Value
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
