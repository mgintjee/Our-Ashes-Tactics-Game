using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Handlers.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Impls;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Handlers.Abstrs
{
    /// <summary>
    /// Abstract Mvc Control Implementation
    /// </summary>
    public abstract class AbstractMvcControlInputHandler : UnityScript, IMvcControlInputHandler
    {
        // Todo
        protected IClassLogger classLogger;

        // Todo
        protected IMvcControlInputClick mvcControlInput = null;

        // Todo
        protected MvcControlInputType mvcControlInputType;

        // Todo
        private bool isEnabled = false;

        public void FixedUpdate()
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

        Optional<IMvcControlInputClick> IMvcControlInputHandler.GetMvcControlInput()
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