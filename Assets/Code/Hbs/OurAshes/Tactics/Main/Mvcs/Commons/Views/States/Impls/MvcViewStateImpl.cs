using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Abstrs;
using System.Collections.Generic;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Impls
{
    /// <summary>
    /// Todo: Add a builder
    /// </summary>
    public class MvcViewStateImpl
        : AbstractMvcViewState
    {
        /// <inheritdoc/>
        public void SetMvcModelRequest(IMvcModelRequest mvcModelRequest)
        {
            this.mvcModelRequest = mvcModelRequest;
        }

        /// <inheritdoc/>
        public void SetMvcControlInputTypes(ISet<MvcControlInputType> mvcControlInputTypes)
        {
            this.mvcControlInputTypes = new HashSet<MvcControlInputType>(mvcControlInputTypes);
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