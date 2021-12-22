using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Abstrs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls
{
    /// <summary>
    /// Todo: Add a builder
    /// </summary>
    public class MvcViewStateImpl
        : AbstractMvcViewState
    {
        /// <inheritdoc/>
        public MvcViewStateImpl SetMvcModelRequest(IMvcModelRequest mvcModelRequest)
        {
            this.mvcModelRequest = mvcModelRequest;
            return this;
        }

        /// <inheritdoc/>
        public MvcViewStateImpl SetMvcControlInputTypes(ISet<MvcControlInputType> mvcControlInputTypes)
        {
            this.mvcControlInputTypes = new HashSet<MvcControlInputType>(mvcControlInputTypes);
            return this;
        }

        /// <inheritdoc/>
        protected override string GetContent()
        {
            return string.Format("{0}s:[{1}], " +
                "\n{2}", typeof(MvcControlInputType).Name,
                string.Join(", ", this.mvcControlInputTypes),
                (this.mvcModelRequest != null)
                ? this.mvcModelRequest.ToString() : "No request selected");
        }
    }
}