using System;

namespace MazeBuilder
{
    public class MazeBuilder
    {
        private readonly int _dimension;

        public MazeBuilder()
        {
            _dimension = 2;
        }

        public MazeBuilder(int num)
        {
            _dimension = num;
        }

        public Maze Build()
        {
            var newMaze = new Maze();

            newMaze.SetRooms(RoomSetup());
            newMaze.SetDimension(_dimension);
            RandomLocks(newMaze);
            LockBoarder(newMaze);

            return newMaze;
        }

        private Room[,] RoomSetup()
        {
            var rooms = new Room[_dimension, _dimension];

            // Initializing Rooms
            int i, j;
            for (i = 0; i < _dimension; i++)
            {
                for (j = 0; j < _dimension; j++)
                {
                    rooms[i, j] = new Room();
                }
            }
            DoorSetup(rooms);

            rooms = RandomlyPlaceExit(rooms);
            //rooms[this.dimension - 1][this.dimension - 1].setExit();

            return rooms;
        }

        private Room[,] RandomlyPlaceExit(Room[,] rooms)
        {
            var rand = new Random();
            int randomX, randomY;

            do
            {
                randomX = rand.Next((_dimension - (_dimension - 5)) - 1);
                randomY = rand.Next((_dimension - (_dimension - 5)) - 1);
            } while (randomX < 2);

            rooms[randomX, randomY].SetExit();

            return rooms;
        }

        private void DoorSetup(Room[,] rooms)
        {
            int i, j;

            // Setting up West and East Shared Doors
            for (i = 0; i < _dimension; i++)
            {
                rooms[i, 0].SetWestDoor(new Door());
                rooms[i, 0].SetEastDoor(new Door());
            }
            for (i = 0; i < _dimension; i++)
                for (j = 1; j < _dimension; j++)
                {
                    rooms[i, j].SetWestDoor(rooms[i, j - 1].GetEasthDoor());

                    if (j == _dimension - 1)
                        rooms[i, j].SetEastDoor(rooms[i, 0].GetWestDoor());
                    else
                        rooms[i, j].SetEastDoor(new Door());
                }

            // Setting up North and South Shared Doors
            for (i = 0; i < _dimension; i++)
            {
                rooms[0, i].SetNorthDoor(new Door());
                rooms[0, i].SetSouthDoor(new Door());
            }
            for (i = 1; i < _dimension; i++)
                for (j = 0; j < _dimension; j++)
                {
                    rooms[i, j].SetNorthDoor(rooms[i - 1, j].GetSouthDoor());

                    if (i == _dimension - 1)
                        rooms[i, j].SetSouthDoor(rooms[0, j].GetNorthDoor());
                    else
                        rooms[i, j].SetSouthDoor(new Door());
                }
        }

        private void LockBoarder(Maze maze)
        {
            var rooms = maze.GetRooms();

            int i, j;

            for (i = 0; i < maze.GetDimension(); i++)
                for (j = 0; j < maze.GetDimension(); j++)
                {
                    if (i == 0)
                        rooms[i, j].LockNorth();
                    if (j == 0)
                        rooms[i, j].LockWest();
                }
        }

        private void RandomLocks(Maze maze)
        {
            var rooms = maze.GetRooms();
            int i, j;
            var gen = new Random();
            for (i = 0; i < maze.GetDimension(); i++)
                for (j = 0; j < maze.GetDimension(); j++)
                {
                    var rand = gen.Next(2);
                    var rand2 = gen.Next(4);
                    if (rand == 0)
                        break;
                    if (rand2 == 0)
                        rooms[i, j].GetNorthDoor().Lock();
                    if (rand2 == 1)
                        rooms[i, j].GetSouthDoor().Lock();
                    if (rand2 == 2)
                        rooms[i, j].GetWestDoor().Lock();
                    if (rand2 == 3)
                        rooms[i, j].GetEasthDoor().Lock();
                }
        }
    }
}