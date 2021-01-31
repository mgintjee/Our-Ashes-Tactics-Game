namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Objects.Api
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Rosters.Talons.Reports.Api;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Enums;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Objects.Api;
    using System.Collections.Generic;

    /// <summary>
    /// Roster Object Api
    /// </summary>
    public interface ITalonRosterObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign">
        /// </param>
        void DeactivateTalonCallSign(TalonCallSign talonCallSign);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<TalonCallSign> GetActiveTalonCallSignSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<TalonCallSign> GetAllTalonCallSignSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonObject GetTalonObject(TalonCallSign talonCallSign);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        ITalonRosterReport GetTalonRosterReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonCallSign"></param>
        /// <returns></returns>
        bool IsTalonCallSignActive(TalonCallSign talonCallSign);
    }
}