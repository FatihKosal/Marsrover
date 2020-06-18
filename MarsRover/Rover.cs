using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover
{
    public class Rover
    {
        public Rover(string roverPosition, string moveCommand)
        {
            if (string.IsNullOrWhiteSpace(roverPosition))
                throw new ApplicationException("RoverPosition must be initialized");

            if (!Regex.IsMatch(roverPosition[0].ToString(), @"^\d+$") || !Regex.IsMatch(roverPosition[1].ToString(), @"^\d+$"))
                throw new ApplicationException("RoverPosition first two input format must be numeric");

            if (Regex.IsMatch(roverPosition[2].ToString(), @"^\d+$"))
                throw new ApplicationException("RoverPosition third input character format must be string");

            positionX = int.Parse(roverPosition[0].ToString());
            positionY = int.Parse(roverPosition[1].ToString());

            switch (roverPosition[2])
            {
                case 'W':
                    direction = WestDirection.Instance;
                    break;
                case 'E':
                    direction = EastDirection.Instance;
                    break;
                case 'N':
                    direction = NorthDirection.Instance;
                    break;
                case 'S':
                    direction = SouthDirection.Instance;
                    break;

                default:
                    throw new ApplicationException("RoverPosition third input character format must be one of the values W,E,N,S ");
            }

            if (string.IsNullOrWhiteSpace(moveCommand))
                throw new ApplicationException("MoveCommand must be initialized");

            foreach (var command in moveCommand.ToCharArray())
            {
                switch (command)
                {
                    case 'L':
                        roverCommands.Add(RoverMoveCommandType.Left);
                        break;
                    case 'R':
                        roverCommands.Add(RoverMoveCommandType.Right);
                        break;
                    case 'M':
                        roverCommands.Add(RoverMoveCommandType.Move);
                        break;

                    default:
                        throw new ApplicationException("Each of moveCommand input characters format must be one of the values L,R,M ");
                }
            }

        }


        private Direction direction;

        public Direction Direction
        {
            get
            {
                return direction;
            }
        }

        private int positionX { get; set; }

        public int PositionX
        {
            get
            {
                return positionX;
            }
            set
            {
                positionX = value;
            }
        }
        private int positionY { get; set; }

        public int PositionY
        {
            get
            {
                return positionY;
            }
            set
            {
                positionY = value;
            }
        }



        private List<RoverMoveCommandType> roverCommands = new List<RoverMoveCommandType>();

        public void Move()
        {
            foreach (var roverCommand in roverCommands)
            {
                switch (roverCommand)
                {
                    case RoverMoveCommandType.Left:
                        direction = Direction.Left;
                        break;
                    case RoverMoveCommandType.Right:
                        direction = Direction.Right;
                        break;
                    case RoverMoveCommandType.Move:
                        direction.Move(this);
                        break;
                    default:
                        break;
                }

            }


        }

    }
}
