using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Impls
{
    /// <summary>
    /// Todo: Add a builder
    /// </summary>
    public class DefaultMvcControlStateImpl
        : AbstractMvcControlState
    {
        public DefaultMvcControlStateImpl()
        {
        }

        public DefaultMvcControlStateImpl SetMvcModelRequest(IMvcRequest mvcModelRequest)
        {
            this.mvcModelRequest = mvcModelRequest;
            return this;
        }

        public DefaultMvcControlStateImpl SetMvcControlInput(IMvcControlInput mvcControlInput)
        {
            this.mvcControlInput = mvcControlInput;
            return this;
        }

        /// <inheritdoc/>
        public override IMvcControlState GetCopy()
        {
            return new DefaultMvcControlStateImpl()
                .SetMvcModelRequest(this.mvcModelRequest)
                .SetMvcControlInput(this.mvcControlInput);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: " +
                "\nRequest: {1}, " +
                "\nInput: {2}",
                this.GetType().Name, this.mvcModelRequest, this.mvcControlInput);
        }
    }
}