using System;

namespace MarsRoverKata
{
    public readonly struct RotateCommand
    {
        private const char r = 'r';
        private const char l = 'l';

        private readonly char value;

        public RotateCommand(char str)
        {
            if (!IsOne(str))
                throw new ArgumentException();

            value = str;
        }

        public static bool IsOne(char command) => command == l || command == r;

        public static implicit operator RotateCommand(char str) =>
            new RotateCommand(str);

        public static implicit operator char(RotateCommand str) =>
            str.value;
    }
}
