using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Classes.Inters;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Mvcs.Inters
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