using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Abstrs
{
    /// <summary>
    /// Todo: Add a builder
    /// </summary>
    public abstract class AbstractMvcViewState
        : IMvcViewState
    {
        // Todo
        protected ISet<MvcControlInputType> mvcControlInputTypes = new HashSet<MvcControlInputType>();

        // Todo
        protected IMvcRequest mvcModelRequest = null;

        /// <inheritdoc/>
        public abstract IMvcViewState GetCopy();

        /// <inheritdoc/>
        ISet<MvcControlInputType> IMvcViewState.GetMvcControlInputTypes()
        {
            return new HashSet<MvcControlInputType>(this.mvcControlInputTypes);
        }

        /// <inheritdoc/>
        Optional<IMvcRequest> IMvcViewState.GetMvcModelRequest()
        {
            return Optional<IMvcRequest>.Of(this.mvcModelRequest);
        }
    }
}