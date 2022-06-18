using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.States.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Frames.States.Impls
{
    public class MvcFrameStateImpl
        : IMvcFrameState
    {
        private MvcType mvcType;

        // Todo
        private IMvcModelState mvcModelState;

        // Todo
        private IMvcControlState mvcControlState;

        // Todo
        private IMvcViewState mvcViewState;

        public MvcFrameStateImpl(MvcType mvcType)
        {
            this.mvcType = mvcType;
        }

        public MvcFrameStateImpl(IMvcFrameState mvcFrameState)
        {
            this.mvcType = mvcFrameState.GetMvcType();
            this.SetMvcControlState(mvcFrameState.GetMvcControlState());
            this.SetMvcModelState(mvcFrameState.GetMvcModelState());
            this.SetMvcViewState(mvcFrameState.GetMvcViewState());
        }

        public MvcFrameStateImpl SetMvcControlState(IMvcControlState mvcControlState)
        {
            this.mvcControlState = mvcControlState.GetCopy();
            return this;
        }

        public MvcFrameStateImpl SetMvcModelState(IMvcModelState mvcModelState)
        {
            this.mvcModelState = mvcModelState.GetCopy();
            return this;
        }

        public MvcFrameStateImpl SetMvcViewState(IMvcViewState mvcViewState)
        {
            this.mvcViewState = mvcViewState.GetCopy();
            return this;
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

        MvcType IMvcFrameState.GetMvcType()
        {
            return this.mvcType;
        }
    }
}