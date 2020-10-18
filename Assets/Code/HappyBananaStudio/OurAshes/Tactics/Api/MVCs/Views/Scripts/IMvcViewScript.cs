
namespace HappyBananaStudio.OurAshes.Tactics.Api.MVCs.Views.Scripts
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Unity.Scripts;

    /// <summary>
    /// MvcView Script Api
    /// </summary>
    public interface IMvcViewScript
        : IUnityScript
    {
        /// <summary>
        /// Todo
        /// </summary>
        void LoadWidgets();

        /// <summary>
        /// Todo
        /// </summary>
        void UpdateWidgets();
    }
}
