using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Sims.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constrs.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constrs.Inters;
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
        SimsType GetSimulationType();

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

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcControlConstruction GetMvcControlConstruction();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcModelConstruction GetMvcModelConstruction();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IMvcViewConstruction GetMvcViewConstruction();
    }
}