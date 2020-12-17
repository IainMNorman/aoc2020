namespace Aoc2020.Day17
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    public class LifeCube4
    {
        private Dictionary<Vector4, bool> map;

        public LifeCube4(string input)
        {
            this.map = new Dictionary<Vector4, bool>();
            var lines = input.ToLines();
            for (int x = 0; x < lines[0].Length; x++)
            {
                for (int y = 0; y < lines.Length; y++)
                {
                    this.map.Add(new Vector4(x, y, 0, 0), lines[x][y] == '#');
                }
            }
        }

        public int Population
        {
            get
            {
                return this.map.Where(x => x.Value).Count();
            }
        }

        public void Generation()
        {
            var bounds = new Bounds
            {
                XMin = (int)this.map.Where(x => x.Value == true).Min(x => x.Key.X) - 1,
                XMax = (int)this.map.Where(x => x.Value == true).Max(x => x.Key.X) + 1,
                YMin = (int)this.map.Where(x => x.Value == true).Min(x => x.Key.Y) - 1,
                YMax = (int)this.map.Where(x => x.Value == true).Max(x => x.Key.Y) + 1,
                ZMin = (int)this.map.Where(x => x.Value == true).Min(x => x.Key.Z) - 1,
                ZMax = (int)this.map.Where(x => x.Value == true).Max(x => x.Key.Z) + 1,
                WMin = (int)this.map.Where(x => x.Value == true).Min(x => x.Key.W) - 1,
                WMax = (int)this.map.Where(x => x.Value == true).Max(x => x.Key.W) + 1
            };

            var mapCopy = this.map.ToDictionary(x => x.Key, x => x.Value);

            for (int x = bounds.XMin; x <= bounds.XMax; x++)
            {
                for (int y = bounds.YMin; y <= bounds.YMax; y++)
                {
                    for (int z = bounds.ZMin; z <= bounds.ZMax; z++)
                    {
                        for (int w = bounds.WMin; w <= bounds.WMax; w++)
                        {
                            var point = new Vector4(x, y, z, w);
                            this.map.TryGetValue(point, out bool alive);
                            var count = this.CountNeighbours(point, mapCopy);
                            if (alive)
                            {
                                if (count < 2 || count > 3)
                                {
                                    this.map[point] = false;
                                }
                            }
                            else
                            {
                                if (count == 3)
                                {
                                    this.map[point] = true;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var item in this.map.Reverse().ToList())
            {
                if (item.Value == false)
                {
                    this.map.Remove(item.Key);
                }
            }
        }

        private int CountNeighbours(Vector4 point, Dictionary<Vector4, bool> map)
        {
            var count = 0;
            var i = 0;

            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    for (int z = -1; z < 2; z++)
                    {
                        for (int w = -1; w < 2; w++)
                        {
                            i++;
                            if (!(x == 0 && y == 0 && z == 0 && w == 0))
                            {
                                if (map.TryGetValue(new Vector4(point.X + x, point.Y + y, point.Z + z, point.W + w), out bool alive))
                                {
                                    if (alive)
                                    {
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return count;
        }
    }
}
