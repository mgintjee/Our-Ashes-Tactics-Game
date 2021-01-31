namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Reports.Phalanxes.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.AIs.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Controllers.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IPhalanxReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        PhalanxCallSign GetPhalanxCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ControllerType GetControllerType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ICustomizationReport GetCustomizationReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        AIType GetAIType();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<TalonCallSign> GetTalonCallSigns();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<PhalanxCallSign> GetFriendlyPhalanxCallSigns();
    }
}