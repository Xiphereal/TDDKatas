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

        private const char N = 'N';
        private const char E = 'E';
        private const char S = 'S';
        private const char W = 'W';

        public Rover(int x, int y, char direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public char Direction { get; private set; }

        public void Receive(string commandsSequence)
        {
            foreach (char command in commandsSequence)
                Process(command);
        }

        private void Process(char command)
        {
            if (!allowedCommands.Contains(command))
                throw new ArgumentException();

            if (command == l || command == r)
                Rotate(command);
            else
                DisplaceTowardsFacingDirection();
        }

        private void DisplaceTowardsFacingDirection()
        {
            var displacement = 1;

            if (Direction == N)
                Y += displacement;
            else if (Direction == S)
                Y -= displacement;
            else if (Direction == W)
                X -= displacement;
            else
                X += displacement;
        }

        private void Rotate(char command)
        {
            if (Direction == N)
            {
                if (command == r)
                    Direction = E;
                else
                    Direction = W;
            }
            else if (Direction == S)
            {
                if (command == r)
                    Direction = W;
                else
                    Direction = E;
            }
            else if (Direction == W)
            {
                if (command == r)
                    Direction = N;
                else
                    Direction = S;
            }
            else
            {
                if (command == r)
                    Direction = S;
                else
                    Direction = N;
            }
        }
    }
}
