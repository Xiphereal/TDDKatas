using System;
using System.Linq;

namespace MarsRoverKata
{
    public class Rover
    {
        private const char r = 'r';
        private const char l = 'l';
        private const char f = 'f';
        private static readonly char[] allowedCommands = [r, l, f];

        public Rover(int x, int y, string direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public string Direction { get; private set; }

        public void Receive(string commandsSequence)
        {
            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                char command = commandsSequence.ElementAt(i);

                Process(command);
            }
        }

        private void Process(char command)
        {
            if (!allowedCommands.Contains(command))
                throw new ArgumentException();

            if (command == l || command == r)
                Rotate(command);
            else
                Displace(command);
        }

        private void Displace(char command)
        {
            var displacement1 = -1;

            if (command == f)
                displacement1 = 1;
            var displacement = displacement1;

            if (Direction == "N")
                Y += displacement;
            else if (Direction == "S")
                Y -= displacement;
            else if (Direction == "W")
                X -= displacement;
            else
                X += displacement;
        }

        private void Rotate(char command)
        {
            if (Direction == "N")
            {
                if (command == r)
                    Direction = "E";
                else
                    Direction = "W";
            }
            else if (Direction == "S")
            {
                if (command == r)
                    Direction = "W";
                else
                    Direction = "E";
            }
            else if (Direction == "W")
            {
                if (command == r)
                    Direction = "N";
                else
                    Direction = "S";
            }
            else
            {
                if (command == r)
                    Direction = "S";
                else
                    Direction = "N";
            }
        }
    }
}
