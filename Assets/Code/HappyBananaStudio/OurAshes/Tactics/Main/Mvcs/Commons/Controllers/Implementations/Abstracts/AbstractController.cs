using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Requests.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Mvc Controller Implementation
    /// </summary>
    public abstract class AbstractController
        : IMvcController
    {
        // Todo
        protected IMvcControllerRequest MvcControllerRequest;

        /// <inheritdoc/>
        IMvcControllerRequest IMvcController.OutputControllerRequest()
        {
            IMvcControllerRequest mvcControllerRequest = null;
            if (this.MvcControllerRequest != null)
            {
                mvcControllerRequest = this.MvcControllerRequest;
                this.MvcControllerRequest = null;
            }
            return mvcControllerRequest;
        }
    }
}