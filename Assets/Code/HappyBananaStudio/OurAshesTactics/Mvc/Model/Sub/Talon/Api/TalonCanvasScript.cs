/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshesTactics.Common.UnityScript;

namespace HappyBananaStudio.OurAshesTactics.Mvc.Model.Sub.Talon.Api
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