using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Requests.Inters;
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
        private ISet<MvcControlInputType> mvcControlInputTypes = new HashSet<MvcControlInputType>();

        // Todo
        private IMvcControlRequest mvcControlRequest = null;

        public AbstractMvcViewState()
        {
        }

        public AbstractMvcViewState(IMvcViewState mvcControlState)
        {
            this.SetMvcControlInputTypes(mvcControlState.GetMvcControlInputTypes());
            this.SetMvcControlRequest(mvcControlState.GetMvcControlRequest().GetValue());
        }

        public Optional<IMvcControlRequest> GetMvcControlRequest()
        {
            return Optional<IMvcControlRequest>.Of(this.mvcControlRequest);
        }

        public void SetMvcControlRequest(IMvcControlRequest mvcControlRequest)
        {
            this.mvcControlRequest = mvcControlRequest;
        }

        public void SetMvcControlInputTypes(ISet<MvcControlInputType> mvcControlInputTypes)
        {
            this.mvcControlInputTypes = new HashSet<MvcControlInputType>(mvcControlInputTypes);
        }

        ISet<MvcControlInputType> IMvcViewState.GetMvcControlInputTypes()
        {
            return new HashSet<MvcControlInputType>(this.mvcControlInputTypes);
        }

        protected override string GetContent()
        {
            return string.Format("{0}" +
                "\n{1}" +
                "\n{2}");
        }
    }
}