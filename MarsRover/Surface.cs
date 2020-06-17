using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarsRover
{
    public class Surface
    {
        public Surface(string lowerLeftCoordinate, string upperRightCoordinate)
        {
            if (string.IsNullOrWhiteSpace(lowerLeftCoordinate))
                throw new ApplicationException("LowerLeftCoordinate must be initialized");

            if (string.IsNullOrWhiteSpace(upperRightCoordinate))
                throw new ApplicationException("UpperRightCoordinate must be initialized");

            string[] lowerLeftCoordinates = lowerLeftCoordinate.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            if (lowerLeftCoordinate.Length != 2)
                throw new ApplicationException("LowerLeftCoordinate input format length must be 2");

            if (!Regex.IsMatch(lowerLeftCoordinate[0].ToString(), @"^\d+$") || !Regex.IsMatch(lowerLeftCoordinate[1].ToString(), @"^\d+$"))
                throw new ApplicationException("LowerLeftCoordinate input format must be numeric");

            if (!Regex.IsMatch(upperRightCoordinate[0].ToString(), @"^\d+$") || !Regex.IsMatch(upperRightCoordinate[1].ToString(), @"^\d+$"))
                throw new ApplicationException("UpperRightCoordinate input format must be numeric");

            if(int.Parse(upperRightCoordinate) <= int.Parse(lowerLeftCoordinate))
                throw new ApplicationException("UpperRightCoordinate must be bigger than LoverLeftCoordinate");


            westEdge = int.Parse(lowerLeftCoordinate[0].ToString());
            southEdge = int.Parse(lowerLeftCoordinate[1].ToString());

            eastEdge = int.Parse(upperRightCoordinate[0].ToString());
            northEdge = int.Parse(upperRightCoordinate[1].ToString());

        }

        private int eastEdge { get; set; }

        public int EastEdge
        {
            get
            {
                return eastEdge;
            }
        }
        private int northEdge { get; set; }

        public int NorthEdge
        {
            get
            {
                return northEdge;
            }
        }
        private int westEdge { get; set; }
        public int WestEdge
        {
            get
            {
                return westEdge;
            }
        }
        private int southEdge { get; set; }

        public int SouthEdge
        {
            get
            {
                return southEdge;
            }
        }

        public List<Rover> PlacedRovers = new List<Rover>();
        public void PlaceRover(Rover rover)
        {
            PlacedRovers.Add(rover);
        }
    }
}
