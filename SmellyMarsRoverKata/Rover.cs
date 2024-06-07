namespace MarsRoverKata
{
    public class Rover
    {
        private string direction;
        private int y;
        private int x;

        public Rover(int x, int y, string direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
        }

        public void Receive(string commandsSequence)
        {
            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                string command = commandsSequence.Substring(i, i + 1);

                if (command == "l" || command == "r")
                {

                    // Rotate Rover
                    if (this.direction == "N")
                    {
                        if (command == "r")
                        {
                            this.direction = "E";
                        }
                        else
                        {
                            this.direction = "W";
                        }
                    }
                    else if (this.direction == "S")
                    {
                        if (command == "r")
                        {
                            this.direction = "W";
                        }
                        else
                        {
                            this.direction = "E";
                        }
                    }
                    else if (this.direction == "W")
                    {
                        if (command == "r")
                        {
                            this.direction = "N";
                        }
                        else
                        {
                            this.direction = "S";
                        }
                    }
                    else
                    {
                        if (command == "r")
                        {
                            this.direction = "S";
                        }
                        else
                        {
                            this.direction = "N";
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

                    if (this.direction == "N")
                    {
                        this.y += displacement;
                    }
                    else if (this.direction == "S")
                    {
                        this.y -= displacement;
                    }
                    else if (this.direction == "W")
                    {
                        this.x -= displacement;
                    }
                    else
                    {
                        this.x += displacement;
                    }
                }
            }
        }
    }
}
