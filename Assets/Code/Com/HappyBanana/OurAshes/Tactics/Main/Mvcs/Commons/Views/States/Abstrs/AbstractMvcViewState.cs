using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Abstrs
{
    /// <summary>
    /// Todo: Add a builder
    /// </summary>
    public abstract class AbstractMvcViewState
        : IMvcViewState
    {
        // Todo
        protected IList<MvcControlInputType> mvcControlInputTypes = new List<MvcControlInputType>();

        // Todo
        protected IMvcRequest mvcModelRequest = null;

        /// <inheritdoc/>
        public abstract IMvcViewState GetCopy();

        /// <inheritdoc/>
        IList<MvcControlInputType> IMvcViewState.GetMvcControlInputTypes()
        {
            return new List<MvcControlInputType>(this.mvcControlInputTypes);
        }

        /// <inheritdoc/>
        IOptional<IMvcRequest> IMvcViewState.GetMvcModelRequest()
        {
            return Optional<IMvcRequest>.Of(this.mvcModelRequest);
        }
    }
}