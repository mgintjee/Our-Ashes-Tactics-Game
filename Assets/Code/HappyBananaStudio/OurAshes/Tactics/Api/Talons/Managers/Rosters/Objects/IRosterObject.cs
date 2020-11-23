namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Managers.Rosters.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Talons;
    using System.Collections.Generic;

    /// <summary>
    /// Roster Object Api
    /// </summary>
    public interface IRosterObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">
        /// </param>
        void DeactivateCallSign(CallSign callSign);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<CallSign> GetActiveCallSignSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        ISet<CallSign> GetAllCallSignSet();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="callSign">
        /// </param>
        /// <returns>
        /// </returns>
        ITalonObject GetTalonObject(CallSign callSign);
    }
}