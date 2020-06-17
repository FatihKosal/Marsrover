using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class EastDirection : Direction
    {
        public EastDirection(Rover rover) : base(rover)
        { }
        public override RoverDirectionCodes DirectionCode => RoverDirectionCodes.East;
        public override Direction Left { get => new NorthDirection(this.Rover); }
        public override Direction Right { get => new SouthDirection(this.Rover); }
        public override void Move()
        {
            this.Rover.PositionX++;
        }
        public override string ToString()
        {
            return "E";
        }
    }

    public class NorthDirection : Direction
    {
        public NorthDirection(Rover rover) : base(rover)
        { }
        public override RoverDirectionCodes DirectionCode => RoverDirectionCodes.North;
        public override Direction Left { get => new WestDirection(this.Rover); }
        public override Direction Right { get => new EastDirection(this.Rover); }

        public override void Move()
        {
            this.Rover.PositionY++;
        }
        public override string ToString()
        {
            return "N";
        }
    }

    public class WestDirection : Direction
    {
        public WestDirection(Rover rover) : base(rover)
        { }
        public override RoverDirectionCodes DirectionCode => RoverDirectionCodes.West;
        public override Direction Left { get => new SouthDirection(this.Rover); }
        public override Direction Right { get => new NorthDirection(this.Rover); }

        public override void Move()
        {
            this.Rover.PositionX--;
        }
        public override string ToString()
        {
            return "W";
        }
    }

    public class SouthDirection : Direction
    {
        public SouthDirection(Rover rover) : base(rover)
        { }
        public override RoverDirectionCodes DirectionCode => RoverDirectionCodes.South;
        public override Direction Left { get => new EastDirection(this.Rover); }
        public override Direction Right { get => new WestDirection(this.Rover); }

        public override void Move()
        {
            this.Rover.PositionY--;
        }

        public override string ToString()
        {
            return "S";
        }

    }

    public abstract class Direction
    {
        public Rover Rover;
        public Direction(Rover rover)
        {
            this.Rover = rover;
        }

        public abstract void Move();
        public abstract RoverDirectionCodes DirectionCode { get; }
        public abstract Direction Left { get; }
        public abstract Direction Right { get; }
    }
}
