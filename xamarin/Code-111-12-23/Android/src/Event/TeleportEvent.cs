using System;

namespace PenghuSpace.Event
{
    public class TeleportEvent : EventArgs
    {
        public event EventHandler teleportevent;

        public void Run()
        {
            teleportevent(this, Empty);
        }
    }
}