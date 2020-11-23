namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Factions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;

    /// <summary>
    /// Todo
    /// </summary>
    public interface ITalonIdentificationReport
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        CallSign GetCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        FactionId GetFactionId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        PhalanxId GetPhalanxId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        TalonModelId GetTalonModelId();
    }
}