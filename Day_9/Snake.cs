using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_09
{
    internal class Snake
    {
        private int _numberOfBodyElements;
        public Position[] BodyPositions { get; private set; }
        public List<Position> TailPositionHistory { get; private set; }
        public List<Position> HeadPositionHistory { get; private set; }

        public Snake(int numberOfBodyElements)
        {
            _numberOfBodyElements = numberOfBodyElements;
            BodyPositions = new Position[_numberOfBodyElements];
            for (int i = 0; i < _numberOfBodyElements; i++)
                BodyPositions[i] = new Position(0, 0);
            TailPositionHistory = new List<Position>();
            HeadPositionHistory = new List<Position>();
        }

        private void MoveUp()
        {
            BodyPositions[0].Up();
        }
        private void MoveDown()
        {
            BodyPositions[0].Down();
        }
        private void MoveLeft()
        {
            BodyPositions[0].Left();
        }
        private void MoveRight()
        {
            BodyPositions[0].Right();
        }

        public void MoveByCommand(string command)
        {
            var splited = command.Split(' ');
            for(int i = 0; i < Convert.ToInt32(splited[1]); i++)
            {
                MoveInDirection(splited[0]);
                for (int j = 1; j < BodyPositions.Length; j++)
                {
                    SetNewBodyPosition(j);
                }
                TailPositionHistory.Add(BodyPositions[_numberOfBodyElements - 1].GetCopy());
                HeadPositionHistory.Add(BodyPositions[0].GetCopy());
            }
            ;
        }

        private void SetNewBodyPosition(int j)
        {
            if (Math.Abs(BodyPositions[j].X - BodyPositions[j - 1].X) == 2 && Math.Abs(BodyPositions[j].Y - BodyPositions[j - 1].Y) == 2)
                BodyPositions[j].SetPosition(CountPosition(BodyPositions[j - 1].X,BodyPositions[j].X),
                                             CountPosition(BodyPositions[j - 1].Y, BodyPositions[j].Y));
            if (Math.Abs(BodyPositions[j].X - BodyPositions[j - 1].X) == 2)
                BodyPositions[j].SetPosition(CountPosition(BodyPositions[j - 1].X, BodyPositions[j].X), BodyPositions[j - 1].Y);
            if (Math.Abs(BodyPositions[j].Y - BodyPositions[j - 1].Y) == 2)
                BodyPositions[j].SetPosition(BodyPositions[j - 1].X, CountPosition(BodyPositions[j - 1].Y, BodyPositions[j].Y));
        }

        private int CountPosition(int pos1, int pos2)
        {
            if (pos1 < pos2)
                return pos2 - 1;
            return pos2 + 1;
        }

        private void MoveInDirection(string command)
        {
            switch (command)
            {
                case "U": 
                    MoveUp();
                    break;
                case "D":
                    MoveDown();
                    break;
                case "L":
                    MoveLeft();
                    break;
                case "R":
                    MoveRight();
                    break;
                default:
                    break;
            }
        }
    }
}
