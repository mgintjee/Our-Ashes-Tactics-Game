using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Abstrs
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
        protected IMvcModelRequest mvcModelRequest = null;

        /// <inheritdoc/>
        public abstract IMvcControlState GetCopy();

        /// <inheritdoc/>
        Optional<IMvcControlInput> IMvcControlState.GetMvcControlInput()
        {
            return Optional<IMvcControlInput>.Of(this.mvcControlInput);
        }

        /// <inheritdoc/>
        Optional<IMvcModelRequest> IMvcControlState.GetMvcModelRequest()
        {
            return Optional<IMvcModelRequest>.Of(this.mvcModelRequest);
        }
    }
}