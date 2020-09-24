/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;
using HappyBananaStudio.OurAshesTactics.Talon.Object.Api;

namespace HappyBananaStudio.OurAshesTactics.Talon.Visual.Api
{
    /// <summary>
    /// Talon Canvas Script Api
    /// </summary>
    public abstract class TalonCanvasScript
    : AbstractUnityScript
    {
        #region Public Methods

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public abstract ITalonCanvasObject GetTalonCanvasObject();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObject"></param>
        public abstract void Initialize(ITalonObject talonObject);

        /// <summary>
        /// Todo
        /// </summary>
        public abstract void UpdateCanvas();

        #endregion Public Methods
    }
}