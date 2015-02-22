using System;
using System.Drawing;

namespace MazeBuilder
{
    public class Maze
    {
        private int _dimension;
        private int _playerRow, _playerCol;
        private Room[,] _rooms;

        public Maze()
        {
            _playerRow = 0;
            _playerCol = 0;
        }

        public int GetDimension()
        {
            return _dimension;
        }

        public void SetDimension(int num)
        {
            _dimension = num;
        }

        public Room[,] GetRooms()
        {
            return _rooms;
        }

        public void SetRooms(Room[,] roomToSet)
        {
            _rooms = roomToSet;
        }

        public override string ToString()
        {
            var maze = "";
            int i, j;

            for (i = 0; i < _rooms.GetLength(0); i++)
            {
                // build north doors
                for (j = 0; j < _rooms.GetLength(1); j++)
                {
                    maze += "*";
                    if (_rooms[i, j].GetNorthDoor().IsLocked())
                        maze += "x";
                    else
                        maze += "-";
                }

                maze += "*" + Environment.NewLine;
                for (j = 0; j < _rooms.GetLength(1); j++)
                {
                    if (_rooms[i, j].GetWestDoor().IsLocked())
                        maze += "x";
                    else
                        maze += "|";
                    if (_rooms[i, j].IsExit())
                        maze += "E";
                    else if (i == _playerRow && j == _playerCol)
                        maze += "P";
                    else
                        maze += " ";
                    maze += " ";
                }
                if (_rooms[i, j - 1].GetEasthDoor().IsLocked())
                    maze += "x";
                else
                    maze += "|";
                maze += Environment.NewLine;
            }
            for (j = 0; j < _rooms.GetLength(1); j++)
            {
                maze += "*";
                if (_rooms[_rooms.GetLength(0) - 1, j].GetSouthDoor().IsLocked())
                    maze += "x";
                else
                    maze += "-";
            }
            maze += "*" + Environment.NewLine;
            return maze;
        }

        public void MoveNorth()
        {
            var curRoom = _rooms[_playerRow, _playerCol];
            if (!curRoom.GetNorthDoor().CanPass())
                DoorIsLockedMessage();
            else
            {
                _playerRow--;
                if (_playerRow < 0)
                    _playerRow = _rooms.Length - 1;
            }
        }

        private string DoorIsLockedMessage()
        {
            return "Door is Locked, find another way around.";
        }

        public void MoveSouth()
        {
            var curRoom = _rooms[_playerRow, _playerCol];

            if (!curRoom.GetSouthDoor().CanPass())
                DoorIsLockedMessage();
            else
            {
                _playerRow++;
                if (_playerRow >= _rooms.Length)
                    _playerRow = 0;
            }
        }

        public void MoveEast()
        {
            var curRoom = _rooms[_playerRow, _playerCol];
            if (!curRoom.GetEasthDoor().CanPass())
                DoorIsLockedMessage();
            else
            {
                _playerCol++;
                if (_playerCol >= _rooms.Length)
                    _playerCol = 0;
            }
        }

        public void MoveWest()
        {
            var curRoom = _rooms[_playerRow, _playerCol];
            if (!curRoom.GetWestDoor().CanPass())
                DoorIsLockedMessage();
            else
            {
                _playerCol--;
                if (_playerCol < 0)
                    _playerCol = _rooms.Length - 1;
            }
        }

        public bool PlayerInExit()
        {
            return _rooms[_playerRow, _playerCol].IsExit();
        }

        public Point GetPosition()
        {
            return new Point(_playerRow, _playerRow);
        }

        public Room GetCurrentRoom()
        {
            return _rooms[_playerRow, _playerCol];
        }

        public bool MazeTraversal()
        {
            var grid = new bool[_dimension, _dimension];

            for (var i = 0; i < _dimension; i++)
                for (var j = 0; j < _dimension; j++)
                    grid[i, j] = false;

            MazeTraversalHelper(_playerRow, _playerCol, grid);

            return grid[_dimension - 1, _dimension - 1];
        }

        private void MazeTraversalHelper(int row, int col, bool[,] grid)
        {
            var curRoom = _rooms[row, col];
            grid[row, col] = true;
            if (curRoom.IsExit())
                return;

            int northRow = row - 1,
                northCol = col,
                southRow = row + 1,
                southCol = col,
                eastRow = row,
                eastCol = col + 1,
                westRow = row,
                westCol = col - 1;

            if (northRow < 0)
                northRow = _dimension - 1;
            if (southRow >= _dimension)
                southRow = 0;
            if (eastCol >= _dimension)
                eastCol = 0;
            if (westCol < 0)
                westCol = _dimension - 1;

            if (!curRoom.GetNorthDoor().IsLocked() && !grid[northRow, northCol])
                MazeTraversalHelper(northRow, northCol, grid);
            if (!curRoom.GetSouthDoor().IsLocked() && !grid[southRow, northCol])
                MazeTraversalHelper(southRow, southCol, grid);
            if (!curRoom.GetEasthDoor().IsLocked() && !grid[eastRow, eastCol])
                MazeTraversalHelper(eastRow, eastCol, grid);
            if (!curRoom.GetWestDoor().IsLocked() && !grid[westRow, westCol])
                MazeTraversalHelper(westRow, westCol, grid);
        }
    }
}