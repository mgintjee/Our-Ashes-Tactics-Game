using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Common.Coordinates.Cube.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Attributes.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Models.Loadouts.Reports.Api;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Views.Customizations.Reports.Api;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Talons.Common.Reports.Api
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        TalonCallSign GetTalonCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITalonAttributesReport GetCurrentTalonAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITalonAttributesReport GetMaximumTalonAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICubeCoordinates GetCubeCoordinates();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITalonLoadoutReport GetTalonLoadoutReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITalonCustomizationReport GetTalonCustomizationReport();
    }
}