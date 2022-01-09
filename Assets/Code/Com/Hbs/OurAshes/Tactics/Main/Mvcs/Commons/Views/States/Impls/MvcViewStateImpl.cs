using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls
{
    public class MvcViewStateImpl
        : AbstractMvcViewState
    {
        public MvcViewStateImpl()
        {
        }

        public MvcViewStateImpl SetMvcModelRequest(IMvcRequest mvcModelRequest)
        {
            this.mvcModelRequest = mvcModelRequest;
            return this;
        }

        public MvcViewStateImpl SetMvcControlInputTypes(ISet<MvcControlInputType> mvcControlInputTypes)
        {
            this.mvcControlInputTypes = new HashSet<MvcControlInputType>(mvcControlInputTypes);
            return this;
        }

        /// <inheritdoc/>
        public override IMvcViewState GetCopy()
        {
            return new MvcViewStateImpl()
                .SetMvcControlInputTypes(this.mvcControlInputTypes)
                .SetMvcModelRequest(this.mvcModelRequest);
        }
    }
}