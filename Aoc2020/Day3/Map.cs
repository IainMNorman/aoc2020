namespace Aoc2020.Day3
{
    using System.Text;

    public class Map
    {
        public Map(string input, int cursorX = 0, int cursorY = 0)
        {
            var lines = input.ToStringArray();

            this.Cells = new char[lines[0].Length * lines.Length];
            this.Width = lines[0].Length;

            for (int y = 0; y < this.Height; y++)
            {
                lines[y].ToCharArray().CopyTo(this.Cells, y * this.Width);
            }

            this.Cursor = new Point(cursorX, cursorY);
        }

        public int Width { get; set; }

        public int Height
        {
            get { return this.Cells.Length / this.Width; }
        }

        public Point Cursor { get; set; }

        public char[] Cells { get; set; }

        public char Cell(Point p)
        {
            return this.Cells[(p.Y * this.Width) + p.X];
        }

        public char Cell(int x, int y)
        {
            return this.Cell(new Point(x, y));
        }

        public void Move(int dx, int dy)
        {
            this.Cursor.X = (this.Cursor.X + dx) % this.Width;
            this.Cursor.Y = this.Cursor.Y + dy;
        }

        public string Render()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    sb.Append(this.Cell(x, y));
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}
