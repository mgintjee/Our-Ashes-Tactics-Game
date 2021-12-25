using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using System;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Mvcs.Inters
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