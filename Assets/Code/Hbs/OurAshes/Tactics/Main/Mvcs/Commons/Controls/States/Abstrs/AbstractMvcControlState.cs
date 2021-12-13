using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Abstrs
{
    /// <summary>
    /// Todo: Add a builder
    /// </summary>
    public abstract class AbstractMvcControlState
        : AbstractReport, IMvcControlState
    {
        // Todo
        protected IMvcControlInput mvcControlInput = null;

        // Todo
        protected IMvcControlRequest mvcControlRequest = null;

        public AbstractMvcControlState()
        {
        }

        public AbstractMvcControlState(IMvcControlState mvcControlState)
        {
            this.mvcControlInput = mvcControlState.GetMvcControlInput().GetValue();
            this.mvcControlRequest = mvcControlState.GetMvcControlRequest().GetValue();
        }

        public Optional<IMvcControlRequest> GetMvcControlRequest()
        {
            return Optional<IMvcControlRequest>.Of(this.mvcControlRequest);
        }

        public Optional<IMvcControlInput> GetMvcControlInput()
        {
            return Optional<IMvcControlInput>.Of(this.mvcControlInput);
        }
    }
}