namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Objects.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Combats.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Roe Object Api
    /// </summary>
    public interface ICombatObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<ICombatReport> GetActualCombatReport(TalonCallSign actingTalonCallSign,
            TalonCallSign targetTalonCallSign, float accuracyCost);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IList<ICombatReport> GetAverageCombatReport(TalonCallSign actingTalonCallSign,
            TalonCallSign targetTalonCallSign, float accuracyCost);
    }
}