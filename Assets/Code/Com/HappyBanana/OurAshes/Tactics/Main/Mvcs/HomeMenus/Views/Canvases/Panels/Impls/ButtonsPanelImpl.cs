using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Abstrs;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Panels.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Specs.Grids.Impls;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.HomeMenus.Frames.Requests.Types;
using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.HomeMenus.Views.Canvases.Panels.Impls
{
    /// <summary>
    /// HomeMenu Buttons PanelImpl
    /// </summary>
    public class ButtonsPanelImpl
        : AbstractPanelWidget
    {
        protected override void InitialBuild()
        {
            Vector2 buttonGridSize = new Vector2(this.canvasGridConvertor.GetGridSize().X,
                this.canvasGridConvertor.GetGridSize().Y / 5);
            this.InternalAddWidget(this.BuildBackground());
            this.InternalAddWidget(ButtonPanelImpl.Builder.Get()
                .SetButtonText(RequestType.QSortie.ToString())
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y * 4 / 5))
                    .SetCanvasGridSize(buttonGridSize))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetName(RequestType.QSortie + ":Button")
                .SetParent(this)
                .Build());
            this.InternalAddWidget(ButtonPanelImpl.Builder.Get()
                .SetButtonText(RequestType.Exit.ToString())
                .SetPanelGridSize(new Vector2(2, 1))
                .SetWidgetGridSpec(new WidgetGridSpecImpl()
                    .SetCanvasGridCoords(new Vector2(0, this.canvasGridConvertor.GetGridSize().Y * 0 / 5))
                    .SetCanvasGridSize(buttonGridSize))
                .SetMvcType(this.mvcType)
                .SetCanvasLevel(0)
                .SetInteractable(true)
                .SetEnabled(true)
                .SetName(RequestType.Exit + ":Button")
                .SetParent(this)
                .Build());
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
                : PanelWidgetBuilders.IPanelWidgetBuilder
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
                : PanelWidgetBuilders.InternalPanelWidgetBuilder, IInternalBuilder
            {
                protected override IPanelWidget BuildScript(UnityEngine.GameObject gameObject)
                {
                    IPanelWidget widget = gameObject.AddComponent<ButtonsPanelImpl>();
                    this.ApplyPanelValues(widget);
                    return widget;
                }
            }
        }
    }
}