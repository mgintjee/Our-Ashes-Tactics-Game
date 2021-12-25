using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Handlers.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Handlers.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Inters;
using UnityEngine;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Handlers.Impls
{
    /// <summary>
    /// TOdo
    /// </summary>
    public class MvcControlInputHandlerClick
        : AbstractMvcControlInputHandler
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="classLogger"></param>
        public void SetClassLogger(IClassLogger classLogger)
        {
            if (this.classLogger == null)
            {
                this.classLogger = classLogger;
            }
        }

        /// <inheritdoc/>
        protected override void DetermineInput()
        {
            Vector3 mousePixelCoords = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                this.classLogger.Debug("Pressed Primary @ Pixel:{}", mousePixelCoords);
                this.mvcControlInput = new MvcControlInputClick(0,
                    new System.Numerics.Vector2(mousePixelCoords.x, mousePixelCoords.y));
            }
            else if (Input.GetMouseButtonDown(1))
            {
                this.classLogger.Debug("Pressed Secondary @ Pixel:{}", mousePixelCoords);
                this.mvcControlInput = new MvcControlInputClick(1,
                    new System.Numerics.Vector2(mousePixelCoords.x, mousePixelCoords.y));
            }
            else if (Input.GetMouseButtonDown(2))
            {
                this.classLogger.Debug("Pressed Tertiary @ Pixel:{}", mousePixelCoords);
                this.mvcControlInput = new MvcControlInputClick(2,
                    new System.Numerics.Vector2(mousePixelCoords.x, mousePixelCoords.y));
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
                : IScriptBuilder<IMvcControlInputHandler>
            {
                IInternalBuilder SetMvcType(MvcType mvcType);

                IInternalBuilder SetIsEnabled(bool isEnabled);
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
            private class InternalBuilder
                : AbstractScriptBuilder<IMvcControlInputHandler>, IInternalBuilder
            {
                // Todo
                private bool isEnabled = false;

                // Todo
                private MvcType mvcType;

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetMvcType(MvcType mvcType)
                {
                    this.mvcType = mvcType;
                    return this;
                }

                /// <inheritdoc/>
                IInternalBuilder IInternalBuilder.SetIsEnabled(bool isEnabled)
                {
                    this.isEnabled = isEnabled;
                    return this;
                }

                /// <inheritdoc/>
                protected override IMvcControlInputHandler BuildScript(GameObject gameObject)
                {
                    IMvcControlInputHandler mvcControlInputHandlerClick = gameObject
                        .AddComponent<MvcControlInputHandlerClick>();
                    ((MvcControlInputHandlerClick)mvcControlInputHandlerClick).SetClassLogger(
                        LoggerManager.GetLogger(this.mvcType).GetClassLogger(typeof(MvcControlInputHandlerClick)));
                    mvcControlInputHandlerClick.SetParent(this.unityScript);
                    mvcControlInputHandlerClick.SetEnable(this.isEnabled);
                    return mvcControlInputHandlerClick;
                }
            }
        }
    }
}