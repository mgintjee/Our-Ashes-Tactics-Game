using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Abstrs
{
    /// <summary>
    /// Todo Add a builder
    /// </summary>
    public abstract class AbstractMvcModelState
        : AbstractReport, IMvcModelState
    {
        private ISet<IMvcControlRequest> mvcControlRequests = new HashSet<IMvcControlRequest>();

        public AbstractMvcModelState()
        {
        }

        public AbstractMvcModelState(IMvcModelState mvcModelState)
        {
            this.mvcControlRequests = new HashSet<IMvcControlRequest>(mvcModelState.GetMvcControlRequests())
                ?? new HashSet<IMvcControlRequest>();
        }

        public void SetMvcModelRequests(ISet<IMvcControlRequest> mvcControlRequests)
        {
            this.mvcControlRequests = new HashSet<IMvcControlRequest>(mvcControlRequests);
        }

        ISet<IMvcControlRequest> IMvcModelState.GetMvcControlRequests()
        {
            return new HashSet<IMvcControlRequest>(this.mvcControlRequests);
        }

        protected override string GetContent()
        {
            throw new System.NotImplementedException();
        }
    }
}