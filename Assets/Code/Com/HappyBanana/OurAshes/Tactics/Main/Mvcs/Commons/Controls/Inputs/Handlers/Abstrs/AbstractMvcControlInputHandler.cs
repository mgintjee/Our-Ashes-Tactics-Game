using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Loggers.Classes.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Apis.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Commons.Internals.Optionals;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Handlers.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Abstrs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Handlers.Abstrs
{
    /// <summary>
    /// Abstract Mvc Control Impl
    /// </summary>
    public abstract class AbstractMvcControlInputHandler
        : AbstractUnityScript, IMvcControlInputHandler
    {
        // Todo
        protected IClassLogger classLogger;

        // Todo
        protected IMvcControlInputClick mvcControlInput = null;

        // Todo
        protected MvcControlInputType mvcControlInputType;

        // Todo
        private bool isEnabled = false;

        public void Update()
        {
            if (this.isEnabled)
            {
                this.DetermineInput();
            }
        }

        void IMvcControlInputHandler.SetEnable(bool isEnabled)
        {
            this.classLogger.Info("Enabling: {}", isEnabled);
            this.isEnabled = isEnabled;
        }

        IOptional<IMvcControlInputClick> IMvcControlInputHandler.GetMvcControlInput()
        {
            return Optional<IMvcControlInputClick>.Of(this.mvcControlInput);
        }

        MvcControlInputType IMvcControlInputHandler.GetMvcControlInputType()
        {
            return this.mvcControlInputType;
        }

        void IMvcControlInputHandler.ClearInput()
        {
            this.mvcControlInput = null;
        }

        protected abstract void DetermineInput();
    }
}