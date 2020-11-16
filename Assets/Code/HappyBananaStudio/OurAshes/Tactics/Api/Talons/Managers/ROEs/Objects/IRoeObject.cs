namespace HappyBananaStudio.OurAshes.Tactics.Api.ROEs.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
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
        bool AreCallSignsFriendly(CallSign callSignA, CallSign callSignB);

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">
        /// </param>
        /// <returns>
        /// </returns>
        ISet<CallSign> GetFriendlyCallSignSet(CallSign callSign);
    }
}
