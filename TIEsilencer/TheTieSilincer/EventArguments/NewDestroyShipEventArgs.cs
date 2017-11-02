namespace TheTieSilincer.EventArguments
{
    using System;

    public class NewDestroyShipEventArgs : EventArgs
    {
        public NewDestroyShipEventArgs(int points)
        {
            this.Points = points;
        }

        public int Points { get; private set; }
    }
}