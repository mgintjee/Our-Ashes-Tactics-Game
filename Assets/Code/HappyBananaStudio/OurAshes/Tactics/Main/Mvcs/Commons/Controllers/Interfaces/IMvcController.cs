using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Requests.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces
{
    /// <summary>
    /// Mvc Controller Interface
    /// </summary>
    public interface IMvcController
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IRequest OutputControllerRequest();
    }
}