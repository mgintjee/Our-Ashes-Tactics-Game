using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Requests.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Interfaces;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Controllers.Implementations.Abstracts
{
    /// <summary>
    /// Abstract Mvc Controller Implementation
    /// </summary>
    public abstract class AbstractController
        : IMvcController
    {
        // Todo
        protected IRequest MvcControllerRequest;

        /// <inheritdoc/>
        IRequest IMvcController.OutputControllerRequest()
        {
            IRequest mvcControllerRequest = null;
            if (this.MvcControllerRequest != null)
            {
                mvcControllerRequest = this.MvcControllerRequest;
                this.MvcControllerRequest = null;
            }
            return mvcControllerRequest;
        }
    }
}