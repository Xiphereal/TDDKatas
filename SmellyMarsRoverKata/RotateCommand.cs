namespace MarsRoverKata
{
    public readonly struct RotateCommand
    {
        private readonly char value;

        public RotateCommand(char str)
        {
            value = str;
        }

        public static implicit operator RotateCommand(char str) =>
            new RotateCommand(str);

        public static implicit operator char(RotateCommand str) =>
            str.value;
    }
}
