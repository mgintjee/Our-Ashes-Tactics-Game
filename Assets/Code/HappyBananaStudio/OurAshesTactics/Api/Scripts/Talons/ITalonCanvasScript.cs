/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Talons.Objects;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Unity;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Scripts.Talons
{
    /// <summary>
    /// Talon Canvas Script Api
    /// </summary>
    public interface ITalonCanvasScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonObject">
        /// </param>
        void Initialize(ITalonObject talonObject);

        /// <summary>
        /// Todo
        /// </summary>
        void UpdateCanvas();
    }
}