using System;
using System.Collections.Generic;

namespace Sudoku
    {
    public class Puzzle
        {
        private const int rows = 9;
        private const int columns = 9;
        private const int rowsInBlock = 3;
        private const int columnsInBlock = 3;

        private byte [,] data;
        public int EmptyCells { get; set; }

        private List<Puzzle> solutions;
        public List<Puzzle> Solutions
            {
            get
                {
                if (this.solutions == null)
                    this.solutions = new List<Puzzle>();

                return this.solutions;
                }
            }

        public Puzzle()
            {
            this.data = new byte[rows,columns];
            this.solutions = null;
            }

        public Puzzle(byte [,] newData)
            {
            this.data = new byte[rows, columns];

            for (int row = 0; row < rows; row++)
                {
                for (int column = 0; column < columns; column++)
                    {
                    byte value = newData[row, column];

                    this.data[row, column] = value;

                    if (value == 0)
                        EmptyCells++;
                    }
                }
            }

        public void Clear()
            {
            this.EmptyCells = rows * columns;
            for (int row = 0; row < rows; row++)
                {
                for (int column = 0; column < columns; column++)
                    {
                    this.data[row, column] = 0;
                    }
                }
            }

        public void SetValue(int row, int column, byte value)
            {
            if (IsValueInUse(row, column, value))
                value = 0;

            byte oldValue = this.data[row, column];

            this.data[row, column] = value;

            if (oldValue != value)
                {
                if (value == 0)
                    {
                    EmptyCells++;
                    }
                else if (oldValue == 0)
                    {
                    EmptyCells--;
                    }
                }
            }

        public byte GetValue(int row, int column)
            {
            return this.data[row, column];
            }

        public bool IsValueInRow(int row, byte value)
            {
            for (int column = 0; column < columns; column++)
                {
                if (this.data[row, column] == value)
                    return true;
                }

            return false;
            }
        public bool IsValueInColumn(int column, byte value)
            {
            for (int row = 0; row < rows; row++)
                {
                if (this.data[row, column] == value)
                    return true;
                }

            return false;
            }

        public bool IsValueInBlock(int testRow, int testColumn, byte value)
            {
            int rowBlock = testRow / rowsInBlock;
            int rowStart = rowBlock * rowsInBlock;
            int rowEnd = rowStart + rowsInBlock;
            int columnBlock = testColumn / columnsInBlock;
            int columnStart = columnBlock * columnsInBlock;
            int columnEnd = columnStart + columnsInBlock;

            for (int row = rowStart; row < rowEnd; row++)
                {
                for (int column = columnStart; column < columnEnd; column++)
                    {
                    if (this.data[row, column] == value)
                        return true;
                    }
                }

            return false;
            }

        public bool IsValueInUse(int row, int column, byte value)
            {
            return IsValueInRow(row, value) || IsValueInColumn(column, value) || IsValueInBlock(row, column, value);
            }

        public void Solve()
            {
            for (int row = 0; row < rows; row++)
                {
                for (int column = 0; column < columns; column++)
                    {
                    if (this.data[row, column] == 0)
                        {
                        for (byte value = 1; value <= 9; value++)
                            {
                            if (!IsValueInUse(row, column, value))
                                {
                                SetValue(row, column, value);
                                Solve();
                                SetValue(row, column, 0);
                                }
                            }

                        return;
                        }
                    }
                }
             
            Solutions.Add(new Puzzle(this.data));
            }
        }
    }
