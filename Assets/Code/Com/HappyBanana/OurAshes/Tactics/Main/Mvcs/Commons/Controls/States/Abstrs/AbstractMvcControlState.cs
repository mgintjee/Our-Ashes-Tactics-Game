using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Abstrs
{
    /// <summary>
    /// Todo: Add a builder
    /// </summary>
    public abstract class AbstractMvcControlState
        : IMvcControlState
    {
        // Todo
        protected IMvcControlInput mvcControlInput = null;

        // Todo
        protected IMvcRequest mvcModelRequest = null;

        /// <inheritdoc/>
        public abstract IMvcControlState GetCopy();

        /// <inheritdoc/>
        IOptional<IMvcControlInput> IMvcControlState.GetMvcControlInput()
        {
            return Optional<IMvcControlInput>.Of(this.mvcControlInput);
        }

        /// <inheritdoc/>
        IOptional<IMvcRequest> IMvcControlState.GetMvcModelRequest()
        {
            return Optional<IMvcRequest>.Of(this.mvcModelRequest);
        }
    }
}