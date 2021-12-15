using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Reports.Abstrs;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Abstrs
{
    public abstract class AbstractMvcFrameState
        : AbstractReport, IMvcFrameState
    {
        // Todo
        private IMvcModelState mvcModelState;

        // Todo
        private IMvcControlState mvcControlState;

        // Todo
        private IMvcViewState mvcViewState;

        public AbstractMvcFrameState()
        {
        }

        public AbstractMvcFrameState(IMvcFrameState mvcFrameState)
        {
            this.mvcModelState = this.WrapMvcModelState(mvcFrameState.GetMvcModelState());
            this.mvcControlState = this.WrapMvcControlState(mvcFrameState.GetMvcControlState());
            this.mvcViewState = this.WrapMvcViewState(mvcFrameState.GetMvcViewState());
        }

        public void SetMvcControlState(IMvcControlState mvcControlState)
        {
            this.mvcControlState = this.WrapMvcControlState(mvcControlState);
        }

        public void SetMvcModelState(IMvcModelState mvcModelState)
        {
            this.mvcModelState = this.WrapMvcModelState(mvcModelState);
        }

        public void SetMvcViewState(IMvcViewState mvcViewState)
        {
            this.mvcViewState = this.WrapMvcViewState(mvcViewState);
        }

        IMvcControlState IMvcFrameState.GetMvcControlState()
        {
            return this.mvcControlState;
        }

        IMvcModelState IMvcFrameState.GetMvcModelState()
        {
            return this.mvcModelState;
        }

        IMvcViewState IMvcFrameState.GetMvcViewState()
        {
            return this.mvcViewState;
        }

        protected override string GetContent()
        {
            return string.Format("{0}" +
                "\n{1}" +
                "\n{2}", this.mvcModelState, this.mvcControlState, this.mvcViewState);
        }

        protected abstract IMvcControlState WrapMvcControlState(IMvcControlState mvcControlState);

        protected abstract IMvcModelState WrapMvcModelState(IMvcModelState mvcModelState);

        protected abstract IMvcViewState WrapMvcViewState(IMvcViewState mvcViewState);
    }
}