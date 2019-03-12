namespace Kata7 {
    public sealed class Block {
        public Block (int value, int x, int y) {
            this.Value = value;
            this.X = x;
            this.Y = y;
        }
        public bool Used { get; }
        public int Value { get; }
        public int X { get; }
        public int Y { get; }

    }
}