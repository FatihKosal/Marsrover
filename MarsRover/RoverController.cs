using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class RoverController
    {
        public string SendCommand(string commandStr)
        {
            if (string.IsNullOrWhiteSpace(commandStr))
                throw new ApplicationException("Command must be initialized");

            string[] commandLines = commandStr.Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            if (!(commandLines.Length >= 3 && commandLines.Length % 2 == 1))
                throw new ApplicationException("CommandStr lines must be bigger than 3 and odd");

            string loverLeftCoordinate = "00";            

            Surface surface = new Surface(loverLeftCoordinate, commandLines[0]);

            StringBuilder builder = new StringBuilder();

            for (int i = 1; i < commandLines.Length; i = i + 2)
            {
                Rover rover = new Rover(commandLines[i], commandLines[i + 1]);
                rover.Move();
                if (rover.PositionX > surface.EastEdge)
                    throw new ApplicationException("Surface EastEdge could not be passed");
                if (rover.PositionX < surface.WestEdge)
                    throw new ApplicationException("Surface WestEdge could not be passed");
                if (rover.PositionY > surface.NorthEdge)
                    throw new ApplicationException("Surface NorthEdge could not be passed");
                if (rover.PositionY < surface.SouthEdge)
                    throw new ApplicationException("Surface SouthEdge could not be passed");

                foreach (var placedRover in surface.PlacedRovers)
                {
                    if(rover.PositionX == placedRover.PositionX && rover.PositionY == placedRover.PositionY)
                        throw new ApplicationException(string.Format("There is already a rover in this position {0}{1}", rover.PositionX, rover.PositionY)); ;
                }

                surface.PlaceRover(rover);
                builder.AppendLine(rover.PositionX.ToString() + rover.PositionY.ToString() + rover.Direction.ToString());
            }


            return builder.ToString();
        }
    }
}
