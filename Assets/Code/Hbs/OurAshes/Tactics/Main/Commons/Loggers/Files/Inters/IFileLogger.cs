﻿namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Files.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IFileLogger
    {
        void WriteToFile(string message);

        void Shutdown();
    }
}