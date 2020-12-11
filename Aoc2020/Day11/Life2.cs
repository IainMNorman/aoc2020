namespace AoC2020.Day11
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    using Aoc2020;

    public class Life2
    {
        private readonly int width;
        private readonly int height;
        private char[,] map;

        public Life2(string input)
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
                    var visibleOccupied = this.CountVisibleOccupiedNeighbours(x, y, mapCopy);
                    if (mapCopy[x, y] != '.')
                    {
                        var occupied = this.map[x, y] == '#';

                        if (occupied)
                        {
                            if (visibleOccupied >= 5)
                            {
                                this.map[x, y] = 'L';
                            }
                        }
                        else
                        {
                            if (visibleOccupied == 0)
                            {
                                this.map[x, y] = '#';
                            }
                        }
                    }
                }
            }
        }

        public int CountVisibleOccupiedNeighbours(int x, int y, char[,] map)
        {
            var count = 0;

            var directions = new Vector2[]
            {
                new Vector2(-1, -1),
                new Vector2(0, -1),
                new Vector2(1, -1),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1),
                new Vector2(-1, 1),
                new Vector2(-1, 0)
            };

            foreach (var dir in directions)
            {
                if (this.IsDirectionOccupied(dir, new Vector2(x, y), map))
                {
                    count++;
                }
            }

            return count;
        }

        public bool IsDirectionOccupied(Vector2 direction, Vector2 seat, char[,] map)
        {
            while (true)
            {
                seat = seat + direction;

                if (seat.X < 0 || seat.Y < 0 || seat.X >= this.width || seat.Y >= this.height)
                {
                    return false;
                }

                if (map[(int)seat.X, (int)seat.Y] == '#')
                {
                    return true;
                }

                if (map[(int)seat.X, (int)seat.Y] == 'L')
                {
                    return false;
                }
            }
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