namespace MazeBuilder
{
    public class Door
    {
        private bool _locked, _open;

        public bool IsLocked()
        {
            return _locked;
        }

        public bool IsOpen()
        {
            return _open;
        }

        public void Lock()
        {
            _locked = true;
        }

        public void Unlock()
        {
            _locked = false;
        }

        public void Open()
        {
            _open = true;
        }

        public void Close()
        {
            _open = false;
        }

        public bool CanPass()
        {
            if (_open)
                return true;
            if (!_locked && !_open)
                return true;
            return false;
        }
    }
}