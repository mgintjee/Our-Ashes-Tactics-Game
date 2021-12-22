using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Abstrs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Impls
{
    /// <summary>
    /// Todo: Add a builder
    /// </summary>
    public class MvcModelStateImpl
        : AbstractMvcModelState
    {
        /// <inheritdoc/>
        public void SetMvcModelRequests(ISet<IMvcModelRequest> mvcModelRequests)
        {
            this.mvcModelRequests = new HashSet<IMvcModelRequest>(mvcModelRequests);
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}s:[{1}]", typeof(IMvcModelRequest).Name,
                string.Join(", ", this.mvcModelRequests));
        }
    }
}