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
        /// <param name="callSignA">
        /// </param>
        /// <param name="callSignB">
        /// </param>
        /// <returns>
        /// </returns>
        bool AreCallSignsFriendly(TalonCallSign callSignA, TalonCallSign callSignB);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">
        /// </param>
        /// <returns>
        /// </returns>
        ISet<TalonCallSign> GetFriendlyCallSignSet(TalonCallSign callSign);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IRoeReport GetRoeReport();
    }
}