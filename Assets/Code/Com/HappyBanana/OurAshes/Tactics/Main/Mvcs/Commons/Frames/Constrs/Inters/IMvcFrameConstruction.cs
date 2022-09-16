using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constrs.Inters
{
    /// <summary>
    /// Mvc Frame Construction Interface
    /// </summary>
    public interface IMvcFrameConstruction
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IUnityScript GetUnityScript();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        SimType GetSimulationType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MvcType GetMvcType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        Random GetRandom();
    }
}