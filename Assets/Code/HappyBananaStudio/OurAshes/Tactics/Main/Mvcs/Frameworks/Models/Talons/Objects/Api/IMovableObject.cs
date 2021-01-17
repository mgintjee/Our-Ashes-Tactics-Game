namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Effects.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Engines.Attributes.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using System.Collections.Generic;

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