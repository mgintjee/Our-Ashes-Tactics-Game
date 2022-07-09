using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Utils.Strings;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Requests.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;
using System.Collections.Generic;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls
{
    public class DefaultMvcViewStateImpl
        : AbstractMvcViewState
    {
        public DefaultMvcViewStateImpl()
        {
        }

        public DefaultMvcViewStateImpl SetMvcModelRequest(IMvcRequest mvcModelRequest)
        {
            this.mvcModelRequest = mvcModelRequest;
            return this;
        }

        public DefaultMvcViewStateImpl SetMvcControlInputTypes(IList<MvcControlInputType> mvcControlInputTypes)
        {
            this.mvcControlInputTypes = new List<MvcControlInputType>(mvcControlInputTypes);
            return this;
        }

        public void Reset()
        {
            this.mvcModelRequest = null;
            this.mvcControlInputTypes = new List<MvcControlInputType>() { MvcControlInputType.Click };
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: {1}, {2}",
                this.GetType().Name, this.mvcModelRequest,
                StringUtils.Format(this.mvcControlInputTypes));
        }

        /// <inheritdoc/>
        public override IMvcViewState GetCopy()
        {
            return new DefaultMvcViewStateImpl()
                .SetMvcControlInputTypes(this.mvcControlInputTypes)
                .SetMvcModelRequest(this.mvcModelRequest);
        }
    }
}