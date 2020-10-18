
namespace HappyBananaStudio.OurAshes.Tactics.Api.Widgets
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Unity.Scripts;
    using UnityEngine;

    /// <summary>
    /// Widget Script Api
    /// </summary>
    public interface IWidget
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        void UpdateWidgetPosition();

        /// <summary>
        /// Todo
        /// </summary>
        void UpdateWidgetDimensions();
    }
}
