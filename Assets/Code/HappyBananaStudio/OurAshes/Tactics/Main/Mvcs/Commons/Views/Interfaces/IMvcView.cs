using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Models.Responses.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Interfaces
{
    /// <summary>
    /// Mvc View Interface
    /// </summary>
    public interface IMvcView
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcModelResponse"></param>
        void InputModelResponse(IMvcModelResponse mvcModelResponse);
    }
}