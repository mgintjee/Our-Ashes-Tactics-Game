using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Handlers.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Handlers.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Managers.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Abstrs;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Managers.Impls
{
    /// <summary>
    /// Mvc Control Input Impl
    /// </summary>
    public class MvcControlInputManagerImpl :
        AbstractUnityScript, IMvcControlInputManager
    {
        // Todo
        private readonly ISet<IMvcControlInputHandler> mvcControlInputHandlers =
            new HashSet<IMvcControlInputHandler>();

        // Todo
        private readonly IClassLogger logger = LoggerManager.GetLogger(MvcType.ScreenSplash)
            .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private IMvcControl mvcControl;

        // Todo
        private MvcType mvcType;

        /// <summary>
        /// Todo
        /// </summary>
        public void Start()
        {
            this.mvcControlInputHandlers.Add(MvcControlInputHandlerClick.Builder.Get()
                .SetMvcType(this.mvcType)
                .SetIsEnabled(true)
                .SetParent(this)
                .SetName(typeof(MvcControlInputHandlerClick).Name)
                .Build());
        }

        /// <summary>
        /// Todo
        /// </summary>
        public void FixedUpdate()
        {
            bool inputExists = false;
            foreach (IMvcControlInputHandler mvcControlInputHandler in this.mvcControlInputHandlers)
            {
                Optional<IMvcControlInputClick> mvcControlInput = mvcControlInputHandler.GetMvcControlInput();
                if (mvcControlInput.IsPresent())
                {
                    logger.Debug("Input found with {}!", mvcControlInputHandler.GetType());
                    this.mvcControl.Process(mvcControlInput.GetValue());
                    inputExists = true;
                    break;
                }
            }
            if (inputExists)
            {
                foreach (IMvcControlInputHandler inputHandler in this.mvcControlInputHandlers)
                {
                    inputHandler.ClearInput();
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="mvcControlInputTypes"></param>
        void IMvcControlInputManager.SetMvcControlInputs(ISet<MvcControlInputType> mvcControlInputTypes)
        {
            foreach (IMvcControlInputHandler mvcControlInputHandler in this.mvcControlInputHandlers)
            {
                mvcControlInputHandler.SetEnable(mvcControlInputTypes
                    .Contains(mvcControlInputHandler.GetMvcControlInputType()));
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IInternalBuilder
                : IScriptBuilder<IMvcControlInputManager>
            {
                IInternalBuilder SetMvcControl(IMvcControl mvcControl);

                IInternalBuilder SetMvcType(MvcType mvcType);
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IInternalBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder :
                AbstractScriptBuilder<IMvcControlInputManager>, IInternalBuilder
            {
                // Todo
                private IMvcControl mvcControl;

                // Todo
                private MvcType mvcType;

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetMvcControl(IMvcControl mvcControl)
                {
                    this.mvcControl = mvcControl;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetMvcType(MvcType mvcType)
                {
                    this.mvcType = mvcType;
                    return this;
                }

                /// <inheritdoc/>
                protected override IMvcControlInputManager BuildScript(GameObject gameObject)
                {
                    IMvcControlInputManager mvcControlInputManager = gameObject.AddComponent<MvcControlInputManagerImpl>();
                    mvcControlInputManager.SetParent(this.unityScript);

                    ((MvcControlInputManagerImpl)mvcControlInputManager).mvcType = this.mvcType;

                    ((MvcControlInputManagerImpl)mvcControlInputManager).mvcControl = this.mvcControl;
                    return mvcControlInputManager;
                }
            }
        }
    }
}