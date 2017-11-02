namespace Library.Client.Core.Commands
{
    using System;

    public class ClearCommand
    {
        public string Execute(string[] inputArgs)
        {
            Console.Clear();
            return $"Successfully Clear All Text From Console";
        }
    }
}