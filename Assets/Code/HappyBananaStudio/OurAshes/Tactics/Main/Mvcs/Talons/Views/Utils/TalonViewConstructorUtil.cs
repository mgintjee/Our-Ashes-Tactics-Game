namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Utils
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.ResourceLoaders.GameObjects;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Reports.Api;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class TalonViewConstructorUtil
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        public static GameObject ConstructGameObject(TalonCallSign talonCallSign)
        {
            ITalonReport talonReport = TalonRosterManager.GetTalonReport(talonCallSign);
            ITalonLoadoutReport talonLoadoutReport = talonReport.GetTalonLoadoutReport();
            ITalonCustomizationReport customizationReport = talonReport.GetTalonCustomizationReport();
            TalonId talonId = talonLoadoutReport.GetTalonId();
            GameObject gameObject = GameObjectResourceLoader.Talons.LoadTalonGameObjectResource(talonId);
            gameObject.name = talonCallSign + ": " + talonId;
            return gameObject;
        }
    }
}