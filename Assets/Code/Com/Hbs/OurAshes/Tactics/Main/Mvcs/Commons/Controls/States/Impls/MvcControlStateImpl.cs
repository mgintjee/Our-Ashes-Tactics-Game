using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;

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

        public MvcControlStateImpl(IMvcControlState mvcControlState)
            : base(mvcControlState)
        {
        }

        public MvcControlStateImpl SetMvcModelRequest(IMvcModelRequest mvcModelRequest)
        {
            this.mvcModelRequest = mvcModelRequest;
            return this;
        }

        public MvcControlStateImpl SetMvcControlInput(IMvcControlInput mvcControlInput)
        {
            this.mvcControlInput = mvcControlInput;
            return this;
        }

        protected override string GetContent()
        {
            throw new System.NotImplementedException();
        }
    }
}