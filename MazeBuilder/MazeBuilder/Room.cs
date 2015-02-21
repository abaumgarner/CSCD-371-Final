namespace MazeBuilder
{
    public class Room
    {
        private bool _exit;
        private Door _northDoor, _southDoor, _eastDoor, _westDoor;

        public Door GetNorthDoor()
        {
            return _northDoor;
        }

        public void SetNorthDoor(Door north)
        {
            _northDoor = north;
        }

        public Door GetSouthDoor()
        {
            return _southDoor;
        }

        public void SetSouthDoor(Door south)
        {
            _southDoor = south;
        }

        public Door GetEasthDoor()
        {
            return _eastDoor;
        }

        public void SetEastDoor(Door east)
        {
            _eastDoor = east;
        }

        public Door GetWestDoor()
        {
            return _westDoor;
        }

        public void SetWestDoor(Door west)
        {
            _westDoor = west;
        }

        public bool IsExit()
        {
            return _exit;
        }

        public void SetExit()
        {
            _exit = true;
        }

        public void LockNorth()
        {
            _northDoor.Lock();
        }

        public void LockSouth()
        {
            _southDoor.Lock();
        }

        public void LockWest()
        {
            _westDoor.Lock();
        }

        public void LockEast()
        {
            _eastDoor.Lock();
        }
    }
}