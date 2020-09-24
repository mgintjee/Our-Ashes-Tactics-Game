/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Reports;
using HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Weapon.Api;
using System.Collections.Generic;

namespace HappyBananaStudio.OurAshesTactics.Talon.Object.Api
{
    /// <summary>
    /// Talon Script Api
    /// </summary>
    public abstract class TalonScript
    : AbstractUnityScript
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract ITalonObject GetTalonObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonConstructionReport"></param>
        /// <param name="weaponObjectList">       </param>
        public abstract void Initialize(TalonConstructionReport talonConstructionReport, List<IWeaponObject> weaponObjectList);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract bool IsInitialized();

        #endregion Public Methods
    }
}