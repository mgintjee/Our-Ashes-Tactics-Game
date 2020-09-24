/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Api;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Reports;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Map.Api
{
    /// <summary>
    /// Map Script Api
    /// </summary>
    public abstract class MapScript
    : AbstractUnityScript
    {
        #region Public Methods

        public abstract IMapObject GetMapObject();

        public abstract void Initialize(MvcModelScript mcvModelScript, MapConstructionReport mapConstructionReport);

        public abstract bool IsInitialized();

        #endregion Public Methods
    }
}