using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Canvases.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Builders.Canvases.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Canvases.Implementations;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Implementations.Abstracts;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Implementations.Abstracts.Basics;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Views.Widgets.Interfaces.Basics;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Canvases.Fores.Implementations
{
    /// <summary>
    /// Splash View Fore Canvas Interface
    /// </summary>
    public class SplashViewForeCanvas : AbstractMvcViewCanvas, IMvcViewCanvas
    {
        /// <inheritdoc/>
        protected override void InternalBuild()
        {
            IImageWidget imageWidget = ImageWidget.Builder.Get()
                .SetParentUnityScript(this)
                .SetSpriteID(SpriteID.Circle)
                .Build();
            this.AddWidget(imageWidget);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder : ICanvasBuilder<IMvcViewCanvas>
            {
            }

            /// <summary>
            /// Todo
            /// </summary>
            /// <returns></returns>
            public static IBuilder Get()
            {
                return new InternalBuilder();
            }

            /// <summary>
            /// Todo
            /// </summary>
            private class InternalBuilder : AbstractCanvasBuilder<IMvcViewCanvas>, IBuilder
            {
                /// <inheritdoc/>
                protected override void Validate(ISet<string> invalidReasons)
                {
                    this.Validate(invalidReasons, this.unityScript);
                    this.Validate(invalidReasons, this.name);
                }

                /// <inheritdoc/>
                protected override IMvcViewCanvas BuildScript(GameObject gameObject)
                {
                    IMvcViewCanvas mvcViewCanvas = gameObject.AddComponent<SplashViewForeCanvas>();
                    mvcViewCanvas.SetParent(this.unityScript);
                    ((SplashViewForeCanvas)mvcViewCanvas).SetMeasurements(this.canvasGridMeasurements);
                    mvcViewCanvas.Build();
                    return mvcViewCanvas;
                }
            }
        }
    }
}