using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Classes.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Loggers.Managers;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Frames.Types;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Abstrs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Fonts.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Builders.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Scripts.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Widgets.Specs.Inters;
using System.Diagnostics;
using System.Numerics;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Splashes.Views.Canvases
{
    /// <summary>
    /// Splash View Canvas Interface
    /// </summary>
    public class SplashViewCanvasImpl
        : AbstractMvcViewCanvas, IMvcViewCanvas
    {
        // Todo
        private readonly IClassLogger _logger = LoggerManager.GetLogger(MvcType.Splash)
            .GetClassLogger(new StackFrame().GetMethod().DeclaringType);

        /// <inheritdoc/>
        protected override void InternalBuild()
        {
            Vector2 imageGridSize = new Vector2(7, 5);
            Vector2 imageGridCoords = new Vector2(0, 0);
            Vector2 imageWorldSize = this.gridConvertor.GetWorldSize(imageGridSize);
            Vector2 imageWorldCoords = this.gridConvertor.GetWorldCoords(imageGridCoords, imageGridSize);
            Vector2 textGridSize = new Vector2(3, 1);
            Vector2 textGridCoords = new Vector2(2, 1);
            Vector2 textWorldSize = this.gridConvertor.GetWorldSize(imageGridSize);
            Vector2 textWorldCoords = this.gridConvertor.GetWorldCoords(imageGridCoords, imageGridSize);
            IImageWidget imageWidget = ImageWidgetImpl.Builder.Get()
                .SetSpriteID(SpriteID.Circle)
                .SetColorID(ColorID.Gray)
                .SetCanvasWidgetSpec(new CanvasWidgetSpecImpl()
                    .SetCanvasLevel(3)
                    .SetInteractable(true)
                    .SetCanvasGridCoords(imageGridCoords)
                    .SetCanvasGridSize(imageGridSize)
                    .SetCanvasWorldCoords(imageWorldCoords)
                    .SetCanvasWorldSize(imageWorldSize))
                .SetParent(this)
                .SetName(this.GetType().Name + ":Image")
                .Build();
            ITextWidget textWidget = TextWidgetImpl.Builder.Get()
                .SetText("PRESS ANYWHERE TO CONTINUE")
                .SetFont(FontID.Arial)
                .SetCanvasWidgetSpec(new CanvasWidgetSpecImpl()
                    .SetCanvasLevel(3)
                    .SetInteractable(true)
                    .SetCanvasGridCoords(textGridCoords)
                    .SetCanvasGridSize(textGridSize)
                    .SetCanvasWorldCoords(textWorldCoords)
                    .SetCanvasWorldSize(textWorldSize))
                .SetParent(this)
                .SetName(this.GetType().Name + ":Text")
                .Build();
            this.AddWidget(imageWidget);
            this.AddWidget(textWidget);
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Todo
            /// </summary>
            public interface IBuilder
                : ICanvasBuilder<IMvcViewCanvas>
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
            private class InternalBuilder
                : AbstractCanvasBuilder<IMvcViewCanvas>, IBuilder
            {
                /// <inheritdoc/>
                protected override IMvcViewCanvas BuildScript(UnityEngine.GameObject gameObject)
                {
                    IMvcViewCanvas mvcViewCanvas = gameObject.AddComponent<SplashViewCanvasImpl>();
                    this.ApplyCanvasValues((AbstractMvcViewCanvas)mvcViewCanvas);
                    mvcViewCanvas.Build();
                    return mvcViewCanvas;
                }
            }
        }
    }
}