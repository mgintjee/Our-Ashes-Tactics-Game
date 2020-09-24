/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Reports;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.HexTile.Api
{
    /// <summary>
    /// HexTile Script Api
    /// </summary>
    public abstract class HexTileScript
    : AbstractUnityScript
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract IHexTileObject GetHexTileObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="tileConstructionReport"></param>
        public abstract void Initialize(HexTileConstructionReport tileConstructionReport);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract bool IsInitialized();

        #endregion Public Methods
    }
}