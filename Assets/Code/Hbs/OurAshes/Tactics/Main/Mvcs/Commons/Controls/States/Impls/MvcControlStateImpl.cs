using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.Requests.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Impls
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

        public void SetMvcModelRequest(IMvcModelRequest mvcModelRequest)
        {
            this.mvcModelRequest = mvcModelRequest;
        }

        public void SetMvcControlInput(IMvcControlInput mvcControlInput)
        {
            this.mvcControlInput = mvcControlInput;
        }

        protected override string GetContent()
        {
            throw new System.NotImplementedException();
        }
    }
}