using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata.Tests
{
    public readonly struct Command
    {
        readonly char whatHasToBeDone;
    
        Command(char whatHasToBeDone)
        {
            if (whatHasToBeDone != 'M' && whatHasToBeDone != 'R' && whatHasToBeDone != 'L')
                throw new ArgumentException("Invalid command");
        
            this.whatHasToBeDone = whatHasToBeDone;
        }

        public static implicit operator Command(char command) => new Command(command);
        public static implicit operator char(Command command) => command.whatHasToBeDone;
    }

    public readonly struct Inputs
    {
        readonly Command[] commands;

        Inputs(Command[] commands)
        {
            this.commands = commands;
        }

        public static implicit operator Inputs(string input) => new(input.Select(command => (Command)command).ToArray());
        public static implicit operator string(Inputs command) => (Char[]);

    }
}