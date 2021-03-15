using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Orders.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Effects.Objects.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Engines.Attributes.Api;
using System.Collections.Generic;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Objects.Subs.Movables.Api
{
    /// <summary>
    /// Movable Object Api
    /// </summary>
    public interface IMovableObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetCurrentActionPoints();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        float GetCurrentMovementPoints();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IEngineAttributes GetEngineAttributes();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<ITalonOrderReport> GetTalonOrderReportSet(ICubeCoordinates cubeCoordinates);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonEffectObject"></param>
        void InputTalonEffect(ITalonEffectObject talonEffectObject);

        /// <summary>
        /// Todo
        /// </summary>
        void ResetForNewPhase();
    }
}