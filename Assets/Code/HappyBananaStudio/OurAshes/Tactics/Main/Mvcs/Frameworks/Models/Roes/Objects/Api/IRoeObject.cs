namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Objects.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Roes.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Roe Object Api
    /// </summary>
    public interface IRoeObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSignA">
        /// </param>
        /// <param name="talonCallSignB">
        /// </param>
        /// <returns>
        /// </returns>
        bool AreCallSignsFriendly(TalonCallSign talonCallSignA, TalonCallSign talonCallSignB);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign">
        /// </param>
        /// <returns>
        /// </returns>
        ISet<TalonCallSign> GetFriendlyCallSignSet(TalonCallSign talonCallSign);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IRoeReport GetRoeReport();
    }
}