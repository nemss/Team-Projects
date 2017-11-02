using System;

namespace TheTieSilincer.EventArguments
{
    public class NewShipCollidesWithPlayerShipEventEventArgs : EventArgs
    {
        public NewShipCollidesWithPlayerShipEventEventArgs(int demage)
        {
            this.Demage = demage;
        }

        public int Demage { get; private set; }
    }
}