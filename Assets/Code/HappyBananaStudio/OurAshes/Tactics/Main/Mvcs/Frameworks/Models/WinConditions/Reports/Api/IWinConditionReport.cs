namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.WinConditions.Reports.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Todo
    /// </summary>
    public interface IWinConditionReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ISet<TalonCallSign> GetTalonCallSignSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        MatchType GetMatchType();
    }
}