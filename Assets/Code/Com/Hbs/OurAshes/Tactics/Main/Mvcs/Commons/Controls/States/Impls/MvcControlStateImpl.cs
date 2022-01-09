using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Impls
{
    /// <summary>
    /// Todo: Add a builder
    /// </summary>
    public class MvcControlStateImpl
        : AbstractMvcControlState
    {
        public MvcControlStateImpl()
        {
        }

        public MvcControlStateImpl SetMvcModelRequest(IMvcRequest mvcModelRequest)
        {
            this.mvcModelRequest = mvcModelRequest;
            return this;
        }

        public MvcControlStateImpl SetMvcControlInput(IMvcControlInput mvcControlInput)
        {
            this.mvcControlInput = mvcControlInput;
            return this;
        }

        /// <inheritdoc/>
        public override IMvcControlState GetCopy()
        {
            return new MvcControlStateImpl()
                .SetMvcModelRequest(this.mvcModelRequest)
                .SetMvcControlInput(this.mvcControlInput);
        }
    }
}