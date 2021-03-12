namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.GameBoards.Talons.Utils
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.ResourceLoaders.GameObjects;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Managers;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Loadouts.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Reports.Api;
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
            ICustomizationReport customizationReport = talonReport.GetCustomizationReport();
            TalonId talonId = talonLoadoutReport.GetTalonId();
            GameObject gameObject = GameObjectResourceLoader.Talons.LoadTalonGameObjectResource(talonId);
            gameObject.name = talonCallSign + ": " + talonId;
            return gameObject;
        }
    }
}