using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Effects.Objects.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Objects.Api
{
    /// <summary>
    /// Talon MvcObject Api
    /// </summary>
    public interface ITalonObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITalonReport GetTalonReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonEffectObject"></param>
        void InputTalonEffect(ITalonEffectObject talonEffectObject);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<ITalonOrderReport> GetTalonOrderReportSet();

        /// <summary>
        /// Todo
        /// </summary>
        void ResetForNewPhase();

        /// <summary>
        /// Todo
        /// </summary>
        void SetCubeCoordinates(ICubeCoordinates cubeCoordinates);
    }
}