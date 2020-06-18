using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class EastDirection : Direction
    {
        #region Singleton Implementation
        private static readonly EastDirection instance = new EastDirection();  
        static EastDirection()
        {
        }
        private EastDirection()
        {
        }
        public static EastDirection Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        public override RoverDirectionCodes DirectionCode => RoverDirectionCodes.East;
        public override Direction Left { get => NorthDirection.Instance; }
        public override Direction Right { get => SouthDirection.Instance; }
        public override void Move(Rover rover)
        {
            rover.PositionX++;
        }
        public override string ToString()
        {
            return "E";
        }
    }

    public class NorthDirection : Direction
    {
        #region Singleton Implementation
        private static readonly NorthDirection instance = new NorthDirection();
        static NorthDirection()
        {
        }
        private NorthDirection()
        {
        }
        public static NorthDirection Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        public override RoverDirectionCodes DirectionCode => RoverDirectionCodes.North;
        public override Direction Left { get => WestDirection.Instance; }
        public override Direction Right { get => EastDirection.Instance; }

        public override void Move(Rover rover)
        {
            rover.PositionY++;
        }
        public override string ToString()
        {
            return "N";
        }
    }

    public class WestDirection : Direction
    {
        #region Singleton Implementation
        private static readonly WestDirection instance = new WestDirection();
        static WestDirection()
        {
        }
        private WestDirection()
        {
        }
        public static WestDirection Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        public override RoverDirectionCodes DirectionCode => RoverDirectionCodes.West;
        public override Direction Left { get => SouthDirection.Instance; }
        public override Direction Right { get => NorthDirection.Instance; }

        public override void Move(Rover rover)
        {
            rover.PositionX--;
        }
        public override string ToString()
        {
            return "W";
        }
    }

    public class SouthDirection : Direction
    {
        #region Singleton Implementation
        private static readonly SouthDirection instance = new SouthDirection();
        static SouthDirection()
        {
        }
        private SouthDirection()
        {
        }
        public static SouthDirection Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        public override RoverDirectionCodes DirectionCode => RoverDirectionCodes.South;
        public override Direction Left { get => EastDirection.Instance; }
        public override Direction Right { get => WestDirection.Instance; }

        public override void Move(Rover rover)
        {
            rover.PositionY--;
        }

        public override string ToString()
        {
            return "S";
        }

    }

    public abstract class Direction
    {
        public abstract void Move(Rover rover);
        public abstract RoverDirectionCodes DirectionCode { get; }
        public abstract Direction Left { get; }
        public abstract Direction Right { get; }
    }
}
