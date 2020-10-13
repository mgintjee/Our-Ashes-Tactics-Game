/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Factions.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Phalanxes.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Common.Constants.Talons.Enums;

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
