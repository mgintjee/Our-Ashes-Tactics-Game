using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Simulations.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Frames.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Contstructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Constructions.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Interfaces;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Constructions.Interfaces;
using System;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Constructions.Interfaces
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