using System;

namespace ConEvento
{
    public class Subject
    {
        public event EventHandler StateChanged;

        private int _state;
        public int State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnStateChanged(EventArgs.Empty);
                }
            }
        }

        protected virtual void OnStateChanged(EventArgs e)
        {
            StateChanged?.Invoke(this, e);
        }
    }
}
