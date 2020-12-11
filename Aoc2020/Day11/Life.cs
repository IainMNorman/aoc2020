namespace AoC2020.Day11
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Aoc2020;

    public class Life
    {
        private readonly int width;
        private readonly int height;
        private char[,] map;

        public Life(string input)
        {
            var lines = input.ToLines();

            this.width = lines[0].Length;
            this.height = lines.Length;

            this.map = new char[this.width, this.height];

            for (int x = 0; x < this.width; x++)
            {
                for (int y = 0; y < this.height; y++)
                {
                    this.map[x, y] = lines[y][x];
                }
            }
        }

        public int HashCode() => this.map.GetHashCode();

        public void Generatation()
        {
            var mapCopy = this.map.Clone() as char[,];

            for (int x = 0; x < this.width; x++)
            {
                for (int y = 0; y < this.height; y++)
                {
                    var occupiedNeighbours = this.CountOccupiedNeighbours(x, y, mapCopy);
                    if (mapCopy[x, y] != '.')
                    {
                        var occupied = this.map[x, y] == '#';

                        if (occupied)
                        {
                            if (occupiedNeighbours >= 4)
                            {
                                this.map[x, y] = 'L';
                            }
                        }
                        else
                        {
                            if (occupiedNeighbours == 0)
                            {
                                this.map[x, y] = '#';
                            }
                        }
                    }
                }
            }
        }

        public int CountOccupiedNeighbours(int x, int y, char[,] map)
        {
            var count = 0;
            if (this.GetValue(x - 1, y - 1, map) == '#')
            {
                count++;
            }

            if (this.GetValue(x, y - 1, map) == '#')
            {
                count++;
            }

            if (this.GetValue(x + 1, y - 1, map) == '#')
            {
                count++;
            }

            if (this.GetValue(x + 1, y, map) == '#')
            {
                count++;
            }

            if (this.GetValue(x + 1, y + 1, map) == '#')
            {
                count++;
            }

            if (this.GetValue(x, y + 1, map) == '#')
            {
                count++;
            }

            if (this.GetValue(x - 1, y + 1, map) == '#')
            {
                count++;
            }

            if (this.GetValue(x - 1, y, map) == '#')
            {
                count++;
            }

            return count;
        }

        public char GetValue(int x, int y, char[,] map)
        {
            if (x < 0 || y < 0 || x >= this.width || y >= this.height)
            {
                return '.';
            }
            else
            {
                return map[x, y];
            }
        }

        public string Render()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    sb.Append(this.map[x, y]);
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }

        public int OccupiedSeats()
        {
            var count = 0;
            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    if (this.map[x, y] == '#')
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}