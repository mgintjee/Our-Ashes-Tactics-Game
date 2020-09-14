/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Reports;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Api
{
    /// <summary>
    /// Roster Script Api
    /// </summary>
    public abstract class RosterScript
    : AbstractUnityScript
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract IRosterObject GetRosterObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mcvModelScript">          </param>
        /// <param name="rosterConstructionReport"></param>
        public abstract void Initialize(MvcModelScript mcvModelScript, RosterConstructionReport rosterConstructionReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract bool IsInitialized();

        #endregion Public Methods
    }
}