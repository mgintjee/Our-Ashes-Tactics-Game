

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
        CallSignEnum GetCallSign();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        FactionIdEnum GetFactionId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        PhalanxIdEnum GetPhalanxId();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        TalonModelIdEnum GetTalonModelId();
    }
}
