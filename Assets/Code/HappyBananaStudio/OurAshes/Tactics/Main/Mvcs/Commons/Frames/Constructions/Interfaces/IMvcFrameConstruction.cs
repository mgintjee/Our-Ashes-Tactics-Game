using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Simulations.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Mvcs.Types;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Reports.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Scripts.Unity.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constructions.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constructions.Interfaces;
using System;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces
{
    /// <summary>
    /// Mvc Frame Construction Interface
    /// </summary>
    public interface IMvcFrameConstruction
        : IReport
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
        SimulationType GetSimulationType();

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
        IMvcControllerConstruction GetMvcControllerConstruction();

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