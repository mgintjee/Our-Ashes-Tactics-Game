namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Coordinates.Cube.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Effects.Objects.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Orders.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
    using System.Collections.Generic;

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