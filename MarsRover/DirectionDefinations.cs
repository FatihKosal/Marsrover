using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class EastDirection : Direction
    {
        public override RoverDirectionCodes DirectionCode => RoverDirectionCodes.East;
        public override Direction Left { get => new NorthDirection(); }
        public override Direction Right { get => new SouthDirection(); }
        public override string ToString()
        {
            return "E";
        }
    }

    public class NorthDirection : Direction
    {
        public override RoverDirectionCodes DirectionCode => RoverDirectionCodes.North;
        public override Direction Left { get => new WestDirection(); }
        public override Direction Right { get => new EastDirection(); }

        public override string ToString()
        {
            return "N";
        }
    }

    public class WestDirection : Direction
    {
        public override RoverDirectionCodes DirectionCode => RoverDirectionCodes.West;
        public override Direction Left { get => new SouthDirection(); }
        public override Direction Right { get => new NorthDirection(); }

        public override string ToString()
        {
            return "W";
        }
    }

    public class SouthDirection : Direction
    {
        public override RoverDirectionCodes DirectionCode => RoverDirectionCodes.South;
        public override Direction Left { get => new EastDirection(); }
        public override Direction Right { get => new WestDirection(); }

        public override string ToString()
        {
            return "S";
        }

    }

    public abstract class Direction
    {
        public abstract RoverDirectionCodes DirectionCode { get; }
        public abstract Direction Left { get; }
        public abstract Direction Right { get; }
    }
}
