using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Abstrs
{
    /// <summary>
    /// Todo: Add a builder
    /// </summary>
    public abstract class AbstractMvcViewState
        : AbstractReport, IMvcViewState
    {
        // Todo
        protected ISet<MvcControlInputType> mvcControlInputTypes = new HashSet<MvcControlInputType>();

        // Todo
        protected IMvcModelRequest mvcModelRequest = null;

        public AbstractMvcViewState()
        {
        }

        public AbstractMvcViewState(IMvcViewState mvcControlState)
        {
            this.mvcControlInputTypes = new HashSet<MvcControlInputType>(mvcControlState.GetMvcControlInputTypes());
            this.mvcModelRequest = mvcControlState.GetMvcModelRequest().GetValue();
        }

        public Optional<IMvcModelRequest> GetMvcModelRequest()
        {
            return Optional<IMvcModelRequest>.Of(this.mvcModelRequest);
        }

        ISet<MvcControlInputType> IMvcViewState.GetMvcControlInputTypes()
        {
            return new HashSet<MvcControlInputType>(this.mvcControlInputTypes);
        }
    }
}