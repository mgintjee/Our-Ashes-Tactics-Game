/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using HappyBananaStudio.OurAshesTactics.Mvc.Framework.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Roster.Reports;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Api
{
    /// <summary>
    /// MvcModel Script Api
    /// </summary>
    public abstract class MvcModelScript
    : AbstractUnityScript
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract IMvcModelObject GetMvcModelObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcFrameworkScript">      </param>
        /// <param name="mapConstructionReport">   </param>
        /// <param name="rosterConstructionReport"></param>
        public abstract void Initialize(MvcFrameworkScript mvcFrameworkScript,
            MapConstructionReport mapConstructionReport,
            RosterConstructionReport rosterConstructionReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract bool IsInitialized();

        #endregion Public Methods
    }
}