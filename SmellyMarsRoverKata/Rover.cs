namespace MarsRoverKata
{
    public class Rover
    {
        public Rover(int x, int y, string direction)
        {
            X = x;
            Y = y;
            this.Direction = direction;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public string Direction { get; private set; }

        public void Receive(string commandsSequence)
        {
            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                string command = commandsSequence.Substring(i, i + 1);

                if (command == "l" || command == "r")
                {

                    // Rotate Rover
                    if (Direction == "N")
                    {
                        if (command == "r")
                        {
                            Direction = "E";
                        }
                        else
                        {
                            Direction = "W";
                        }
                    }
                    else if (Direction == "S")
                    {
                        if (command == "r")
                        {
                            Direction = "W";
                        }
                        else
                        {
                            Direction = "E";
                        }
                    }
                    else if (Direction == "W")
                    {
                        if (command == "r")
                        {
                            Direction = "N";
                        }
                        else
                        {
                            Direction = "S";
                        }
                    }
                    else
                    {
                        if (command == "r")
                        {
                            Direction = "S";
                        }
                        else
                        {
                            Direction = "N";
                        }
                    }
                }
                else
                {

                    // Displace Rover
                    var displacement1 = -1;

                    if (command == "f")
                    {
                        displacement1 = 1;
                    }
                    var displacement = displacement1;

                    if (Direction == "N")
                    {
                        Y += displacement;
                    }
                    else if (Direction == "S")
                    {
                        Y -= displacement;
                    }
                    else if (Direction == "W")
                    {
                        X -= displacement;
                    }
                    else
                    {
                        X += displacement;
                    }
                }
            }
        }
    }
}
