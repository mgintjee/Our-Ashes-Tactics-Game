using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Interfaces;
using System;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Mvcs.Interfaces
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMvcLogger
    {
        IClassLogger GetClassLogger(Type type);

        void EndLogging();
    }
}