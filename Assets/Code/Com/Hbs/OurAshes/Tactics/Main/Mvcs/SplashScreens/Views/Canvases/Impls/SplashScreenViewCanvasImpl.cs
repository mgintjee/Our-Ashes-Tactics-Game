using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Models.States.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.Aligns;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.SplashScreens.Views.Canvases.Impls
{
    /// <summary>
    /// SplashScreen View Canvas Implementation
    /// </summary>
    public class SplashScreenViewCanvasImpl
        : AbstractMvcViewCanvas, IMvcViewCanvas
    {
        public override void InitialBuild()
        {
            ICanvasWidget backgrounWidget = this.BuildBackground();
            backgrounWidget.SetInteractable(true);
            List<ICanvasWidget> canvasWidgets = new List<ICanvasWidget>
            {
                backgrounWidget,
                this.BuildSubheader()
            };
            canvasWidgets.AddRange(this.BuildHeader());
            this.AddWidgets(canvasWidgets);
        }

        public override void Process(IMvcModelState mvcModelState)
        {
            throw new System.NotImplementedException();
        }

        private ICanvasWidget BuildSubheader()
        {
            return TextWidgetImpl.Builder.Get()
                .SetText("Input anywhere\nto continue...")
                .SetFont(FontID.Arial)
                .SetColor(ColorID.White)
                .SetAlign(AlignType.MiddleCenter)
                .SetBestFit(true, 13, 50)
                .SetCanvasLevel(1)
                .SetInteractable(false)
                .SetEnabled(true)
                .SetWidgetGridSpec(new CanvasGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(3, 1))
                    .SetCanvasGridSize(new Vector2(3, 1)))
                .SetParent(this)
                .SetName(this.mvcType + ":SubheaderText")
                .Build();
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
                : AbstractViewCanvasBuilders.IViewCanvasBuilder
            {
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
                : AbstractViewCanvasBuilders.AbstractViewCanvasBuilder, IInternalBuilder
            {
                /// <inheritdoc/>
                protected override IMvcViewCanvas BuildScript(UnityEngine.GameObject gameObject)
                {
                    IMvcViewCanvas mvcViewCanvas = gameObject.AddComponent<SplashScreenViewCanvasImpl>();
                    this.ApplyMvcViewValues((AbstractMvcViewCanvas)mvcViewCanvas);
                    mvcViewCanvas.InitialBuild();
                    return mvcViewCanvas;
                }
            }
        }
    }
}