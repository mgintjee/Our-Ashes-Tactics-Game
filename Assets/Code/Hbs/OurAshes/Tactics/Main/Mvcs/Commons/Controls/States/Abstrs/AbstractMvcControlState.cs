using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;

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
        protected IMvcModelRequest mvcModelRequest = null;

        public AbstractMvcControlState()
        {
        }

        public AbstractMvcControlState(IMvcControlState mvcControlState)
        {
            this.mvcControlInput = mvcControlState.GetMvcControlInput().GetValue();
            this.mvcModelRequest = mvcControlState.GetMvcModelRequest().GetValue();
        }

        public Optional<IMvcModelRequest> GetMvcModelRequest()
        {
            return Optional<IMvcModelRequest>.Of(this.mvcModelRequest);
        }

        public Optional<IMvcControlInput> GetMvcControlInput()
        {
            return Optional<IMvcControlInput>.Of(this.mvcControlInput);
        }
    }
}